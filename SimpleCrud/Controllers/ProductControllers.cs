using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.Services;
namespace SimpleCrud.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private readonly ProductServices _productServices;
        public ProductControllers(ProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest)

        {
            var createdProduct = await _productServices.AddProduct(addProductRequest);
            return createdProduct == null ? NotFound() : Ok(createdProduct);
        }
        [HttpDelete("/{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            await _productServices.DeleteProduct(ProductId);
            return Ok("Product Deleted");
        }

        [HttpGet]
        public async Task<IActionResult> FetchAllProducts() => Ok(await _productServices.GetAllProducts());

        [HttpGet("findProductById/{ProductId}")]
        public async Task<IActionResult> FindProductById(int ProductId)
        {
            var product = await _productServices.FindProductById(ProductId);
            return product == null ? NotFound() : Ok(product);
        }
        [HttpPut("/{ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, UpdateProductRequest UpdateProductRequestDTO)
        {
            var product = await _productServices.UpdateProduct(ProductId, UpdateProductRequestDTO);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPatch("/{ProductId}")]
        public async Task<IActionResult> UpdateTheProductStoreId(int ProductId, int StoreId)
        {
            var product = await _productServices.UpdateTheProductStoreId(ProductId, StoreId);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
