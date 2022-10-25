using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Data;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class GetTogethersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetTogethersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GetTogethers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Events.ToListAsync());
        }

        // GET: GetTogethers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var getTogether = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getTogether == null)
            {
                return NotFound();
            }

            return View(getTogether);
        }

        // GET: GetTogethers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetTogethers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Place,Date")] GetTogether getTogether)
        {
            if (ModelState.IsValid)
            {
                _context.Add(getTogether);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(getTogether);
        }

        // GET: GetTogethers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var getTogether = await _context.Events.FindAsync(id);
            if (getTogether == null)
            {
                return NotFound();
            }
            return View(getTogether);
        }

        // POST: GetTogethers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Place,Date")] GetTogether getTogether)
        {
            if (id != getTogether.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(getTogether);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GetTogetherExists(getTogether.Id))
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
            return View(getTogether);
        }

        // GET: GetTogethers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var getTogether = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getTogether == null)
            {
                return NotFound();
            }

            return View(getTogether);
        }

        // POST: GetTogethers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Events'  is null.");
            }
            var getTogether = await _context.Events.FindAsync(id);
            if (getTogether != null)
            {
                _context.Events.Remove(getTogether);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GetTogetherExists(int id)
        {
          return _context.Events.Any(e => e.Id == id);
        }
    }
}