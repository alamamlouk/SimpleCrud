using SimpleCrud.DTOs.ProductDTOs;

namespace SimpleCrud.DTOs.StoreDTOs
{
    public class GetStoreResponse
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
        public List<GetProductResponse> Products { get; set; }
    }
}
