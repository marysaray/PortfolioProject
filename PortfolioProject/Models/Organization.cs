namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents a specific Organization.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// The associated id to the organization event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Organization.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date and time of the past event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The location of the past event.
        /// </summary>
        public string Place { get; set; }
    }
}