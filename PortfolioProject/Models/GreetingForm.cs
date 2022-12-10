using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    /// <summary>
    /// Represents one Greeting Form.
    /// </summary>
    public class GreetingForm
    {
#nullable disable
        /// <summary>
        /// The primary key for one Greeting Form.
        /// </summary>
        [Key]
        public int GreetingId { get; set; }

        /// <summary>
        /// A short message for the greeting.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The associated category type from the GreetingType class.
        /// </summary>
        [Display(Name = "Greeting Type")]
        public GreetingType GreetingType { get; set; }

        /// <summary>
        /// The unique file name that was created when the file is uploaded.
        /// </summary>
        public string PhotoUrl { get; set; }
    }

    /// <summary>
    /// Represents the view model for the Create form page.
    /// </summary>
    public class GreetingCreateViewModel
    { 
        /// <summary>
        /// A list of all greetings.
        /// </summary>
        public List<GreetingType> AllGreetings { get; set; }

        /// <summary>
        /// The choses greeting type.
        /// </summary>
        public int ChosenGreeting { get; set; }

        /// <summary>
        /// A short message for the greeting.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The interface to upload file.
        /// </summary>
        public IFormFile UploadFile { get; set; }
    }

    /// <summary>
    /// Represents the Index view page for Greeting Forms.
    /// </summary>
    public class GreetingIndexViewModel
    {
        /// <summary>
        /// The associated id with the specific greeting.
        /// </summary>
        public int GreetingId { get; set; }

        /// <summary>
        /// The associated category type from the GreetingType class.
        /// </summary>
        [Display(Name = "Greeting Type")]
        public GreetingType GreetingType { get; set; }

        /// <summary>
        /// A short message for the greeting.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The unique file name that was created when the file is uploaded.
        /// </summary>
        public string Photo { get; set; }
    }
}