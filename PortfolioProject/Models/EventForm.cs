using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    public class EventForm
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Date Time")]
        public DateTime EndDateTime { get; set; }

        public ContactInfo EventBy { get; set; }

        public EventType Category { get; set; }

        public Location Location { get; set; }
    }

    public class CreateEventViewModel
    {
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Date Time")]
        public DateTime EndDateTime { get; set; }

        public List<ContactInfo> AllContacts { get; set; }

        public int ChosenContact { get; set; }

        public List<EventType> AllCategories { get; set; }

        public int ChosenCategory { get; set; }

        public List<Location> AllLocations { get; set; }

        public int ChosenLocation { get; set; }
    }

    public class EventFormsIndexViewModel
    {
        public int EventFormId { get; set; }

        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "End Date Time")]
        public DateTime EndDateTime { get; set; }

        public ContactInfo EventBy { get; set; }

        public EventType Category { get; set; }

        public Location Location { get; set; }
    }

    public class PaginationEventIndexViewModel
    {
        /// <summary>
        /// This constructor is for the pagination model
        /// </summary>
        public PaginationEventIndexViewModel(List<EventFormsIndexViewModel> events, int lastPage, int currPage)
        {
            EventForms = events;
            LastPage = lastPage;
            CurrentPage = currPage;
        }
        public List<EventFormsIndexViewModel> EventForms { get; private set; }

        /// <summary>
        /// The last page of the events. 
        /// Calculated by having a total number of
        /// events divided by events per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// Current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}