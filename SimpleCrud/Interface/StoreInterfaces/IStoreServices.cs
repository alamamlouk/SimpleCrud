using SimpleCrud.DTOs;
using SimpleCrud.DTOs.StoreDTOs;

namespace SimpleCrud.Interface.Store
{
    public interface IStoreServices
    {
        public Task<GetStoreResponse> FindStore(int StoreId);
        public Task<List<GetStoreResponse>> GetAllStores();
        public Task<AddStoreResponse> AddStore(AddStoreRequest storeRequest);
        public Task<UpdateStoreResponse> UpdateStore(int StoreId,UpdateStoreRequest UpdateStoreRequest);
        public Task<string> DeleteStore(int StoreId);
        public Task<string> EmptyStoreTable();



    }
}
