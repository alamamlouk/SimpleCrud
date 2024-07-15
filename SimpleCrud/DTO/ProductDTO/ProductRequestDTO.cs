namespace SimpleCrud.DTO.ProductDTO
{
    public class AddProductRequestDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int? StoreId { get; set; }
    }
    public class UpdateProductRequestDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int? StoreId { get; set; }
    }

}
