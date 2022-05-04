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
        public async Task<IActionResult> Index() {
            var movies = from i in _context.Movies select i;
            movies = movies.Where(x => x.NowShowing == true);
            var showtimes = from i in _context.ShowTimes select i;
            var stVM = new stView {
                films = new SelectList(await movies.Distinct().ToListAsync()),
                shows = await showtimes.ToListAsync()
            };
            return View(stVM);
        }
    }
}
