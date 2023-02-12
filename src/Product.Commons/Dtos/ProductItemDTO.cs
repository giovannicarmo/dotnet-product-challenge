using System;

namespace Product.Commons.Dtos
{
    public class ProductItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCompanyDocument { get; set; }
    }
}