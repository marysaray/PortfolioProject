using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents a celebration or ceremony.
    /// </summary>
    public class CelebrationsAndCeremonies
    {
        /// <summary>
        /// The associated id to the event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
    }
}