using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Product.Api.Services;
using Product.Commons.Dtos;
using System.Collections.Generic;
using Product.Domain.Specifications;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductItemService _productItemService;

        public ProductItemController(IProductItemService productItemService, IMapper mapper)
        {
            _productItemService = productItemService;
        }

        // GET: api/ProductItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItemDto>> GetProductItemAsync(int id)
        {
            try
            {
                var productItem = await _productItemService.GetByIdAsync(id);
                return Ok(productItem);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: api/ProductItem
        [HttpGet]
        public async Task<ActionResult<List<ProductItemDto>>> GetProductItemsByFilterAsync(
            string description,
            DateTime? startExpirationDate,
            DateTime? endExpirationDate,
            int? supplierCode,
            int pageSize,
            int pageIndex
        )
        {
            try
            {
                var specification = new ProductItemSpecification
                {
                    Description = description, 
                    StartExpirationDate = startExpirationDate,
                    EndExpirationDate = endExpirationDate,
                    SupplierCode = supplierCode,
                };

                var productItems = await _productItemService.GetByFilterAsync(specification, pageSize, pageIndex);
                return Ok(productItems);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST: api/ProductItem
        [HttpPost]
        public async Task<ActionResult<ProductItemDto>> PostProductItemAsync(ProductItemDto productItemDto)
        {
            try
            {
                var productItem = await _productItemService.CreateAsync(productItemDto);
                return Ok(productItem);
            }
            catch (ValidationException e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT: api/ProductItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductItemAsync(int id, ProductItemDto productItemDto)
        {
            try
            {
                await _productItemService.UpdateAsync(id, productItemDto);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (ValidationException e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE: api/ProductItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductItemAsync(int id)
        {
            try
            {
                await _productItemService.RemoveAsync(id);

                return NoContent();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}