using Microsoft.EntityFrameworkCore;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.Configuration;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Models
{
    public class WastMangementContext : DbContext
    {
        public WastMangementContext(DbContextOptions<WastMangementContext> options) : base(options) { }

        public DbSet<Citizens> Citizens { get; set; }

        public DbSet<Contractors> Contractors { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Municipalities> Municipality { get; set;}


        public DbSet<Supervisors> Supervisor { get; set; }

        public DbSet<UserProduct> UserProducts { get; set; }

        public DbSet<MainProduct> MainProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }

    }
}
