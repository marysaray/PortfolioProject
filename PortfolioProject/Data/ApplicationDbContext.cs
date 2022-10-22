using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Models;

#nullable disable

namespace PortfolioProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventType> Categories { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Holidays> Holidays { get; set; }

        public DbSet<Birthday> Birthdays { get; set; }

        public DbSet<CelebrationsAndCeremonies> CelebrationsAndCeremonies { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<BabyAndKids> BabyAndKids { get; set; }

        public DbSet<Wedding> Love { get; set; }
    }
}