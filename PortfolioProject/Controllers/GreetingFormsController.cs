﻿using System;
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
    public class GreetingFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GreetingFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GreetingForms
        public async Task<IActionResult> Index()
        {
              return View(await _context.GreetingForms.ToListAsync());
        }

        // GET: GreetingForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GreetingForms == null)
            {
                return NotFound();
            }

            var greetingForm = await _context.GreetingForms
                .FirstOrDefaultAsync(m => m.GreetingId == id);
            if (greetingForm == null)
            {
                return NotFound();
            }

            return View(greetingForm);
        }

        // GET: GreetingForms/Create
        public IActionResult Create()
        {
            // Pass in a list of Greeting Types to get right away
            GreetingCreateViewModel viewModel = new GreetingCreateViewModel();

            // Get all greetings from the database and sort by id
            viewModel.AllGreetings = _context.GreetingTypes.OrderBy(g => g.GreetingId).ToList();

            // pass in the view mdodel
            return View(viewModel);
        }

        // POST: GreetingForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GreetingCreateViewModel greeting)
        {
            if (ModelState.IsValid)
            {
                // Map greeting type
                GreetingForm newGreeting = new()
                {
                    GreetingType = new GreetingType()
                    {
                        GreetingId = greeting.ChosenGreeting
                    },
                    Message = greeting.Message,
                };

                // Mark greeting unmodified for EF functionality
                _context.Entry(newGreeting.GreetingType).State = EntityState.Unchanged;

                _context.Add(newGreeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Add greetings back into the view model
            greeting.AllGreetings = _context.GreetingTypes.OrderBy(g => g.GreetingId).ToList().ToList();
            return View(greeting);
        }

        // GET: GreetingForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GreetingForms == null)
            {
                return NotFound();
            }

            var greetingForm = await _context.GreetingForms.FindAsync(id);
            if (greetingForm == null)
            {
                return NotFound();
            }
            return View(greetingForm);
        }

        // POST: GreetingForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GreetingId,Message")] GreetingForm greetingForm)
        {
            if (id != greetingForm.GreetingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(greetingForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GreetingFormExists(greetingForm.GreetingId))
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
            return View(greetingForm);
        }

        // GET: GreetingForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GreetingForms == null)
            {
                return NotFound();
            }

            var greetingForm = await _context.GreetingForms
                .FirstOrDefaultAsync(m => m.GreetingId == id);
            if (greetingForm == null)
            {
                return NotFound();
            }

            return View(greetingForm);
        }

        // POST: GreetingForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GreetingForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GreetingForms'  is null.");
            }
            var greetingForm = await _context.GreetingForms.FindAsync(id);
            if (greetingForm != null)
            {
                _context.GreetingForms.Remove(greetingForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GreetingFormExists(int id)
        {
          return _context.GreetingForms.Any(e => e.GreetingId == id);
        }
    }
}