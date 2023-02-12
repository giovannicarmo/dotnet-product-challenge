using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Product.Commons.Dtos;
using Product.Commons.Validators;
using Product.Domain.Models;
using Product.Domain.Repositories;
using FluentValidation;

namespace Product.Api.Services
{
    public class ProductItemService : IProductItemService
    {
        private readonly IMapper _mapper;
        private readonly IProductItemRepository _repository;
        private readonly ProductItemDTOValidator _validator;

        public ProductItemService(
            IMapper mapper,
            IProductItemRepository repository,
            ProductItemDTOValidator validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<ProductItemDto> GetByIdAsync(int id)
        {
            try
            {
                var productItem = await _repository.GetByIdAsync(id);

                if (productItem == null)
                {
                    throw new ArgumentException($"Product item not found for given Id: {id}");
                }

                return _mapper.Map<ProductItemDto>(productItem);
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

        public async Task<ProductItemDto> CreateAsync(ProductItemDto productItemDto)
        {
            try
            {
                _validator.ValidateAndThrow(productItemDto);
                var productItem = _mapper.Map<ProductItem>(productItemDto);

                await _repository.AddAsync(productItem);

                return _mapper.Map<ProductItemDto>(productItem);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductItemDto> UpdateAsync(int id, ProductItemDto productItemDto)
        {
            try
            {
                var productItem = await _repository.GetByIdAsync(id);

                if (productItem == null)
                {
                    throw new ArgumentException($"Product item not found for given Id: {id}");
                }

                _validator.ValidateAndThrow(productItemDto);
                _mapper.Map(productItemDto, productItem);

                await _repository.UpdateAsync(productItem);

                return _mapper.Map<ProductItemDto>(productItem);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductItemDto> RemoveAsync(int id)
        {
            try
            {
                var productItem = await _repository.GetByIdAsync(id);

                if (productItem == null || !productItem.Exists)
                {
                    throw new ArgumentException($"Product item not found for given Id: {id}");
                }

                await _repository.RemoveAsync(productItem);

                return _mapper.Map<ProductItemDto>(productItem);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}