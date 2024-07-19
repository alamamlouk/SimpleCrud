namespace SimpleCrud.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; } 
        public decimal Price { get; set; }
        public int StoreId { get; set; }
        public Store? Store { get; set; }
    }
}
