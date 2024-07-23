using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Data;
using SimpleCrud.DTOs;
using SimpleCrud.DTOs.StoreDTOs;
using SimpleCrud.Entity;
using SimpleCrud.Services;

namespace SimpleCrud.Controllers
{
    [Route("api/store")]
    [ApiController]
    public partial class StoreController : ControllerBase
    {
        #region Local Variables + Constructor
        private readonly StoreServices _storeServices;
        public StoreController(ApplicationDBContext context, IMapper mapper)
        {
            _storeServices = new StoreServices(context, mapper);
        }
        #endregion

        #region Main Methods

        #region FetchAllStores
        [HttpGet]
        public async Task<IActionResult> FetchAllStores(int page,int pageSize)=> Ok(await _storeServices.GetAllStores(page,pageSize));
        
        #endregion

        #region FindStoreById
        [HttpGet("{StoreId}")]
        public async Task<IActionResult> FindStoreById(int StoreId)
        {
            GetStoreResponse findStore = await _storeServices.FindStore(StoreId);
            return findStore == null ? NotFound() : Ok(findStore);
        }
        #endregion

        #region AddStore
        [HttpPost]
        public async Task<IActionResult>  AddStore(AddStoreRequest addStoreRequest)
        {
            AddStoreResponse addStoreResponse= await _storeServices.AddStore(addStoreRequest);
            return addStoreResponse == null? StatusCode(500,"couldn't add the product"):Ok( addStoreResponse);
        }
        #endregion

        #region UpdateStore

        [HttpPut("{StoreId}")]
        public async Task<IActionResult> UpdateStore(int StoreId, UpdateStoreRequest storeRequest)
        {
            UpdateStoreResponse store = await _storeServices.UpdateStore(StoreId, storeRequest);
            return store == null ? BadRequest("couldn't update the store") : Ok(store);
        }

        #endregion

        #region DeleteStore
        [HttpDelete("{StoreId}")]
        public async Task<IActionResult> DeleteStore(int StoreId)=> 
            await _storeServices.DeleteStore(StoreId) ?
            Ok(" Store deleted ") :
            NotFound(" Couldn't delete the store ");
        
        #endregion

        #region EmptyStoreTable
        [HttpDelete("all")]
        public async Task<IActionResult> EmptyStoreTable()=> 
            await _storeServices.EmptyStoreTable() ?
            Ok("Empty table successful   ") :
            NotFound("Couldn't empty the table");
        
        #endregion

        #endregion
     

    }
}
