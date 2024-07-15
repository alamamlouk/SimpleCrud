using SimpleCrud.DTO.StoreDTO;

namespace SimpleCrud.Interface.Store
{
    public interface IStoreServices
    {
        public Task<FindStoreResponseDTO> FindStore(int StoreId);
        public  Task<List<FindStoreResponseDTO>> GetAllStores();
        public  Task<AddStoreResponseDTO> AddStore(AddStoreRequestDTO addStoreRequestDTO);
        public Task<UpdateStoreResponseDTO> UpdateStore(int StoreId, UpdateStoreRequestDTO UpdateStoreRequestDTO);
        public Task DeleteStore(int StoreId);
        public Task EmptyStoreTable();



    }
}
