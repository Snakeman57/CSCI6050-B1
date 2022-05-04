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
        // start new order
        public async Task<IActionResult> Index(string movie, string show) {
            string showtime = null;
            var movies = from i in _context.Movies where i.NowShowing==true select i.Title; // collect currently available movies
            var showtimes = from i in _context.ShowTimes where i.TimeStart>DateTime.Now select i; // collect upcoming showtimes
            if (!string.IsNullOrEmpty(movie)) { // if movie is selected, filter show times
                var id = from i in _context.Movies where i.Title==movie select i;
                foreach (Movie i in id)
                    showtimes = showtimes.Where(x => x.MovieId == i);
            }
            else // if movie is not selected, showtimes unavailable
                showtimes = showtimes.Where(x => false);
            if (!string.IsNullOrEmpty(show)) {
                var id = showtimes.Where(x => x.TimeStart==Convert.ToDateTime(show));
                foreach (ShowTime i in id)
                    showtime = i.ID.ToString();
            }
            var stlist = await showtimes.ToListAsync(); // begin conversion of showtimes to datetimes
            var sttimes = from i in _context.ShowTimes where stlist.Contains(i) select i.TimeStart; // end conversion of showtimes to datetimes
            var ttypes = from i in _context.TicketTypes select i; // collect ticket types
            var selector = new ShowSelector {
                films = new SelectList(await movies.ToListAsync()),
                shows = new SelectList(await sttimes.ToListAsync()),
                ttypes = await ttypes.ToListAsync(),
                show = showtime,
                canGo = !string.IsNullOrEmpty(showtime),
            };
            return View(selector);
        }
        [Route("Order/{show}")]
        public async Task<IActionResult> SelSeat(string show){
            if (!string.IsNullOrEmpty(show)) {
                ShowTime showtime = null;
                var showtimes = from i in _context.ShowTimes where i.ID==uint.Parse(show) select i;
                foreach (ShowTime i in showtimes)
                    showtime = i;
                var seats = from i in _context.Tickets where i.ShowTimeId==showtime.ID select i.SeatNumber;
                var selector = new SeatSelector {
                    Show = showtime,
                    SeatsTaken = await seats.ToListAsync()
                };
                return View(selector);
            }
            return NotFound();
        }
    }
}
