using SimpleCrud.DTO.ProductDTO;
using SimpleCrud.Models;

namespace SimpleCrud.Mapper
{
    public static class ProductMapper
    {
        public static Product DTOtoProduct(this AddProductRequestDTO productDto) => new Product
        {
            ProductName = productDto.ProductName,
            ProductDescription = productDto.ProductDescription,
            Price = productDto.Price,
            StoreId = productDto.StoreId
        };
        public static AddProductResponseDTO ProductToAddProductResponseDTO(this Product Product) => new AddProductResponseDTO
        {
            Id = Product.Id,
            ProductName = Product.ProductName,
            ProductDescription = Product.ProductDescription,
            Price = Product.Price,
            StoreId = Product.StoreId
        };
        public static FindProductResponseDTO ProductToFindProductResponseDTO(this Product Product) => new FindProductResponseDTO
        {
            Id = Product.Id,
            ProductName = Product.ProductName,
            ProductDescription = Product.ProductDescription,
            Price = Product.Price
        };
        public static UpdateProductResponseDTO ProductToUpdateProductResponseDTO(  this Product product )=> new UpdateProductResponseDTO
        {
            Id = product.Id,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            Price = product.Price
        };
        public static Product UpdateProductRequestDTOToProduct (this UpdateProductRequestDTO updateProductRequestDTO)=> new Product
        {
            ProductName = updateProductRequestDTO.ProductName,
            ProductDescription = updateProductRequestDTO.ProductDescription,
            Price = updateProductRequestDTO.Price
        };
        public static Product UpdateTheProductStoreId(this Product product, int StoreId)
        {
            product.StoreId = StoreId;
            return product;
        }
    }
}
