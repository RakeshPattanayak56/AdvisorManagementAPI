using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Infrastructure.Data
{
    public class AdvisorDbContext : DbContext
    {
        public AdvisorDbContext(DbContextOptions<AdvisorDbContext> options) : base(options) { }

        public DbSet<Advisors> Advisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply any specific configurations, like constraints or seed data
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Advisors>()
        .Property(a => a.HealthStatus)
        .HasConversion<string>()  // Convert enum to string in the database
        .HasMaxLength(8);  // Set the maximum length for nvarchar(8)
        }
    }
}
