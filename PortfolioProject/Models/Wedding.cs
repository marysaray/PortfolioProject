namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents occasions of different events.
    /// Engagement, Bridal, Groom, Rehearsal, etc..
    /// </summary>
    public class Wedding
    {
        /// <summary>
        /// The associated id to the specific event.
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// A short description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }
    }
}