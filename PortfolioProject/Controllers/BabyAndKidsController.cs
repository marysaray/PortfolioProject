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
    public class BabyAndKidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BabyAndKidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BabyAndKids
        public async Task<IActionResult> Index()
        {
              return View(await _context.BabyAndKids.ToListAsync());
        }

        // GET: BabyAndKids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BabyAndKids == null)
            {
                return NotFound();
            }

            var babyAndKids = await _context.BabyAndKids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (babyAndKids == null)
            {
                return NotFound();
            }

            return View(babyAndKids);
        }

        // GET: BabyAndKids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BabyAndKids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BabyAndKids babyAndKids)
        {
            if (ModelState.IsValid)
            {
                _context.Add(babyAndKids);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(babyAndKids);
        }

        // GET: BabyAndKids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BabyAndKids == null)
            {
                return NotFound();
            }

            var babyAndKids = await _context.BabyAndKids.FindAsync(id);
            if (babyAndKids == null)
            {
                return NotFound();
            }
            return View(babyAndKids);
        }

        // POST: BabyAndKids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BabyAndKids babyAndKids)
        {
            if (id != babyAndKids.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(babyAndKids);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BabyAndKidsExists(babyAndKids.Id))
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
            return View(babyAndKids);
        }

        // GET: BabyAndKids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BabyAndKids == null)
            {
                return NotFound();
            }

            var babyAndKids = await _context.BabyAndKids
                .FirstOrDefaultAsync(m => m.Id == id);
            if (babyAndKids == null)
            {
                return NotFound();
            }

            return View(babyAndKids);
        }

        // POST: BabyAndKids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BabyAndKids == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BabyAndKids'  is null.");
            }
            var babyAndKids = await _context.BabyAndKids.FindAsync(id);
            if (babyAndKids != null)
            {
                _context.BabyAndKids.Remove(babyAndKids);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BabyAndKidsExists(int id)
        {
          return _context.BabyAndKids.Any(e => e.Id == id);
        }
    }
}
