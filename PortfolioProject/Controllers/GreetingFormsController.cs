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
    /// The controller for the greeting form page.
    /// </summary>
    public class GreetingFormsController : Controller
    {
        // field
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        // constructor injection: inject services
        public GreetingFormsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: GreetingForms
        /// <summary>
        /// Displays a view of all greetings.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(GreetingIndexViewModel viewModel)
        {
            List<GreetingIndexViewModel> greetingData =
                await (from gd in _context.GreetingForms
                       orderby gd.GreetingId descending
                       select new GreetingIndexViewModel
                       {
                           GreetingId = gd.GreetingId,
                           GreetingType = gd.GreetingType,
                           Message = gd.Message,
                           Photo = gd.PhotoUrl
                       }).ToListAsync();

            return View(greetingData);
        }

        // GET: GreetingForms/Details/5
        /// <summary>
        /// Displays data associated to the specific greeting id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Create a new greeting form.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Add and save to database after validation.
        /// </summary>
        /// <param name="greeting"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GreetingCreateViewModel greeting)
        {
            // Create unique file name for uploading images.
            string fileName = Guid.NewGuid().ToString();
            fileName += fileName + Path.GetExtension(greeting.UploadFile.FileName);

            // Save file to file system
            string uploadPath = Path.Combine(_environment.WebRootPath, "images", fileName);

            // Create permission [using] keyword calls and dispose automatically.
            using Stream fileStream = new FileStream(uploadPath, FileMode.Create);

            // Copy file 
            await greeting.UploadFile.CopyToAsync(fileStream);

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
                    PhotoUrl = fileName
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
        /// <summary>
        /// Edit a specific greeting.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update and save greeting to database after validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="greetingForm"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete a specific greeting.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update database after greeting deletion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validation if content exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool GreetingFormExists(int id)
        {
          return _context.GreetingForms.Any(e => e.GreetingId == id);
        }
    }
}