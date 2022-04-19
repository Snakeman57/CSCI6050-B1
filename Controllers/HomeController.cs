using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using CineWeb.Data;

namespace CineWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
      private readonly WebContext _context;

    public HomeController(ILogger<HomeController> logger, WebContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index() //string movieCategory,string searchString
    {
        //  // Use LINQ to get list of Category.
        //     IQueryable<string> categoryQuery = from m in _context.Movies
        //                                     orderby m.Category
        //                                     select m.Category;
        //     var movies = from m in _context.Movies
        //                  select m;

        //     if (!string.IsNullOrEmpty(searchString))
        //     {
        //         movies = movies.Where(s => s.Title!.Contains(searchString));
        //     }

        //     if (!string.IsNullOrEmpty(movieCategory))
        //     {
        //         movies = movies.Where(x => x.Category == movieCategory);
        //     }

        //     var movieCategoryVM = new MovieCategoryView
        //     {
        //         Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
        //         Movies = await movies.ToListAsync()
        //     };

        //     return View(movieCategoryVM);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
