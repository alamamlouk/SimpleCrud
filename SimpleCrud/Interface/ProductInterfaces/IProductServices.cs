using SimpleCrud.DTO.ProductDTO;
using SimpleCrud.Models;

namespace SimpleCrud.Interface.Products
{
    public interface IProductServices
    {
        Task<List<Product>> GetAllProducts();
        Task<AddProductResponseDTO> AddProduct(AddProductRequestDTO addProductRequestDTO);
        Task DeleteProduct(int ProductId);
        Task<FindProductResponseDTO> FindProductById(int ProductId);
        Task<UpdateProductResponseDTO> UpdateProduct(int ProductId,UpdateProductRequestDTO UpdateProductRequestDTO);
        Task<Product> UpdateTheProductStoreId(int ProductId, int StoreId);
    }
}
