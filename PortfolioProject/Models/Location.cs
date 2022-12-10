using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents the location of a specific event.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The primary key for the location.
        /// </summary>
        [Key]
        public int LocationId { get; set; }

        /// <summary>
        /// The name of the place or venue.
        /// </summary>
        [Display(Name = "Place")]
        public string LocationName { get; set; }

        /// <summary>
        /// The street address of the event place.
        /// </summary>
        [Display(Name = "Street Address")]
        public string  StreetAddress { get; set; }

        /// <summary>
        /// The city of the event place.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state of the event place.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The zip code of the event place.
        /// </summary>
        public string Zip { get; set; }
    }
}