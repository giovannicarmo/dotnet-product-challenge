using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Commons.Dtos;
using Product.Domain.Specifications;

namespace Product.Api.Services
{
    public interface IProductItemService
    {
        Task<ProductItemDto> GetByIdAsync(int id);
        Task<List<ProductItemDto>> GetByFilterAsync(
            ProductItemSpecification specification,
            int pageSize,
            int pageIndex
        );
        Task<ProductItemDto> CreateAsync(ProductItemDto productItemDto);
        Task<ProductItemDto> UpdateAsync(int id, ProductItemDto productItemDto);
        Task<ProductItemDto> RemoveAsync(int id);
    }
}