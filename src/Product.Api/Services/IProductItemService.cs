using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Commons.Dtos;
using Product.Domain.Models;

namespace Product.Api.Services
{
    public interface IProductItemService
    {
        Task<ProductItemDto> GetByIdAsync(int id);
        Task<List<ProductItemDto>> GetItemsByFilter();
        Task<ProductItemDto> UpdateAsync(ProductItemDto productItemDto);
        Task<ProductItemDto> RemoveAsync(int id);
        ProductItem FromDto(ProductItemDto productItemDto);
        ProductItemDto ToDto(ProductItem productItem);
    }
}