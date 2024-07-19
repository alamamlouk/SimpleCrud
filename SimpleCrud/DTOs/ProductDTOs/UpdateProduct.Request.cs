namespace SimpleCrud.DTOs.ProductDTOs
{
    public class UpdateProductRequest
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
