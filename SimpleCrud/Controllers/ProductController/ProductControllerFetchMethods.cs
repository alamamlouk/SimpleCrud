using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTO.ProductDTO;

namespace SimpleCrud.Controllers.ProductController
{

    public partial class ProductController : ControllerBase
    {
        [HttpGet("FetchAllProduct")]
        public async Task<IActionResult> FetchAllProducts() => Ok(await _productServices.GetAllProducts());

        [HttpGet("FindProductById/{ProductId}")]
        public async Task<IActionResult> FindProductById(int ProductId)
        {
            var product = await _productServices.FindProductById(ProductId);
            return product == null ? NotFound() : Ok(product);
        }
     
    }
}
