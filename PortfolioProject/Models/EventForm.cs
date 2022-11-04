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

        [Display(Name ="Event Title")]
        public string EventTitle { get; set; }

        public ContactInfo EventBy { get; set; }

        public EventType Category { get; set; }

        public Location Location { get; set; }
    }

    public class CreateEventViewModel
    {
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        public List<ContactInfo> AllContacts { get; set; }

        public ContactInfo ChosenContact { get; set; }

        public List<EventType> AllCategories { get; set; }

        public EventType ChosenCategory { get; set; }

        public List<Location> AllLocations { get; set; }

        public Location ChosenLocation { get; set; }
    }
}