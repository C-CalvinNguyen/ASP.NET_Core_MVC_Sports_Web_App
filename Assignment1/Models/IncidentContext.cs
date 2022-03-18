using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IncidentContext : DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Technician> Technician { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<IncidentListViewModel> IncidentListViewModel { get; set; }
        public DbSet<Registration> Registration { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());

            modelBuilder.ApplyConfiguration(new TechnicianConfig());

            modelBuilder.ApplyConfiguration(new CountryConfig());

            modelBuilder.ApplyConfiguration(new CustomerConfig());

            modelBuilder.ApplyConfiguration(new IncidentConfig());

            modelBuilder.ApplyConfiguration(new RegistrationConfig());
        }
    }
}
