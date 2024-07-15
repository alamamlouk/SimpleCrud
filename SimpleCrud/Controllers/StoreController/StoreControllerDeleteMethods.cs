using Microsoft.AspNetCore.Mvc;

namespace SimpleCrud.Controllers.StoreController
{
    public partial class StoreController : ControllerBase
    {
        [HttpDelete("DeleteStore/{StoreId}")]
        public async Task<IActionResult> DeleteStore(int StoreId)
        {
            await _storeServices.DeleteStore(StoreId);
            return Ok("Store Deleted");
        }
        [HttpDelete("EmptyStoreTable")]
        public async Task<IActionResult> EmptyStoreTable()
        {
            await _storeServices.EmptyStoreTable();
            return Ok("Store Table Emptied");
        }
    }
}
