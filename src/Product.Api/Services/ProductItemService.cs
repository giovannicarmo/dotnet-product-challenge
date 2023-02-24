using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Product.Commons.Dtos;
using Product.Commons.Validators;
using Product.Domain.Models;
using Product.Domain.Repositories;
using Product.Domain.Specifications;

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
            var productItem = await _repository.GetByIdAsync(id);

            if (productItem == null)
            {
                throw new ArgumentException($"Product item not found for given Id: {id}");
            }

            return _mapper.Map<ProductItemDto>(productItem);
        }

        public async Task<List<ProductItemDto>> GetByFilterAsync(
            ProductItemSpecification specification,
            int pageSize,
            int pageIndex
        )
        {
            var productItems = await _repository.GetByFilterAsync(specification, pageSize, pageIndex);
            return _mapper.Map<List<ProductItemDto>>(productItems);
        }

        public async Task<ProductItemDto> CreateAsync(ProductItemDto productItemDto)
        {
            _validator.ValidateAndThrow(productItemDto);
            var productItem = _mapper.Map<ProductItem>(productItemDto);

            await _repository.AddAsync(productItem);

            return _mapper.Map<ProductItemDto>(productItem);
        }

        public async Task<ProductItemDto> UpdateAsync(int id, ProductItemDto productItemDto)
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

        public async Task<ProductItemDto> RemoveAsync(int id)
        {
            var productItem = await _repository.GetByIdAsync(id);

            if (productItem == null || !productItem.Exists)
            {
                throw new ArgumentException($"Product item not found for given Id: {id}");
            }

            await _repository.RemoveAsync(productItem);

            return _mapper.Map<ProductItemDto>(productItem);
        }
    }
}