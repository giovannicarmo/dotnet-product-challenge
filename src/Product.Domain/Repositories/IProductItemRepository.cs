using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain.Models;
using Product.Domain.Specifications;

namespace Product.Domain.Repositories
{
    public interface IProductItemRepository : IRepository<ProductItem>
    {
        public Task<IEnumerable<ProductItem>> GetByFilterAsync(
            ProductItemSpecification specification,
            int pageSize,
            int pageIndex
        );
        Task RemoveAsync(ProductItem productItem);
    }
}