﻿using System;
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
    public class EventFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventForms
        public async Task<IActionResult> Index()
        {
              return View(await _context.EventForms.ToListAsync());
        }

        // GET: EventForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventForms == null)
            {
                return NotFound();
            }

            var eventForm = await _context.EventForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventForm == null)
            {
                return NotFound();
            }

            return View(eventForm);
        }

        // GET: EventForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventTitle")] EventForm eventForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventForm);
        }

        // GET: EventForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventForms == null)
            {
                return NotFound();
            }

            var eventForm = await _context.EventForms.FindAsync(id);
            if (eventForm == null)
            {
                return NotFound();
            }
            return View(eventForm);
        }

        // POST: EventForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventTitle")] EventForm eventForm)
        {
            if (id != eventForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventFormExists(eventForm.Id))
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
            return View(eventForm);
        }

        // GET: EventForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventForms == null)
            {
                return NotFound();
            }

            var eventForm = await _context.EventForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventForm == null)
            {
                return NotFound();
            }

            return View(eventForm);
        }

        // POST: EventForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EventForms'  is null.");
            }
            var eventForm = await _context.EventForms.FindAsync(id);
            if (eventForm != null)
            {
                _context.EventForms.Remove(eventForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventFormExists(int id)
        {
          return _context.EventForms.Any(e => e.Id == id);
        }
    }
}