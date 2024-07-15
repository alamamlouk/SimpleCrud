using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.DTO.ProductDTO;
using SimpleCrud.Interface.Products;
using SimpleCrud.Mapper;
using SimpleCrud.Models;

namespace SimpleCrud.Services
{
    public class ProductServices : IProductServices
    {   
        private readonly ApplicationDBContext _context;
        public ProductServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProducts()=> await _context.Product.ToListAsync();
        public async Task<AddProductResponseDTO> AddProduct(AddProductRequestDTO addProductRequestDTO){
            if( addProductRequestDTO.ProductName == null || 
                addProductRequestDTO.Price == 0 || 
                addProductRequestDTO.ProductDescription == null || 
                addProductRequestDTO.StoreId == null )
            {
                return null;
            }
            if( await _context.Store.FindAsync(addProductRequestDTO.StoreId) == null)
            {
                return null;
            }
            var newProduct = _context.Product.Add(addProductRequestDTO.DTOtoProduct());
            
            await _context.SaveChangesAsync();
           
            return newProduct.Entity.ProductToAddProductResponseDTO(); ;
        }
        
        public async Task DeleteProduct (int ProductId)
        {
            var product = await _context.Product.FindAsync(ProductId);
            if(product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FindProductResponseDTO> FindProductById(int ProductId)
        {
               var Product= await _context.Product.FindAsync(ProductId);
            if(Product == null)
                {
                     return null;
                }
            return Product.ProductToFindProductResponseDTO();
        
        }

        public async Task<UpdateProductResponseDTO> UpdateProduct(int ProductId, UpdateProductRequestDTO UpdateProductRequestDTO)
        {
            var product = await _context.Product.FindAsync(ProductId);

            if( product == null)
            {
                return null;
            }
            product.ProductName = UpdateProductRequestDTO.ProductName;
            product.ProductDescription = UpdateProductRequestDTO.ProductDescription;
            product.Price = UpdateProductRequestDTO.Price;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product.ProductToUpdateProductResponseDTO();
        }

        public async Task<Product> UpdateTheProductStoreId(int ProductId, int StoreId)
        {
            var product = await _context.Product.FindAsync(ProductId);
            if(product == null)
            {
                return null;
            }
            var Store = await _context.Store.FindAsync(StoreId);
            if (Store == null)
            {
                return null;
            }
            product.StoreId = StoreId;
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
