using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Commons.Dtos;

namespace Product.Api.Services
{
    public interface IProductItemService
    {
        Task<ProductItemDto> GetByIdAsync(int id);
        Task<List<ProductItemDto>> GetItemsByFilter();
        Task<ProductItemDto> CreateAsync(ProductItemDto productItemDto);
        Task<ProductItemDto> UpdateAsync(int id, ProductItemDto productItemDto);
        Task<ProductItemDto> RemoveAsync(int id);
    }
}