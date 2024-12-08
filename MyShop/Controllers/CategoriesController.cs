using Microsoft.AspNetCore.Mvc;
using service;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService CategoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await CategoryService.GetAllCategories();
        }


    }
}
