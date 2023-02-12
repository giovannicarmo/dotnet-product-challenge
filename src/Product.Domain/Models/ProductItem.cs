using System;

namespace Product.Domain.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.ACTIVE;
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCompanyDocument { get; set; }
        public bool Exists => Status == ProductStatus.ACTIVE;
    }

    public enum ProductStatus
    {
        ACTIVE,
        INACTIVE
    }
}