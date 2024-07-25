using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.Entity;
using SimpleCrud.Interface.Products;

namespace SimpleCrud.Services
{
    public class ProductServices : IProductServices
    {
        #region Constructor + Local Variables
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ProductServices(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Main Methods

        #region FindProductById
        public async Task<GetProductResponse> FindProductById(int Id)=>
                    _mapper.Map<GetProductResponse>(await _context.Product
                                                                  .FindAsync(Id));
        #endregion

        #region GetAllProducts
        public async Task<List<GetProductResponse>> GetAllProducts(int page=1,int pageSize=10)=>
            (await _context.Product
                           .Skip((page-1)* pageSize)
                           .Take(pageSize)
                           .ToListAsync())
                           .Select(p => _mapper.Map<GetProductResponse>(p))
                           .ToList();
        
        #endregion

        #region AddProduct
        public async Task<AddProductResponse> AddProduct(AddProductRequest addProductRequest)
        {
            if(await _context.Store.FindAsync(addProductRequest.StoreId)==null)
                return null;
            if( addProductRequest.Name == null ||
                addProductRequest.Description == null ||
                addProductRequest.Price==0)
                return null;
            Product newProduct = _context.Product.Add(_mapper.Map<Product>(addProductRequest)).Entity;
            await _context.SaveChangesAsync();
            return _mapper.Map<AddProductResponse>(newProduct);
        }
        #endregion

        #region UpdateProduct
        public async Task<UpdateProductResponse> UpdateProduct(int Id, UpdateProductRequest updateProductRequest)
        {
            Product product = await _context.Product.FindAsync(Id);
            if (product == null)
                return null;
            product.Description = updateProductRequest.Description??product.Description;
            product.Name = updateProductRequest.Name??product.Name;
            product.Price = updateProductRequest.Price.HasValue ? updateProductRequest.Price.Value:product.Price ;
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<UpdateProductResponse>(product);
        }
        #endregion

        #region ChangeTheStoreIdOfAProduct
        public async Task<UpdateProductResponse> ChangeTheStoreIdOfAProduct(int ProductId, int StoreId)
        {
            Product product = await _context.Product.FindAsync(ProductId);
            if (product == null)
                return null;
            Store Store = await _context.Store.FindAsync(StoreId);
            if (Store == null)
                return null;
            product.StoreId = StoreId;
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<UpdateProductResponse>(product);
        }
        #endregion

        #region DeleteProduct
        public async Task<bool> DeleteProduct(int ProductId)
        {
            Product product = await _context.Product.FindAsync(ProductId);
            if (product == null)
                return false;
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #endregion


    }
}
