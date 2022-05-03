using CineWeb.Data;
using CineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly WebContext _context;

        public TicketController(WebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ticketModel = new Ticket();
            //ViewBag.tickets = ticketModel.findAll();
            return View(await _context.Tickets.ToListAsync());
        }
    }
}