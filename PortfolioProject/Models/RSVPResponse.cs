using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
#nullable disable
    public class RSVPResponse
    {
        [Key]
        public int Id { get; set; }

        public string RSVPType { get; set; }
    }
}