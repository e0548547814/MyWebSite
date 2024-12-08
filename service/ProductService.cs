using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace service
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }

    }

}
