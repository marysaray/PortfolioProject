using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
#nullable disable
    public class RSVPForm
    {
        [Key]
        public int RSVPId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ConfirmedEmail { get; set; }

        public string RSVPResponse { get; set; }

        public DateTime DateSubmitted { get; set; }

        public EventForm Event { get; set; }
    }
}