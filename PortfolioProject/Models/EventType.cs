using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    public class EventType
    {
        [Key]
        public int EventId { get; set; }

        public string Category { get; set; }
    }
}