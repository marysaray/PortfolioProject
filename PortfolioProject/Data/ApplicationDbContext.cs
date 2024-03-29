﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        // Log every query to console
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        public DbSet<EventType> Categories { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Holidays> Holidays { get; set; }

        public DbSet<Birthday> Birthdays { get; set; }

        public DbSet<CelebrationsAndCeremonies> CelebrationsAndCeremonies { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<BabyAndKids> BabyAndKids { get; set; }

        public DbSet<Wedding> Love { get; set; }

        public DbSet<GetTogether> Events { get; set; }

        public DbSet<ContactInfo> Contacts { get; set; }

        public DbSet<EventForm> EventForms { get; set; }

        public DbSet<GreetingType> GreetingTypes { get; set; }

        public DbSet<GreetingForm> GreetingForms { get; set; }

        public DbSet<RSVPForm> RSVPForms { get; set; }

        public DbSet<RSVPResponse> RSVPResponses {get; set;}
    }
}