namespace SimpleCrud.DTO.StoreDTO
{
    public class AddStoreRequestDTO
    {
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
    }
    public class UpdateStoreRequestDTO
    {
        public string StoreName { get; set; }
        public string StoreOwner { get; set; }
    }
    public class DeletedStoreRequestDTO
    {
        public int Id { get; set; }
    }
    public class FindStoreRequestDTO
    {
        public int Id { get; set; }
    }
}
