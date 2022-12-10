namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represents a birthday event.
    /// </summary>
    public class Birthday
    {
        /// <summary>
        /// The associated id to a birthday.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the person's birthday.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date of the birthday.
        /// </summary>
        public DateTime Date { get; set; }
    }
}