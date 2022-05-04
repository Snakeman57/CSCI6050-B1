using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CineWeb.Data;
using CineWeb.Models;

namespace CineWeb.Controllers
{
    public class PromoController : Controller
    {
        private readonly WebContext _context;

        public PromoController(WebContext context)
        {
            _context = context;
        }

        // GET: Promo
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoviePromotion.ToListAsync());
        }

        // GET: Promo/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePromotion = await _context.MoviePromotion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePromotion == null)
            {
                return NotFound();
            }

            return View(moviePromotion);
        }

        // GET: Promo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Promotion,PromoCode,PromoDeal")] MoviePromotion moviePromotion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviePromotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moviePromotion);
        }

        // GET: Promo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePromotion = await _context.MoviePromotion.FindAsync(id);
            if (moviePromotion == null)
            {
                return NotFound();
            }
            return View(moviePromotion);
        }

        // POST: Promo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Promotion,PromoCode,PromoDeal")] MoviePromotion moviePromotion)
        {
            if (id != moviePromotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviePromotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviePromotionExists(moviePromotion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(moviePromotion);
        }

        // GET: Promo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePromotion = await _context.MoviePromotion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePromotion == null)
            {
                return NotFound();
            }

            return View(moviePromotion);
        }

        // POST: Promo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviePromotion = await _context.MoviePromotion.FindAsync(id);
            _context.MoviePromotion.Remove(moviePromotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviePromotionExists(int id)
        {
            return _context.MoviePromotion.Any(e => e.Id == id);
        }
    }
}
