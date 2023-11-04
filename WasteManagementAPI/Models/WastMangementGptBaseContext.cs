using Microsoft.EntityFrameworkCore;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.Configuration;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Models
{
    public class WastMangementGptBaseContext : DbContext
    {
        public WastMangementGptBaseContext(DbContextOptions<WastMangementGptBaseContext> options) : base(options) { }

        public DbSet<Citizens> Citizens { get; set; }

        public DbSet<Contractors> Contractors { get; set; }

        public DbSet<CollectionBooths> CollectionBooths { get; set; }

        public DbSet<Municipalities> Municipality { get; set;}


        public DbSet<Supervisors> Supervisor { get; set; }

        public DbSet<WasteTypes> WasteTypes { get; set; }

        public DbSet<Shipments> Shipments { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
////modelBuilder.ApplyConfiguration(new ProductConfig());
//        }

    }
}
