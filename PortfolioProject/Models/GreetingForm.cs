using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class GreetingForm
    {
        #nullable disable
        [Key]
        public int GreetingId { get; set; }

        public string Message { get; set; }

        [Display(Name = "Greeting Type")]
        public GreetingType GreetingType { get; set; }

        public string PhotoUrl { get; set; }
    }

    public class GreetingCreateViewModel
    { 
        public List<GreetingType> AllGreetings { get; set; }

        public int ChosenGreeting { get; set; }

        public string Message { get; set; }

        public IFormFile UploadFile { get; set; }
    }

    public class GreetingIndexViewModel
    { 
        public int GreetingId { get; set; }

        [Display(Name = "Greeting Type")]
        public GreetingType GreetingType { get; set; }
        public string Message { get; set; }

        public string Photo { get; set; }
    }
}