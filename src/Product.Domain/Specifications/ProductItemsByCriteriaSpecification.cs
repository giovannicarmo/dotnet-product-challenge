using System;
using System.Linq.Expressions;
using Product.Domain.Models;
using LinqKit;

namespace Product.Domain.Specifications
{
    public class ProductItemsByCriteriaSpecification : ISpecification<ProductItem>
    {
        private readonly ProductItemSpecification _spec;

        public ProductItemsByCriteriaSpecification(ProductItemSpecification spec)
        {
            _spec = spec;
        }

        public Expression<Func<ProductItem, bool>> Criteria
        {
            get
            {
                var predicate = PredicateBuilder.New<ProductItem>();

                if (!string.IsNullOrEmpty(_spec.Description))
                {
                    predicate = predicate.And(pi => pi.Description.Contains(_spec.Description));
                }

                if (_spec.StartExpirationDate.HasValue)
                {
                    predicate = predicate.And(pi => pi.ManufacturingDate >= _spec.StartExpirationDate.Value);
                }

                if (_spec.EndExpirationDate.HasValue)
                {
                    predicate = predicate.And(pi => pi.ManufacturingDate <= _spec.EndExpirationDate.Value);
                }

                if (_spec.SupplierCode.HasValue)
                {
                    predicate = predicate.And(pi => pi.SupplierCode == _spec.SupplierCode.Value);
                }

                return predicate;
            }
        }
    }

    public class ProductItemSpecification
    {
        public string Description { get; set; }
        public DateTime? StartExpirationDate { get; set; }
        public DateTime? EndExpirationDate { get; set; }
        public int? SupplierCode { get; set; }
    }
}