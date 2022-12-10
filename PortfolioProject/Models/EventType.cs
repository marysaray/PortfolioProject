using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents one specific category type.
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// The primary key for the event type.
        /// </summary>
        [Key]
        public int EventId { get; set; }

        /// <summary>
        /// The type of event.
        /// </summary>
        public string Category { get; set; }
    }
}