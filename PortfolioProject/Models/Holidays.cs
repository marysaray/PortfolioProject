using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents a Holiday event.
    /// </summary>
    public class Holidays
    {
        /// <summary>
        /// The associated id to the occasion.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the occasion.
        /// </summary>
        [Display(Name = "Holiday")]
        public string HolidayName { get; set; }
    }
}