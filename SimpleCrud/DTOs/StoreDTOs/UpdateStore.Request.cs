using System.Security.Cryptography.X509Certificates;

namespace SimpleCrud.DTOs.StoreDTOs
{
    public class UpdateStoreRequest
    {
        public string? Name { get; set; }
        public string? Owner { get; set; }

    }
}
