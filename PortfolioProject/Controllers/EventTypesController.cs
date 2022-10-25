using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    [Authorize]
    public class EventTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Categories.ToListAsync());
        }

        // GET: EventTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var eventType = await _context.Categories
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        // GET: EventTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Category")] EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventType);
        }

        // GET: EventTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var eventType = await _context.Categories.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }
            return View(eventType);
        }

        // POST: EventTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Category")] EventType eventType)
        {
            if (id != eventType.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTypeExists(eventType.EventId))
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
            return View(eventType);
        }

        // GET: EventTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var eventType = await _context.Categories
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        // POST: EventTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var eventType = await _context.Categories.FindAsync(id);
            if (eventType != null)
            {
                _context.Categories.Remove(eventType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTypeExists(int id)
        {
          return _context.Categories.Any(e => e.EventId == id);
        }
    }
}