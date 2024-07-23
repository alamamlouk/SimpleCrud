using SimpleCrud.DTOs.ProductDTOs;

namespace SimpleCrud.Interface.Products
{
    public interface IProductServices
    {
        Task<List<GetProductResponse>> GetAllProducts(int page,int pageSize);
        Task<GetProductResponse> FindProductById(int Id);
        Task<AddProductResponse> AddProduct(AddProductRequest addProductRequest);
        Task<UpdateProductResponse> UpdateProduct(int Id, UpdateProductRequest UpdateProductRequestDTO);
        Task<UpdateProductResponse> ChangeTheStoreIdOfAProduct(int ProductId, int StoreId);
        Task<bool> DeleteProduct(int Id);

    }
}
