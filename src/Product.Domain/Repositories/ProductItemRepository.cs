using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Models;
using Product.Domain.Specifications;

namespace Product.Domain.Repositories
{
    public class ProductItemRepository : AbstractRepository<ProductItem>, IProductItemRepository
    {
        private new readonly ProductDbContext _context;

        public ProductItemRepository(ProductDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductItem>> GetByFilterAsync(
            ProductItemSpecification specification,
            int pageSize = 10,
            int pageIndex = 0)
        {
            var filter = new ProductItemsByCriteriaSpecification(specification).Criteria; 

            var productItems = await _context.ProductItems
                .Where(filter)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return productItems;
        }

        public async Task RemoveAsync(ProductItem productItem)
        {
            productItem.Status = ProductStatus.INACTIVE;
            await UpdateAsync(productItem);
        }
    }
}