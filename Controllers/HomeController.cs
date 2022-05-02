using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineWeb.Models;
using CineWeb.Data;

namespace CineWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly WebContext _context;
    public string ShopCartID { get; set; }


    public HomeController(ILogger<HomeController> logger, WebContext webContext)
    {
        _logger = logger;
        _context = webContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Book()
    {
        return View();
    }
    // [HttpPost]
    // public async Task<IActionResult> Book(int id)

    // {

    //     var cartItem = _context.CartItems.SingleOrDefault(
    //             c => c.CartID == ShopCartID
    //             && c.TicketID == id);
    //     if (cartItem == null)
    //     {
    //         // Create a new cart item if no cart item exists.                 
    //         cartItem = new Cart
    //         {
    //             ItemID = Guid.NewGuid().ToString(),
    //             TicketID = id,
    //             CartID = ShopCartID,
    //             movieTicket = _context.Ticket.SingleOrDefault(
    //            p => p.ID == id),
    //             Quantity = 1,
    //             DateCreated = DateTime.Now
    //         };

    //         _context.CartItems.Add(cartItem);
    //     }
    //     else
    //     {
    //         // If the item does exist in the cart,                  
    //         // then add one to the quantity.                 
    //         cartItem.Quantity++;
    //     }
    //     _context.SaveChanges();
    //     return View();
    // }
    // public List<Cart> GetCartItems()
    // {
    //     // ShopCartID = GetCartId();

    //     return _context.CartItems.Where(
    //         c => c.CartID == ShopCartID).ToList();
    // }

}
