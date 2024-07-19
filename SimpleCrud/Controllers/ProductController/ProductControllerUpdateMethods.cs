using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTO.ProductDTO;

namespace SimpleCrud.Controllers.ProductController
{
    public partial class ProductController : ControllerBase
    {
        [HttpPut("UpdateProduct/{ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, UpdateProductRequestDTO UpdateProductRequestDTO)
        {
            var product = await _productServices.UpdateProduct(ProductId, UpdateProductRequestDTO);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPatch("UpdateTheProductStoreId/{ProductId}")]
        public async Task<IActionResult> UpdateTheProductStoreId(int ProductId, int StoreId)
        {
            var product = await _productServices.UpdateTheProductStoreId(ProductId, StoreId);
            return product == null ? NotFound() : Ok(product);
        }


    }
}
