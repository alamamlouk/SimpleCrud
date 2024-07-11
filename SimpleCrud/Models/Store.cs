namespace SimpleCrud.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string StoreOwner { get; set; } = string.Empty;
        public List< Product> Products { get; set; } = new List< Product>();
    }
}
