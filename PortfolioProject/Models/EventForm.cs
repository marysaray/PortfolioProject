using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents one Event Form.
    /// </summary>
    public class EventForm
    {
        /// <summary>
        /// The primary key for one Event Form.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        /// <summary>
        /// The reason for the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date and time of the event.
        /// </summary>
        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// The end date and time of the event.
        /// </summary>
        [Display(Name = "End Date Time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// The host of the event implemented from the Contacts class.
        /// </summary>
        public ContactInfo EventBy { get; set; }

        /// <summary>
        /// The associated category type from the EventType class.
        /// </summary>
        public EventType Category { get; set; }

        /// <summary>
        /// The location of the event implemented from the Location class.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// The name or description of the file that is uploaded.
        /// </summary>
        [Display(Name = "Caption")]
        public string PhotoTitle { get; set; }

        /// <summary>
        /// The unique file name that was created when the file is uploaded.
        /// </summary>
        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }
    }

    /// <summary>
    /// Represents the view model for the Create form page.
    /// </summary>
    public class CreateEventViewModel
    {
        /// <summary>
        /// The name of the event.
        /// </summary>
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        /// <summary>
        /// The reason for the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date and time of the event.
        /// </summary>
        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// The end date and time of the event.
        /// </summary>
        [Display(Name = "End Date Time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// A list of all contacts.
        /// </summary>
        public List<ContactInfo> AllContacts { get; set; }

        /// <summary>
        /// The chosen contact for the event.
        /// </summary>
        public int ChosenContact { get; set; }

        /// <summary>
        /// A list of all categories.
        /// </summary>
        public List<EventType> AllCategories { get; set; }

        /// <summary>
        /// The chosen category type.
        /// </summary>
        public int ChosenCategory { get; set; }

        /// <summary>
        /// A list of all locations.
        /// </summary>
        public List<Location> AllLocations { get; set; }

        /// <summary>
        /// The chosen location.
        /// </summary>
        public int ChosenLocation { get; set; }

        /// <summary>
        /// The name or description of the file that is uploaded.
        /// </summary>
        [Display(Name = "Caption")]
        public string PhotoTitle { get; set; }

        /// <summary>
        /// The interface to upload file.
        /// </summary>
        [Display(Name = "Photo")]
        public IFormFile UploadImage { get; set; }
    }

    /// <summary>
    /// Represents the Index view page for Event Forms.
    /// </summary>
    public class EventFormsIndexViewModel
    {
        /// <summary>
        /// The associated id with the specific event.
        /// </summary>
        [Display(Name ="Event Type")]
        public int EventFormId { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        /// <summary>
        /// The reason for the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date and time of the event.
        /// </summary>
        [Display(Name = "Start Date Time")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// The end date and time of the event.
        /// </summary>
        [Display(Name = "End Date Time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// The host of the event implemented from the Contacts class.
        /// </summary>
        public ContactInfo EventBy { get; set; }

        /// <summary>
        /// The associated category type from the EventType class.
        /// </summary>
        public EventType Category { get; set; }

        /// <summary>
        /// The location of the event implemented from the Location class.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// The name or description of the file that is uploaded.
        /// </summary>
        [Display(Name = "Caption")]
        public string PhotoTitle { get; set; }

        /// <summary>
        /// The unique file name that was created when the file is uploaded.
        /// </summary>
        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }
    }

    /// <summary>
    /// Represents the view page with how many pages are available. 
    /// </summary>
    public class PaginationEventIndexViewModel
    {
        /// <summary>
        /// This constructor is for the pagination model.
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
        /// events divided by events per page.
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// Current page the user is viewing.
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}