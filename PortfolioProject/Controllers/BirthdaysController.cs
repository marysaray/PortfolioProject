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
    /// <summary>
    /// The controller for the birthday page.
    /// </summary>
    public class BirthdaysController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;

        // constructor injection: inject services
        public BirthdaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Birthdays
        /// <summary>
        /// Displays a view of all birthdays.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
              return View(await _context.Birthdays.ToListAsync());
        }

        // GET: Birthdays/Details/5
        /// <summary>
        /// Displays data associated to the specific id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Birthdays == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthdays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birthday == null)
            {
                return NotFound();
            }

            return View(birthday);
        }

        // GET: Birthdays/Create
        /// <summary>
        /// Create a new upload.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Birthdays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date")] Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birthday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birthday);
        }

        // GET: Birthdays/Edit/5
        /// <summary>
        /// Edit a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Birthdays == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthdays.FindAsync(id);
            if (birthday == null)
            {
                return NotFound();
            }
            return View(birthday);
        }

        // POST: Birthdays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update and save event to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date")] Birthday birthday)
        {
            if (id != birthday.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birthday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirthdayExists(birthday.Id))
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
            return View(birthday);
        }

        // GET: Birthdays/Delete/5
        /// <summary>
        /// Delete a specific event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Birthdays == null)
            {
                return NotFound();
            }

            var birthday = await _context.Birthdays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birthday == null)
            {
                return NotFound();
            }

            return View(birthday);
        }

        // POST: Birthdays/Delete/5
        /// <summary>
        /// Update database after event deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Birthdays == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Birthdays'  is null.");
            }
            var birthday = await _context.Birthdays.FindAsync(id);
            if (birthday != null)
            {
                _context.Birthdays.Remove(birthday);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool BirthdayExists(int id)
        {
          return _context.Birthdays.Any(e => e.Id == id);
        }
    }
}