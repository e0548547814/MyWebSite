using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository

    {

        ApiOrmContext _ApiOrmContext;
        public ProductRepository(ApiOrmContext ApiOrmContext)
        {
            _ApiOrmContext = ApiOrmContext;
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _ApiOrmContext.Products.FindAsync(id);

        }



        public async Task<List<Product>> GetAllProducts()
        {
            return await _ApiOrmContext.Products.ToListAsync();

        }


    }
}

