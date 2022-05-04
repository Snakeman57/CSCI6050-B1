using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineWeb.Data;
using CineWeb.Helpers;
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



        public IActionResult Index()
        {
            ShowTimeModel showModel = new ShowTimeModel();
            List<Ticket> availableTicket = new List<Ticket>();
            for (int i = 1; i <= 10; i++)
            {
                string name = "Ticket" + i.ToString();
                availableTicket.Add(
                    new Ticket()
                    {
                        Id = i,
                        showTime = showModel.find(1),
                        Row = Row.A,
                        seatNumber = i,
                        Price = 14.00
                    }
                    );
            }
            ViewBag.showTickets = availableTicket;
            var cart = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "ticket");
            return View();
        }



        public IActionResult Cart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "ticket");
            // ViewBag.showCart = cart;
            // ViewBag.total = cart.Sum(item => item.Price.Value);
            return View();
        }




        [HttpPost]
        public IActionResult Buy(ShowTime show, Row row, int seat, double price)
        {
            ShowTimeModel showTimeModel = new ShowTimeModel();

            if (SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "ticket") == null)
            {
                List<Ticket> cart = new List<Ticket>();
                ViewBag.showCart = cart;
                cart.Add(new Ticket()
                {   Id = 1,
                    showTime = show,
                    Row = row,
                    seatNumber = seat,
                    Price = price
                }
                );
               

                SessionHelper.SetObjectAsJson(HttpContext.Session, "ticket", cart);
            }

            return RedirectToPage("Cart");
        }

    }

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