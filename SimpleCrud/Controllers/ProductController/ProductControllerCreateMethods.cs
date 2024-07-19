using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTO.ProductDTO;
namespace SimpleCrud.Controllers.ProductController
{

    public partial class ProductController : ControllerBase
    {
     
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductRequestDTO AddProductRequestDTO)
        {
            return await _productServices.AddProduct(AddProductRequestDTO) == null ? NotFound() : Ok("Product Added");
        }
    }
  
}
