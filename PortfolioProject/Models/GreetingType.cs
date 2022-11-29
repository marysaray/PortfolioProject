using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    public class GreetingType
    {
        [Key]
        public int GreetingId { get; set; }

        public string GreetingName { get; set; }
    }
}