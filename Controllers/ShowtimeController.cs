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
    public class ShowtimeController : Controller
    {
        private readonly WebContext _context;

        public ShowtimeController(WebContext context)
        {
            _context = context;
        }

        // GET: showtime
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.ShowTimes.ToListAsync());
        }

        // GET: Showtime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showtime = await _context.ShowTimes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (showtime == null)
            {
                return NotFound();
            }

            return View(showtime);
        }

        // GET: Showtime/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Showtime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TimeStart,TimeEnd,Movies,Theaters")] ShowTime showtime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showtime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showtime);
        }

        // GET: Showtime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showtime = await _context.ShowTimes.FindAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }
            return View(showtime);
        }

        // POST: Showtime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TimeStart,TimeEnd,Movies,Theaters")] ShowTime showtime)
        {
            if (id != showtime.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showtime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowtimeExists(showtime.ID))
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
            return View(showtime);
        }

        // GET: Showtime/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showtime = await _context.ShowTimes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (showtime == null)
            {
                return NotFound();
            }

            return View(showtime);
        }

        // POST: Showtime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showtime = await _context.ShowTimes.FindAsync(id);
            _context.ShowTimes.Remove(showtime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowtimeExists(int id)
        {
            return _context.ShowTimes.Any(e => e.ID == id);
        }
    }
}
