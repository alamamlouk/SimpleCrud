using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Data;
using SimpleCrud.DTO.ProductDTO;
using SimpleCrud.Services;

namespace SimpleCrud.Controllers.ProductController.ProductController
{
    [Route("api/product")]
    [ApiController]
    public partial class ProductController : ControllerBase
    {
        private readonly ProductServices _productServices;
        public ProductController(ApplicationDBContext context)
        {
            _productServices = new ProductServices(context);
        }
       
    }
}
