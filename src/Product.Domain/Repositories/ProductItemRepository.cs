using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Models;

namespace Product.Domain.Repositories
{
    public class ProductItemRepository : AbstractRepository<ProductItem>, IProductItemRepository
    {
        private readonly Context _context;

        public ProductItemRepository(Context context) : base(context)
        {
            _context = context;
        }

        public Task<List<ProductItem>> GetFilteredAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductItem> RemoveAsync(ProductItem productItem)
        {
            productItem.Status = ProductStatus.INACTIVE;   
            return await UpdateAsync(productItem);
        }
    }
}