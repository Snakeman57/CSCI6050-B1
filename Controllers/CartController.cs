// using CineWeb.Data;
// using CineWeb.Models;
// using Microsoft.AspNetCore.Mvc;


// namespace CineWeb.Controllers
// {
//     public class CartController : IDisposable
//     {
//         private WebContext _context;
//         public string ShopCartID { get; set; }
//         private readonly IHttpContextAccessor _contextSession;
//         public const string CartSessionKey = "CartID";


//         public CartController(WebContext context, IHttpContextAccessor contextSession)
//         {
//             _context = context;
//             _contextSession = contextSession;
//         }

//         public void AddToCart(int id)
//         {
//             // Retrieve the product from the database.           
//             // ShopCartID = GetCartId();

//             var cartItem = _context.CartItems.SingleOrDefault(
//                 c => c.CartID == ShopCartID
//                 && c.TicketID == id);
//             if (cartItem == null)
//             {
//                 // Create a new cart item if no cart item exists.                 
//                 cartItem = new Cart
//                 {
//                     ItemID = Guid.NewGuid().ToString(),
//                     TicketID = id,
//                     CartID = ShopCartID,
//                     movieTicket = _context.Ticket.SingleOrDefault(
//                    p => p.ID == id),
//                     Quantity = 1,
//                     DateCreated = DateTime.Now
//                 };

//                 _context.CartItems.Add(cartItem);
//             }
//             else
//             {
//                 // If the item does exist in the cart,                  
//                 // then add one to the quantity.                 
//                 cartItem.Quantity++;
//             }
//             _context.SaveChanges();
//         }

//         public void Dispose()
//         {
//             if (_context != null)
//             {
//                 _context.Dispose();
//                 _context = null;
//             }
//         }

//         // public string GetCartId()
//         // {
//         //     if (_contextSession.HttpContext.Session == null)
//         //     {
//         //         if (!string.IsNullOrWhiteSpace(_contextSession.HttpContext.User.Identity.Name))
//         //         {
//         //             (_contextSession.HttpContext.(CartSessionKey) )= _contextSession.HttpContext.User.Identity.Name;
//         //         }
//         //         else
//         //         {
//         //             // Generate a new random GUID using System.Guid class.     
//         //             Guid tempCartId = Guid.NewGuid();
//         //             HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
//         //         }
//         //     }
//         //     return HttpContext.Current.Session[CartSessionKey].ToString();
//         // }

//         public List<Cart> GetCartItems()
//         {
//             // ShopCartID = GetCartId();

//             return _context.CartItems.Where(
//                 c => c.CartID == ShopCartID).ToList();
//         }
//     }
// }
using CineWeb.Areas.Identity.Services;
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
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.movieTicket.price * item.Quantity);
            return View();
        }

        // [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
            TicketModel tickets = new TicketModel();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { movieTicket = tickets.find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { movieTicket = tickets.find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        // [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
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
}