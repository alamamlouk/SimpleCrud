using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.Models;

namespace SimpleCrud.Interface.Products
{
    public interface IProductServices
    {
        Task<List<GetProductResponse>> GetAllProducts();
        Task<AddProductResponse> AddProduct(AddProductRequest addProductRequest);
        Task<string> DeleteProduct(int ProductId);
        Task<GetProductResponse> FindProductById(int ProductId);
        Task<UpdateProductResponse> UpdateProduct(int ProductId, UpdateProductRequest UpdateProductRequestDTO);
        Task<UpdateProductResponse> UpdateTheProductStoreId(int ProductId, int StoreId);
    }
}
