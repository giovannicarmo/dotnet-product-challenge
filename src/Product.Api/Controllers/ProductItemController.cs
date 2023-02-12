using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Product.Api.Services;
using Product.Commons.Dtos;

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

        // // GET: api/ProductItem
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<ProductItemDto>>> GetProductItems()
        // {
        //     try
        //     {
        //         var productItems = await _productItemService.GetAllAsync();
        //         return Ok(_mapper.Map<IEnumerable<ProductItemDto>>(productItems));
        //     }
        //     catch (Exception e)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        //     }
        // }

        // GET: api/ProductItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItemDto>> GetProductItem(int id)
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

        // POST: api/ProductItem
        [HttpPost]
        public async Task<ActionResult<ProductItemDto>> PostProductItem(ProductItemDto productItemDto)
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
        public async Task<IActionResult> PutProductItem(int id, ProductItemDto productItemDto)
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
        public async Task<IActionResult> DeleteProductItem(int id)
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