using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_CRUD_API.Services.ProductServices;

namespace Product_CRUD_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetSingeleProduct(int id)
        {
            var result = await _productService.GetSingleProduct(id);
            if (result is null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            var result = await _productService.CreateProduct(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product request)
        {
            var result = await _productService.UpdateProduct(id,request);
            if (result is null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id, Product request)
        {
            var result = await _productService.DeleteProduct(id);
            if(result is null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(result);
        }
    }
}
