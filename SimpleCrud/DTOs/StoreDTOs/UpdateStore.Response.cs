using SimpleCrud.DTOs.ProductDTOs;

namespace SimpleCrud.DTOs.StoreDTOs
{
    public class UpdateStoreResponse
    { 
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public List<GetProductResponse> Products { get; set; }
    }   
}
