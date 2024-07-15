using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTO.StoreDTO;

namespace SimpleCrud.Controllers.StoreController
{
    public partial class StoreController : ControllerBase
    {
        [HttpPost("CreateStore")]
        public IActionResult AddStore(AddStoreRequestDTO addStoreRequestDTO)
        {

            AddStoreResponseDTO response = _storeServices.AddStore(addStoreRequestDTO).Result;
            return Ok(response);
        }

       
    }
}
