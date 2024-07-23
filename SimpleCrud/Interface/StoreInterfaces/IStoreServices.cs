using SimpleCrud.DTOs;
using SimpleCrud.DTOs.StoreDTOs;

namespace SimpleCrud.Interface.Store
{
    public interface IStoreServices
    {
        public Task<GetStoreResponse> FindStore(int Id);
        public Task<List<GetStoreResponse>> GetAllStores(int page,int pageSize);
        public Task<AddStoreResponse> AddStore(AddStoreRequest storeRequest);
        public Task<UpdateStoreResponse> UpdateStore(int Id,UpdateStoreRequest UpdateStoreRequest);
        public Task<bool> DeleteStore(int Id);
        public Task<bool> EmptyStoreTable();



    }
}
