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
    public class RSVPResponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSVPResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RSVPResponses
        public async Task<IActionResult> Index()
        {
              return View(await _context.RSVPResponses.ToListAsync());
        }

        // GET: RSVPResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RSVPResponses == null)
            {
                return NotFound();
            }

            var rSVPResponse = await _context.RSVPResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rSVPResponse == null)
            {
                return NotFound();
            }

            return View(rSVPResponse);
        }

        // GET: RSVPResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RSVPResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RSVPType")] RSVPResponse rSVPResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rSVPResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rSVPResponse);
        }

        // GET: RSVPResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RSVPResponses == null)
            {
                return NotFound();
            }

            var rSVPResponse = await _context.RSVPResponses.FindAsync(id);
            if (rSVPResponse == null)
            {
                return NotFound();
            }
            return View(rSVPResponse);
        }

        // POST: RSVPResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RSVPType")] RSVPResponse rSVPResponse)
        {
            if (id != rSVPResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rSVPResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RSVPResponseExists(rSVPResponse.Id))
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
            return View(rSVPResponse);
        }

        // GET: RSVPResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RSVPResponses == null)
            {
                return NotFound();
            }

            var rSVPResponse = await _context.RSVPResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rSVPResponse == null)
            {
                return NotFound();
            }

            return View(rSVPResponse);
        }

        // POST: RSVPResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RSVPResponses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RSVPResponses'  is null.");
            }
            var rSVPResponse = await _context.RSVPResponses.FindAsync(id);
            if (rSVPResponse != null)
            {
                _context.RSVPResponses.Remove(rSVPResponse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RSVPResponseExists(int id)
        {
          return _context.RSVPResponses.Any(e => e.Id == id);
        }
    }
}
