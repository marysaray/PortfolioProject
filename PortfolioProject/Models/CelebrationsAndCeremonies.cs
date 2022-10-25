using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
#nullable disable
    public class CelebrationsAndCeremonies
    {
        public int Id { get; set; }

        [Display(Name = "Event Name")]
        public string EventName { get; set; }
    }
}