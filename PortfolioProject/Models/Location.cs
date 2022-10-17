using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string  StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
