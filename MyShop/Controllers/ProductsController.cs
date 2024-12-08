using Microsoft.AspNetCore.Mvc;
using service;
using Entity;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService ProductService;
        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await ProductService.GetAllProducts();
        }


    }
}
