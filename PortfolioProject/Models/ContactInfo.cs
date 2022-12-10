using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
#nullable disable
    /// <summary>
    /// Represent the contact or host of the event.
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// The primary key for the contact.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The first name of the contact person.
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the contact person.
        /// </summary>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number of the contact person.
        /// </summary>
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The email of the contact person.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
    }
}