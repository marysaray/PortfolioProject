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
    public class EventFormsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EventFormsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: EventForms OFFSET & FETCH https://www.essentialsql.com/using-offset-and-fetch-with-the-order-by-clause/
        public async Task<IActionResult> Index(EventFormsIndexViewModel viewModel, int? id)
        {
            // Make list flexible
            const int NumEventsToDisplayPerPage = 3;
            // Offset to use current page to figure out # of events to skip
            const int PageOffset = 1;
            // Get current page 
            /*
                if (id.HasValue)
                {
                    currPage = id.Value;
                }
                else
                {
                    currPage = 1;
                }
            */
            // int currPage = id.HasValue ? id.Value : 1;
            int currPage = id ?? 1; // lightbulb --> coalesce expression: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
            // Total number of events out of the database
            int totalNumOfEvents = await _context.EventForms.CountAsync();
            // Round events up for items to be displayed
            double value = Math.Ceiling((double)totalNumOfEvents / NumEventsToDisplayPerPage);
            int lastPage = Convert.ToInt32(value);

            List<EventFormsIndexViewModel> eventFormData =
                await (from ef in _context.EventForms
                       orderby ef.StartDateTime descending
                       select new EventFormsIndexViewModel
                       {
                           // map to model
                           EventFormId = ef.Id,
                           EventTitle = ef.EventTitle,
                           Description = ef.Description,
                           StartDateTime = ef.StartDateTime,
                           EndDateTime = ef.EndDateTime,
                           Category = ef.Category,
                           EventBy = ef.EventBy,
                           Location = ef.Location     
                       })
                       .Skip(NumEventsToDisplayPerPage * (currPage - PageOffset)) // skip 0 rows for the first page
                       .Take(NumEventsToDisplayPerPage) // take how many associated with const value
                       .ToListAsync();
            PaginationEventIndexViewModel eventListPage = new(eventFormData, lastPage, currPage);
            return View(eventListPage);
        }

        // GET: EventForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventForms == null)
            {
                return NotFound();
            }
            var eventForm = await 
                (from ef in _context.EventForms
                 orderby ef.Id
                 select new EventForm
                 {
                     // map to model
                     Id = ef.Id,
                     EventTitle = ef.EventTitle,
                     Description = ef.Description,
                     StartDateTime = ef.StartDateTime,
                     EndDateTime = ef.EndDateTime,
                     Category = ef.Category,
                     EventBy = ef.EventBy,
                     Location = ef.Location
                 }).FirstOrDefaultAsync(m => m.Id == id);
            if (eventForm == null)
            {
                return NotFound();
            }
            return View(eventForm);
        }

        // GET: EventForms/Create
        public IActionResult Create()
        {
            CreateEventViewModel viewModel = new();
            viewModel.AllContacts = _context.Contacts.OrderBy(c => c.FirstName).ToList();
            viewModel.AllCategories = _context.Categories.OrderBy(i => i.EventId).ToList();
            viewModel.AllLocations = _context.Locations.OrderBy(l => l.LocationName).ToList();
            return View(viewModel);
        }

        // POST: EventForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventViewModel eventForm)
        {
            if (ModelState.IsValid)
            {
                // map CreateEventViewModel into newEvent
                EventForm newEvent = new()
                {
                    EventTitle = eventForm.EventTitle,
                    Description = eventForm.Description,
                    StartDateTime = eventForm.StartDateTime,
                    EndDateTime = eventForm.EndDateTime,
                    EventBy = new ContactInfo()
                    { 
                        Id = eventForm.ChosenContact
                    },
                    Category = new EventType()
                    { 
                        EventId = eventForm.ChosenCategory
                    },
                    Location = new Location()
                    { 
                        LocationId = eventForm.ChosenLocation
                    }
                };

                // The entity state has not changed from the existing models
                _context.Entry(newEvent.EventBy).State = EntityState.Unchanged;
                _context.Entry(newEvent.Category).State = EntityState.Unchanged;
                _context.Entry(newEvent.Location).State = EntityState.Unchanged;

                _context.Add(newEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            eventForm.AllContacts = _context.Contacts.OrderBy(c => c.FirstName).ToList();
            eventForm.AllLocations = _context.Locations.OrderBy(l => l.LocationName).ToList();
            eventForm.AllCategories = _context.Categories.OrderBy(i => i.EventId).ToList();
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
        public async Task<IActionResult> Edit(int id, EventForm eventForm)
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