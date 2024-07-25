using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Data;
using SimpleCrud.DTOs.ProductDTOs;
using SimpleCrud.Services;
namespace SimpleCrud.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        #region Local Variables + Constructor
        private readonly ProductServices _productServices;
        public ProductControllers(ApplicationDBContext context, IMapper mapper)
        {
            _productServices = new ProductServices(context, mapper);
            
        }
        #endregion

        #region Main Methods

        #region fetchAllProducts
        [HttpGet]
        public async Task<IActionResult> FetchAllProducts(int page ,int pageSize) => Ok(await _productServices.GetAllProducts(page,pageSize));
        #endregion

        #region FindProductById
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> FindProductById(int ProductId)
        {
            GetProductResponse product = await _productServices.FindProductById(ProductId);
            return product == null ? NotFound("Product not found") : Ok(product);
        }
        #endregion

        #region AddProduct
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest)
        {
            AddProductResponse createdProduct = await _productServices.AddProduct(addProductRequest);
            return createdProduct == null ? NotFound("Couldn't add the product") : Ok(createdProduct);
        }
        #endregion

        #region UpdateProduct 
        [HttpPut("{ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, UpdateProductRequest UpdateProductRequestDTO)
        {
            UpdateProductResponse product = await _productServices.UpdateProduct(ProductId, UpdateProductRequestDTO);
            return product == null ? NotFound() : Ok(product);
        }
        #endregion

        #region UpdateTheProductStoreId
        [HttpPatch("{ProductId}")]
        public async Task<IActionResult> UpdateTheProductStoreId(int ProductId, int StoreId)
        {
            UpdateProductResponse product = await _productServices.ChangeTheStoreIdOfAProduct(ProductId, StoreId);
            return product == null ? NotFound() : Ok(product);
        }
        #endregion

        #region DeleteProduct 
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)=> 
            await _productServices.DeleteProduct(ProductId) ?
            Ok("Product Deleted") :
            NotFound("couldn't delete the product");
        
        #endregion
        #endregion 

          
    }
}
