using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class GreetingForm
    {
        #nullable disable
        [Key]
        public int GreetingId { get; set; }

        public string Message { get; set; }
        public GreetingType GreetingType { get; set; }
    }
    }
}