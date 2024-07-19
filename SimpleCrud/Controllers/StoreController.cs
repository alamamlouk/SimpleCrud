using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Data;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Services;

namespace SimpleCrud.Controllers
{
    [Route("api/store")]
    [ApiController]
    public partial class StoreController : ControllerBase
    {
        private readonly StoreServices _storeServices;
        public StoreController(ApplicationDBContext context, IMapper mapper)
        {
            _storeServices = new StoreServices(context, mapper);
        }
        [HttpGet]
        public async Task<IActionResult> FetchAllStores()
        {
            return Ok(await _storeServices.GetAllStores());
        }
        [HttpGet("/{StoreId}")]
        public async Task<IActionResult> FindStoreById(int StoreId)
        {
            var findStore = await _storeServices.FindStore(StoreId);
            return findStore == null ? NotFound() : Ok(findStore);
        }
        [HttpPost]
        public IActionResult AddStore(AddStoreRequest addStoreRequest)
        {
            return Ok(_storeServices.AddStore(addStoreRequest).Result);
        }
        [HttpDelete("DeleteById/{StoreId}")]
        public async Task<IActionResult> DeleteStore(int StoreId)
        {

            return Ok(await _storeServices.DeleteStore(StoreId));
        }
        [HttpDelete]
        public async Task<IActionResult> EmptyStoreTable()
        {
            return Ok(await _storeServices.EmptyStoreTable());
        }
        [HttpPut("update/{StoreId}")]
        public async Task<IActionResult> UpdateStore(int StoreId, UpdateStoreRequest storeRequest)
        {
            var store = await _storeServices.UpdateStore(StoreId, storeRequest);
            return store == null ? NotFound() : Ok(store);
        }

    }
}
