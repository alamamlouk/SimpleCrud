using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.Interface.Products;
using SimpleCrud.Models;

namespace SimpleCrud.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ProductServices(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetProductResponse>> GetAllProducts()
        {
            var products = await _context.Product.ToListAsync();
            return products.Select(p => _mapper.Map<GetProductResponse>(p)).ToList();
        }
        public async Task<AddProductResponse> AddProduct(AddProductRequest addProductRequest)
        {

            try
            {
                var newProduct = _context.Product.Add(_mapper.Map<Product>(addProductRequest));

                await _context.SaveChangesAsync();

                return _mapper.Map<AddProductResponse>(newProduct.Entity);
            }
            catch (System.Exception)
            {
                return null;
            }
            
        }

        public async Task<string> DeleteProduct(int ProductId)
        {
            var product = await _context.Product.FindAsync(ProductId);
           if (product == null)
            {
                return "Product Not Found";
            }
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            
            return "Product Deleted";
        }

        public async Task<GetProductResponse> FindProductById(int ProductId)
        {
            var product = await _context.Product.FindAsync(ProductId);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<GetProductResponse>(product);

        }

        public async Task<UpdateProductResponse> UpdateProduct(int ProductId, UpdateProductRequest updateProductRequest)
        {
            var product = await _context.Product.FindAsync(ProductId);

            if (product == null)
            {
                return null;
            }
            product = _mapper.Map<Product>(updateProductRequest);

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<UpdateProductResponse>(product);
        }

        public async Task<UpdateProductResponse> UpdateTheProductStoreId(int ProductId, int StoreId)
        {
            var product = await _context.Product.FindAsync(ProductId);
            if (product == null)
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
            return _mapper.Map<UpdateProductResponse>(product);
        }

        
    }
}
