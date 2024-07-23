namespace SimpleCrud.Entity
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public List<Product> Products { get; set; }
    }
}
