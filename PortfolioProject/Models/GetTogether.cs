namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents a get-together event.
    /// </summary>
    public class GetTogether
    {
        /// <summary>
        /// The associated id to the get-together.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the get-together.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The get-together location.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// The date and time of the get-together.
        /// </summary>
        public DateTime Date {get; set;}
    }
}