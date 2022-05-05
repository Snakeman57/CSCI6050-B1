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
        public async Task<IActionResult> Index(string movie, string show, params uint[] tickets) {
            uint tleft = 0; // might drop this
            // collect currently available movies
            var movies = from i in _context.Movies where i.NowShowing==true select i.Title;
            // collect upcoming showtimes
            var showtimes = from i in _context.ShowTimes where i.TimeStart > DateTime.Now select i;
            if (!string.IsNullOrEmpty(movie)) // if movie is selected, filter show times
                showtimes = showtimes.Where(x => x.MovieId == (from i in _context.Movies where i.Title==movie select i).FirstOrDefault());
            else // if movie is not selected, showtimes unavailable
                showtimes = showtimes.Where(x => false);
            var stlist = await showtimes.ToListAsync(); // begin conversion of showtimes to datetimes
            var sttimes = from i in _context.ShowTimes where stlist.Contains(i) select i.TimeStart; // end conversion of showtimes to datetimes
            // collect ticket types
            var ttypes = await (from i in _context.TicketTypes select i).ToListAsync();
            // store selected showtime
            string showtime = string.IsNullOrEmpty(show) ? null : (showtimes.Where(x => x.TimeStart==Convert.ToDateTime(show))).FirstOrDefault()?.ID.ToString();
            // store selected tickets
            var ticketstr = "";
            if (tickets.Length > 0){
                foreach (uint i in tickets)
                    ticketstr += i + ",";
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
                films = new SelectList(await movies.ToListAsync()),
                shows = new SelectList(await sttimes.ToListAsync()),
                ttypes = ttypes,
                tleft = tleft,
                show = showtime,
                tickets = ticketstr,
                canGo = !string.IsNullOrEmpty(showtime),
            };
            return View(selector);
        }
        /// SEAT SELECTION
        public async Task<IActionResult> SelSeat([FromQuery (Name = "show")] string show, [FromQuery (Name = "tickets")] string ticketstr, params byte[][] seats) {
            if (!string.IsNullOrEmpty(show)) {
                // define showtime info
                var movie = (from i in _context.ShowTimes where i.ID==uint.Parse(show) select i.MovieId).FirstOrDefault();
                var theater = (from i in _context.ShowTimes where i.ID==uint.Parse(show) select i.TheaterId).FirstOrDefault();
                var showtime = new ShowTime((from i in _context.ShowTimes where i.ID==uint.Parse(show) select i).FirstOrDefault(),
                    movie, 
                    theater);
                // find existing tickets and invalidate those seats
                var badseats = await (from i in _context.Tickets where i.ShowTimeId==uint.Parse(show) select i.SeatNumber).ToListAsync();
                // retain ticket info for cuurent order-in-progress
                var ticketstrs = ticketstr.Split(',').ToList();
                var tickets = new List<uint>();
                foreach (string i in ticketstrs) {
                    tickets.Add(Convert.ToUInt32(i));
                }
                // make readable for page
                var selector = new SeatSelector {
                    Show = showtime,
                    SeatsTaken = badseats,
                    Seats = seats,
                    Tickets = tickets.ToArray(),
                };
                return View(selector);
            }
            return NotFound();
        }
    }
}
