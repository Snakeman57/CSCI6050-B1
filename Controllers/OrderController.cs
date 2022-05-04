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
        public async Task<IActionResult> Index(string movie) {
            var movies = from i in _context.Movies where i.NowShowing==true select i.Title; // collect currently available movies
            var showtimes = from i in _context.ShowTimes where i.TimeStart>DateTime.Now select i; // collect upcoming showtimes
            if (!string.IsNullOrEmpty(movie)) { // if movie is selected, filter show times
                var id = from i in _context.Movies where i.Title==movie select i.ID;
                foreach (uint i in id)
                    showtimes = showtimes.Where(x => x.MovieId.ID == i);
            }
            else { // if movie is not selected, showtimes unavailable
                showtimes = showtimes.Where(x => false);
            }
            var sttmp = await showtimes.ToListAsync(); // begin conversion of showtimes to datetimes
            var sttimes = from i in _context.ShowTimes where sttmp.Contains(i) select i.TimeStart; // end conversion of showtimes to datetimes
            var ttypes = from i in _context.TicketTypes select i; // collect ticket types
            var stVM = new stView {
                films = new SelectList(await movies.ToListAsync()),
                shows = new SelectList(await sttimes.ToListAsync()),
                tickets = await ttypes.ToListAsync()
            };
            return View(stVM);
        }
    }
}
