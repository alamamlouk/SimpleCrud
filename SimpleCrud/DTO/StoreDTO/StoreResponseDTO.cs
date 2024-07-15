using SimpleCrud.DTO.ProductDTO;

namespace SimpleCrud.DTO.StoreDTO
{
    public class AddStoreResponseDTO
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }


    }
    public class FindStoreResponseDTO
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
        public List<FindProductResponseDTO> Products { get; set; }
    }
    public class UpdateStoreResponseDTO
    {
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
    }
    public class FetchAllStoresResponseDTO
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
        public List<FindProductResponseDTO> Products { get ; set; }
    }

}
