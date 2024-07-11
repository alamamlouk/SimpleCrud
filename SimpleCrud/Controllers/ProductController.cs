using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Data;
using SimpleCrud.Services;

namespace SimpleCrud.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      private readonly ProductServices _productServices;
        public ProductController(ApplicationDBContext context)
        {
            _productServices = new ProductServices(context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productServices.getAllProducts());
        }
    }
}
