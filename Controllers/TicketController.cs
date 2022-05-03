using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineWeb.Data;
using CineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineWeb.Controllers
{
    // [Route("product")]
    public class TicketController : Controller
    {
        // [Route("")]
        // [Route("index")]
        // [Route("~/")]
        private readonly WebContext _context;

        public TicketController(WebContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShowTimeModel showModel = new ShowTimeModel();
            List<Ticket> availableTicket = new List<Ticket>();
            // ViewBag.showTickets = showModel.findAll();
            ViewBag.showTickets = new Ticket()
            {
                showTime = showModel.find(2),
                Row = Row.A,
                seatNumber = 4
                
            };

            return View();
        }
        // public IActionResult Book()
        // {
        //     return View();
        // }
        /*public int ID { get; set; }
        public CineWebUser? User { get; set; }
        public ShowTime showTime { get; set; }
        [Range(1, 12)]
        public int seatNumber { get; set; }
        public Row Row { get; set; } //Number of rows. So seat 1-10 = row 1, seats 11-20 = row 2
        public double price { get; set; }*/

        // [HttpPost]
        // public async Task<IActionResult> Book(ShowTime show, Row row, int seat)
        // {
        //     ShowTimeModel showsModel = new ShowTimeModel();
        //      if (Session["Book"] == null)
        //     {
        //         List<Ticket> bookTicket = new List<Ticket>();
        //         bookTicket.Add(new Ticket(show, row, seat));
        //         Session["Book"] = bookTicket;
        //     }
        //     return View("Index");
        // }

        // private int isExist(string id)
        // {
        //     List<Item> cart = (List<Item>)Session["cart"];
        //     for (int i = 0; i < cart.Count; i++)
        //         if (cart[i].Product.Id.Equals(id))
        //             return i;
        //     return -1;
        // }
    }
}