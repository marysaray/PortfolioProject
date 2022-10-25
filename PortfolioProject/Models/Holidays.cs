namespace PortfolioProject.Models
{
#nullable disable
    public class Holidays
    {
        public int Id { get; set; }

        [Display(Name = "Holiday")]
        public string HolidayName { get; set; }
    }
}
