/* using CineWeb.Areas.Identity.Services;
using CineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CineWeb.Controllers
{
    // [Route("cart")]
    public class CartController : Controller
    {
        // [Route("index")]
        public async Task<IActionResult> Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(Order => Order.Tickets.calcPrice());
            return View();
        }

        // [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
            TicketModel tickets = new TicketModel();
            if (SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart") == null)
            {
                List<Order> cart = new List<Order>();
                cart.Add(new Order { movieTicket = tickets.find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Order { movieTicket = tickets.find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        // [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Order> cart = SessionHelper.GetObjectFromJson<List<Order>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].movieTicket.ID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
} */
using CineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Stripe;


namespace CineWeb.Controllers
{
    public class CartController : Controller
    {
        public ActionResult OrderStatus()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
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
    }
}