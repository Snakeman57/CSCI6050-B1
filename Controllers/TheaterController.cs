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
    public class TheaterController : Controller
    {
        private readonly WebContext _context;

        public TheaterController(WebContext context)
        {
            _context = context;
        }

        // GET: Theater
        public async Task<IActionResult> Index()
        {
            return View(await _context.Theaters.ToListAsync());
        }

        // GET: Theater/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.Theaters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

        // GET: Theater/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Theater/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,TheaterCapacity,Row")] Theater theater)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theater);
        }

        // GET: Theater/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.Theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }
            return View(theater);
        }

        // POST: Theater/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,TheaterCapacity,Row")] Theater theater)
        {
            if (id != theater.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheaterExists(theater.ID))
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
            return View(theater);
        }

        // GET: Theater/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.Theaters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

        // POST: Theater/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);
            _context.Theaters.Remove(theater);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheaterExists(int id)
        {
            return _context.Theaters.Any(e => e.ID == id);
        }
    }
}
