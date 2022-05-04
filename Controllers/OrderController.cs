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
            var movies = from i in _context.Movies where i.NowShowing==true select i.Title; //movie to look for showing content
            var showtimes = from i in _context.ShowTimes select i;      // showtime select from context
            if (!string.IsNullOrEmpty(movie)) {
                var id = from i in _context.Movies where i.Title==movie select i.ID;
                foreach (uint i in id)
                    showtimes = showtimes.Where(x => x.MovieId.ID == i);
            }
            else {
                showtimes = showtimes.Where(x => false);
            }
            //var ttypes = from i in _context.TicketType select i;
            var stVM = new stView {
                films = new SelectList(await movies.ToListAsync()),
                shows = await showtimes.ToListAsync(),
                //tickets = await ttypes.ToListAsync()
            };
            return View(stVM);
        }
    }
}
