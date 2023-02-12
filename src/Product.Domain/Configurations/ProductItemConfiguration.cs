using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Models;

namespace Product.Domain.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder
                .ToTable("product_items")
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder
                .Property(p => p.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(255);
            builder
                .Property(p => p.Status)
                .HasColumnName("status")
                .HasConversion(
                    s => s.ToString(),
                    s => (ProductStatus)Enum.Parse(typeof(ProductStatus), s)
                );
            builder
                .Property(p => p.ManufacturingDate)
                .HasColumnName("manufacturing_date")
                .HasColumnType("datetime");
            builder
                .Property(p => p.ExpirationDate)
                .HasColumnName("expiration_date")
                .HasColumnType("datetime");
            builder
                .Property(p => p.SupplierCode)
                .HasColumnName("supplier_code");
            builder
                .Property(p => p.SupplierDescription)
                .HasColumnName("supplier_description");
            builder
                .Property(p => p.SupplierCompanyDocument)
                .HasColumnName("supplier_company_document");
        }
    }
}