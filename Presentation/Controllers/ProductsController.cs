using Microsoft.AspNetCore.Mvc;
using SimpleServerProducts.Application.Interfaces;
using SimpleServerProducts.Core.Models;

namespace SimpleServerProducts.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Product? productToReturn = await _productService.GetOne(id);

            if (productToReturn == null)
            {
                return NotFound();
            }
            return Ok(productToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            Product? productToReturn = await _productService.Create(product);

            if (productToReturn == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = productToReturn.Id }, productToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            Product? updatedProduct = await _productService.Update(id, product);

            if (updatedProduct == null)
            {
                return NotFound("Product not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? RemovedProduct = await _productService.Delete(id);
            if (RemovedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
