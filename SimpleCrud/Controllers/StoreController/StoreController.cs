using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Data;
using SimpleCrud.Services;

namespace SimpleCrud.Controllers.StoreController
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class StoreController : ControllerBase
    {
        private readonly StoreServices _storeServices;
        public StoreController(ApplicationDBContext context)
        {
            _storeServices = new StoreServices(context);
        }
    }
}
