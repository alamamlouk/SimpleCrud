using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTO.StoreDTO;

namespace SimpleCrud.Controllers.StoreController
{
    public partial class StoreController : ControllerBase
    {
        //Ask if i can pass the store Id in the UpdateStoreRequestDTO or not
        [HttpPut("UpdateStore/{StoreId}")]
        public async Task<IActionResult> UpdateStore(int StoreId, UpdateStoreRequestDTO StoreBody)
        {
            var store = await _storeServices.UpdateStore(StoreId, StoreBody);
            return store == null ? NotFound() : Ok(store);

        }
      
    }
}
