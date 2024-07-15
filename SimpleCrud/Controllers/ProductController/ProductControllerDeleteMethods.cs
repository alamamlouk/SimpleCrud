using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCrud.Controllers.ProductController
{

    public partial class ProductController : ControllerBase
    {

        [HttpDelete("DeleteProduct/{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            await _productServices.DeleteProduct(ProductId);
            return Ok("Product Deleted");
        }
    }
}
