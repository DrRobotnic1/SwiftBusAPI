using Domain.Models.ScheduleModel;
using Microsoft.EntityFrameworkCore;
using SwiftBusAPI.Domain.Models.BusModel;
using SwiftBusAPI.Domain.Models.CityModel;
using SwiftBusAPI.Domain.Models.CompanyModel;
using SwiftBusAPI.Domain.Models.RouteModel;
using SwiftBusAPI.Domain.Models.TicketModel;
using SwiftBusAPI.Domain.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class SwiftBusDataContext : DbContext
    {
        public SwiftBusDataContext(DbContextOptions<SwiftBusDataContext> options) : base(options) { }

        public DbSet<Bus> buses { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<Ticket> tickets { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Schedule> schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Company
            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .Property(c => c.CompName)
                .IsRequired();

            // Bus
            modelBuilder.Entity<Bus>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.Company)
                .WithMany(c => c.Buses)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // City
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<City>()
                .Property(c => c.CityName)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasMany(c => c.DepartureRoutes)
                .WithOne(r => r.DepartureCity)
                .HasForeignKey(r => r.DepartureCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
                .HasMany(c => c.ArrivalRoutes)
                .WithOne(r => r.ArrivalCity)
                .HasForeignKey(r => r.ArrivalCityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Route
            modelBuilder.Entity<Route>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.DepartureCity)
                .WithMany(c => c.DepartureRoutes)
                .HasForeignKey(r => r.DepartureCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.ArrivalCity)
                .WithMany(c => c.ArrivalRoutes)
                .HasForeignKey(r => r.ArrivalCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Route>()
                .Property(r => r.DistanceKm)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Route>()
                .Property(r => r.TollCost)
                .HasColumnType("decimal(10,2)");

            // User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Ticket
            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Bus)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BusId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Route)
                .WithMany(r => r.Tickets)
                .HasForeignKey(t => t.RouteId);

            // Payment
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Ticket)
                .WithOne(t => t.Payment)
                .HasForeignKey<Payment>(p => p.TicketId);

            modelBuilder.Entity<Payment>()
    .Property(p => p.AmountPaid)
    .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Ticket>()
                .Property(t => t.BasePrice)
                .HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Schedule>().ToTable("Schedules");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "YourConnectionStringHere",
                    x => x.MigrationsAssembly("SwiftBusAPI")
                );
            }





        }
    }
}
