using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Product.Commons.Dtos;
using Product.Commons.Exceptions;
using Product.Commons.Validators;
using Product.Domain.Models;
using Product.Domain.Repositories;

namespace Product.Api.Services
{
    public class ProductItemService : IProductItemService
    {
        private readonly IMapper _mapper;
        private readonly IProductItemRepository _productItemRepository;
        private readonly ProductItemDTOValidator _productItemValidator;

        public ProductItemService(
            IMapper mapper,
            IProductItemRepository productItemRepository,
            ProductItemDTOValidator productItemValidator)
        {
            _mapper = mapper;
            _productItemRepository = productItemRepository;
            _productItemValidator = productItemValidator;
        }

        public async Task<ProductItemDto> GetByIdAsync(int id)
        {
            try
            {
                var result = await _productItemRepository.GetByIdAsync(id);

                if (result == null)
                {
                    throw new EntityNotFountException($"Product item not found for given Id: {id}");
                }

                return ToDto(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<ProductItemDto>> GetItemsByFilter()
        {
            throw new NotImplementedException();
        }

        public Task<ProductItemDto> UpdateAsync(ProductItemDto productItemDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductItemDto> RemoveAsync(int id)
        {
            try
            {
                var productItem = await _productItemRepository.GetByIdAsync(id);

                if (productItem == null || productItem.Status == ProductStatus.INACTIVE)
                {
                    throw new EntityNotFountException($"Product item not found for given Id: {id}");
                }

                var result = await _productItemRepository.RemoveAsync(productItem);

                return ToDto(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ProductItem FromDto(ProductItemDto productItemDto)
            => _mapper.Map<ProductItem>(productItemDto);

        private ProductItemDto ToDto(ProductItem productItem)
        => _mapper.Map<ProductItemDto>(productItem);
    }
}