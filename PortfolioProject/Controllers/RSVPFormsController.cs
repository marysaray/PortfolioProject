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
    public class RSVPFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSVPFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RSVPForms
        public async Task<IActionResult> Index()
        {
              return View(await _context.RSVPForms.ToListAsync());
        }

        // GET: RSVPForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RSVPForms == null)
            {
                return NotFound();
            }

            var rSVPForm = await _context.RSVPForms
                .FirstOrDefaultAsync(m => m.RSVPId == id);
            if (rSVPForm == null)
            {
                return NotFound();
            }

            return View(rSVPForm);
        }

        // GET: RSVPForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RSVPForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RSVPId,FirstName,LastName,ConfirmedEmail,RSVPResponse,DateSubmitted")] RSVPForm rSVPForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rSVPForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rSVPForm);
        }

        // GET: RSVPForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RSVPForms == null)
            {
                return NotFound();
            }

            var rSVPForm = await _context.RSVPForms.FindAsync(id);
            if (rSVPForm == null)
            {
                return NotFound();
            }
            return View(rSVPForm);
        }

        // POST: RSVPForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RSVPId,FirstName,LastName,ConfirmedEmail,RSVPResponse,DateSubmitted")] RSVPForm rSVPForm)
        {
            if (id != rSVPForm.RSVPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rSVPForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RSVPFormExists(rSVPForm.RSVPId))
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
            return View(rSVPForm);
        }

        // GET: RSVPForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RSVPForms == null)
            {
                return NotFound();
            }

            var rSVPForm = await _context.RSVPForms
                .FirstOrDefaultAsync(m => m.RSVPId == id);
            if (rSVPForm == null)
            {
                return NotFound();
            }

            return View(rSVPForm);
        }

        // POST: RSVPForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RSVPForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RSVPForms'  is null.");
            }
            var rSVPForm = await _context.RSVPForms.FindAsync(id);
            if (rSVPForm != null)
            {
                _context.RSVPForms.Remove(rSVPForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RSVPFormExists(int id)
        {
          return _context.RSVPForms.Any(e => e.RSVPId == id);
        }
    }
}
