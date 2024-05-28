using GeekShopping.ProductsApi.Data.ValueObjects;
using GeekShopping.ProductsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products = await _repository.FindAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product.Id <= 0) 
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto productDto)
        {
            if (productDto is null)
                return BadRequest();

            var product = await _repository.Create(productDto);
            return Ok(product);
        }


        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update(ProductDto productDto)
        {
            if (productDto is null)
                return BadRequest();

            var product = await _repository.Update(productDto);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (status is false)
                return BadRequest();

            return Ok(status);
        }
    }
}
