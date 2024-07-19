namespace SimpleCrud.DTOs.ProductDTOs
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int StoreId { get; set; }
    }
}
