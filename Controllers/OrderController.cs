using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineWeb.Data;
using CineWeb.Models;
using CineWeb.Areas.Identity.Services;
using Stripe;

namespace CineWeb.Controllers
{
    // [Route("Book")]
    public class OrderController: Controller {
        private readonly WebContext _context;
        public OrderController(WebContext context) {
            _context = context;
        }
        // get order history by user
        public async Task<IActionResult> History(string uid) {
            if (uid == null) {
                return NotFound();
            }

            var orders = from i in _context.Orders /*orderby i.ShowTimeId.TimeStart*/ select i;
            orders = orders.Where(x => x.UserId.Id == uid);
            return View(await orders.ToListAsync());
        }
        /// NEW ORDER
        public async Task<IActionResult> Index(string movie, string show, uint Adult, uint Child, uint Senior) {
            var tickets = new uint[3] {Adult, Child, Senior}; // this should be changed to work dyamically, but I couldn't figure it out
            uint tleft = 0; // might drop this
            // collect currently available movies
            var movies = await (from i in _context.Movies where i.NowShowing==true select i.Title).ToListAsync();
            // collect upcoming showtimes
            var showtimes = from i in _context.ShowTimes where i.TimeStart > DateTime.Now select i;
            if (!string.IsNullOrEmpty(movie)) // if movie is selected, filter show times
                showtimes = showtimes.Where(x => x.MovieId == (from i in _context.Movies where i.Title==movie select i).FirstOrDefault());
            else // if movie is not selected, showtimes unavailable
                showtimes = showtimes.Where(x => false);
            var stlist = await showtimes.ToListAsync(); // begin conversion of showtimes to datetimes
            var sttimes = await (from i in _context.ShowTimes where stlist.Contains(i) select i.TimeStart).ToListAsync(); // end conversion of showtimes to datetimes
            // collect ticket types
            var ttypes = await (from i in _context.TicketTypes select i).ToListAsync();
            // store selected showtime
            string showtime = string.IsNullOrEmpty(show) ? null : (showtimes.Where(x => x.TimeStart==Convert.ToDateTime(show))).FirstOrDefault()?.ID.ToString();
            // store selected tickets
            var ticketstr = "";
            var ttotal = 0;
            if (tickets.Length == ttypes.Count){
                foreach (uint i in tickets){
                    ticketstr += i + ",";
                    ttotal += Convert.ToInt32(i);
                }
                ticketstr = ticketstr.Substring(0, ticketstr.Length - 1);
            }
            else {
                ticketstr = "0";
                tickets = new uint[ttypes.Count];
                for(int i = 0; i < tickets.Length; i++)
                    tickets[i] = 0;
            }
            // make readable for page
            var selector = new ShowSelector {
                films = new SelectList(movies),
                shows = new SelectList(sttimes),
                ttypes = ttypes,
                tleft = tleft,
                show = showtime,
                texport = ticketstr,
                tlocal = tickets,
                canGo = !string.IsNullOrEmpty(showtime) && ttotal > 0,
            };
            return View(selector);
        }
        /// SEAT SELECTION
        public async Task<IActionResult> SelSeat([FromQuery (Name = "show")] string show, [FromQuery (Name = "tickets")] string ticketstr, [FromQuery (Name = "seats")] string seatstr) {
            if (!string.IsNullOrEmpty(show)) {
                // define showtime info
                var movie = (from i in _context.ShowTimes where i.ID==uint.Parse(show) select i.MovieId).FirstOrDefault();
                var theater = (from i in _context.ShowTimes where i.ID==uint.Parse(show) select i.TheaterId).FirstOrDefault();
                var showtime = new ShowTime((from i in _context.ShowTimes where i.ID==uint.Parse(show) select i).FirstOrDefault(),
                    movie, 
                    theater);
                // find existing tickets and invalidate those seats
                var badseats = await (from i in _context.Tickets where i.ShowTimeId.ID==uint.Parse(show) select i.SeatNumber).ToListAsync();
                // generate seats
                byte[][] seats = null;
                if (!string.IsNullOrEmpty(seatstr)) {
                    var seatstrs = seatstr.Substring(1, seatstr.Length - 2).Split("|");
                    seats = new byte[seatstrs.Length][];
                    for(var i = 0; i < seats.Length; i++)
                        seats[i] = new byte[2] {Convert.ToByte(seatstrs[i].Split(",")[0]), Convert.ToByte(seatstrs[i].Split(",")[1])};
                }
                // retain ticket info for cuurent order-in-progress
                var ticketstrs = ticketstr.Split(',').ToList();
                /*var tickets = new List<uint>();
                foreach (string i in ticketstrs) {
                    tickets.Add(Convert.ToUInt32(i));
                }*/
                var tickets = new uint[3] {0, 0, 0};
                for(var i = 0; i < tickets.Length; i++)
                    tickets[i] = Convert.ToUInt32(ticketstrs.ToArray()[i]);
                // make readable for page
                var selector = new SeatSelector {
                    Show = showtime,
                    SeatsTaken = badseats,
                    Seats = seats,
                    Tickets = tickets,
                };
                selector.CanGo = selector.Available() == 0;
                return View(selector);
            }
            return NotFound();
        }
        /// CHECKOUT
        public async Task<IActionResult> Checkout([FromQuery (Name = "show")] string show, [FromQuery (Name = "tickets")] string ticketstr, [FromQuery (Name = "seats")] string seatstr, [FromQuery (Name = "promo")] string promocode) {
            // define showtime info
            var movie = (from i in _context.ShowTimes where i.ID==uint.Parse(show) select i.MovieId).FirstOrDefault();
            var theater = (from i in _context.ShowTimes where i.ID==uint.Parse(show) select i.TheaterId).FirstOrDefault();
            var showtime = new ShowTime((from i in _context.ShowTimes where i.ID==uint.Parse(show) select i).FirstOrDefault(),
                movie, 
                theater);
            // generate seats
            var seatstrs = seatstr.Substring(1, seatstr.Length - 2).Split("|");
            var seats = new byte[seatstrs.Length][];
            for(var i = 0; i < seats.Length; i++){
                seats[i] = new byte[2] {Convert.ToByte(seatstrs[i].Split(",")[0]), Convert.ToByte(seatstrs[i].Split(",")[1])};
            }
            // generate tickets
            var ttypes = await (from i in _context.TicketTypes select i).ToListAsync();
            var ticketstrs = ticketstr.Split(',').ToList();
            var ticketarr = new uint[3] {0, 0, 0};
            var tickets = new List<Ticket>();
            var k = 0;
            for(var i = 0; i < ticketarr.Length; i++) {
                ticketarr[i] = Convert.ToUInt32(ticketstrs.ToArray()[i]);
                for(var j = 0; j < ticketarr[i]; j++){
                    tickets.Add(new Ticket(showtime, seats[k], ttypes.ToArray()[i]));
                    k++;
                }
            }
            // make readable for page
            var order = new CineWeb.Models.Order {
                DateCreated = DateTime.Now,
                ShowTimeId = showtime,
                Tickets = tickets,
            };
            if(!string.IsNullOrEmpty(promocode)){
                var promo = (from i in _context.Promotions where i.Code==promocode select i).FirstOrDefault();
                if(promo != null)
                    order = AppliedPromo.NewPromo(order, promo);
            }
            return View(order);
        }
         [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            Stripe.StripeConfiguration.SetApiKey("Publishable key");
            Stripe.StripeConfiguration.ApiKey = "Secret key";

            var myCharge = new Stripe.ChargeCreateOptions();
            // always set these properties
            myCharge.Amount = 500;
            myCharge.Currency = "USD";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Sample Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutConfirm([Bind("ID,DateCreated,UserId,ShowTimeId,Tickets")] CineWeb.Models.Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home/Index");
            }
            return RedirectToAction("Order/Checkout", new {
                show = order.ShowTimeId.ID,
                tickets = order.TicketStr(),
                seats = order.SeatStr(),
            });
        }
    }
}
