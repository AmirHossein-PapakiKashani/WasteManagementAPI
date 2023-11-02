using Microsoft.EntityFrameworkCore;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.Configuration;


namespace WasteManagementAPI.Models
{
    public class WastMangementAuthContext : DbContext
    {
        public WastMangementAuthContext(DbContextOptions<WastMangementAuthContext> options) : base(options) { }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }

    }
}
