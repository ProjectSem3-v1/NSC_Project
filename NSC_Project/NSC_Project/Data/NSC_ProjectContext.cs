using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSC_Project.Models;

namespace NSC_Project.Data
{
    public class NSC_ProjectContext : DbContext
    {
        public NSC_ProjectContext (DbContextOptions<NSC_ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<NSC_Project.Models.Customer> Customer { get; set; } = default!;
        public DbSet<NSC_Project.Models.AirlineCompany> AirlineCompany { get; set; } = default!;
        public DbSet<NSC_Project.Models.AirportFrom> AirportFrom { get; set; } = default!;
        public DbSet<NSC_Project.Models.AirportTo> AirportTo { get; set; } = default!;
        public DbSet<NSC_Project.Models.Bill> Bill { get; set; } = default!;
        public DbSet<NSC_Project.Models.Fare> Fare { get; set; } = default!;
        public DbSet<NSC_Project.Models.FlightRoute> FlightRoute { get; set; } = default!;
        public DbSet<NSC_Project.Models.Plane> Plane { get; set; } = default!;
        public DbSet<NSC_Project.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<NSC_Project.Models.TicketClass> TicketClass { get; set; } = default!;
        public DbSet<NSC_Project.Models.Trip> Trip { get; set; } = default!;

    }
}
