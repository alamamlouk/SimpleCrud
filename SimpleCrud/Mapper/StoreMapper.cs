using SimpleCrud.DTO.StoreDTO;
using SimpleCrud.Models;

namespace SimpleCrud.Mapper
{
    public static class StoreMapper
    {
        public static Store DTOtoStore(this AddStoreRequestDTO storeDto) => new Store
        {
            StoreName = storeDto.StoreName,
            StoreOwner = storeDto.StoreOwner
        };
        public static AddStoreResponseDTO AddStoreToDTO(this Store store) => new AddStoreResponseDTO
        {
            Id = store.Id,
            StoreName = store.StoreName,
            StoreOwner = store.StoreOwner
        };
        public static FindStoreResponseDTO FindStoreToDTO(this Store store) => new FindStoreResponseDTO
        {   
            Id = store.Id,
            StoreName = store.StoreName,
            StoreOwner = store.StoreOwner,
            Products = store.Products.Select(p => p.ProductToFindProductResponseDTO()).ToList()
        };
        public static UpdateStoreResponseDTO StoreToUpdateStoreResponseDTO(this Store storeDto) => new UpdateStoreResponseDTO
        {
            StoreName = storeDto.StoreName,
            StoreOwner = storeDto.StoreOwner
        };
        public static Store UpdateStoreRequestDTOToStore (this UpdateStoreRequestDTO UpdateStoreRequestDTO)=> new Store
        {
           
            StoreName = UpdateStoreRequestDTO.StoreName,
            StoreOwner = UpdateStoreRequestDTO.StoreOwner
        };


    }
}
