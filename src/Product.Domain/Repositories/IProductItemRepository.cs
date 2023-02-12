using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain.Models;

namespace Product.Domain.Repositories
{
    public interface IProductItemRepository : IRepository<ProductItem>
    {
        Task<List<ProductItem>> GetFilteredAsync();
        Task RemoveAsync(ProductItem productItem);
    }
}