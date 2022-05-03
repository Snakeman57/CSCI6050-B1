// using CineWeb.Data;
// using CineWeb.Helpers;
// using CineWeb.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace CineWeb.Controllers
// {
//     // [Route("cart")]
//     public class CartController : Controller
//     {
//         private readonly WebContext _context;
//         private readonly Ticket _ticket;


//         public CartController(WebContext context, Ticket ticket)
//         {
//             _context = context;
//             _ticket = ticket;

//         }
//         // [Route("index")]
//         public async Task<IActionResult> Index()
//         {
//             var cart = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "cart");
//             ViewBag.cart = cart;
//             ViewBag.total = cart.Sum(item => item.Price.Value);
//             return View(await _context.Ticket.ToListAsync());
//         }

//         // [Route("buy/{id}")]
//         public async Task<IActionResult> Buy(ShowTime show, Row row, int seat, double price)
//         {
//             ShowTimeModel showTimeModel = new ShowTimeModel();

//             if (SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "cart") == null)
//             {
//                 List<Ticket> cart = new List<Ticket>();

//                 cart.Add(new Ticket()
//                 {
//                     showTime = show,
//                     Row = row,
//                     seatNumber = seat,
//                     Price = price
//                 }
//                 );
//                 if (ModelState.IsValid)
//                 {
//                     _context.Add(cart);
//                     await _context.SaveChangesAsync();
//                     return RedirectToAction(nameof(Index));
//                 }

//                 SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//             }
//             // else
//             // {
//             //     List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
//             //     int index = isExist(id);
//             //     if (index != -1)
//             //     {
//             //         cart[index].Quantity++;
//             //     }
//             //     else
//             //     {
//             //         cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
//             //     }
//             //     SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//             // }
//             return RedirectToAction("Index");
//         }

//         // [Route("remove/{id}")]
//         public IActionResult Remove(ShowTime show, Row row, int id, double price)
//         {
//             List<Ticket> cart = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "cart");
//             int index = isExist(show, row, id, price);
//             cart.RemoveAt(index);
//             SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
//             return RedirectToAction("Index");
//         }

//         private int isExist(ShowTime show, Row row, int id, double price)
//         {
//             List<Ticket> cart = SessionHelper.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "cart");
//             for (int i = 0; i < cart.Count; i++)
//             {
//                 if (cart[i].seatNumber.Equals(id) && cart[i].Row.Equals(row))
//                 {
//                     return i;
//                 }
//             }
//             return -1;
//         }

//     }
// }