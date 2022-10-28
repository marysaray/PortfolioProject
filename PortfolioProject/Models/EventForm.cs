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
}