using SimpleCrud.Data;
using SimpleCrud.Models;

namespace SimpleCrud.Services
{
    public class ProductServices
    {   
        private readonly ApplicationDBContext _context;
        public ProductServices(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<Product> getAllProducts()=>_context.Product.ToList();

        //ADd Product
        // Update Product
        // Delete Product
        // Get Product
        // get all products

    }
}
