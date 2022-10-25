using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Display(Name = "Place")]
        public string LocationName { get; set; }

        [Display(Name = "Street Address")]
        public string  StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}