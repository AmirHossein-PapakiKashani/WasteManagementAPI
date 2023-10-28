using Microsoft.EntityFrameworkCore;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Models.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<MainProduct>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MainProduct> builder)
        {
            builder.HasData
                (
                 new MainProduct { MainProductId = 1 , Name = "Bread"},
                 new MainProduct {MainProductId = 2 , Name = "Iron"},
                 new MainProduct {MainProductId = 3 , Name = "Plastic"}
                );
        }
    }
}
