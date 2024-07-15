using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTO.StoreDTO;

namespace SimpleCrud.Controllers.StoreController
{
    public partial class StoreController : ControllerBase
    {
        [HttpGet("GetAllStores")]
        public async Task<IActionResult> FetchAllStores()
        {
            return Ok(await _storeServices.GetAllStores());
        }
        [HttpGet("FindStoreById/{StoreId}")]
        public async Task<IActionResult> FindStoreById(int StoreId)
        {
            var findStore = await _storeServices.FindStore(StoreId);
            return findStore == null ? NotFound() : Ok(findStore);
        }


    }
}
