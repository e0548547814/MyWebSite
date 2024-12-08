using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository categoryRepository;



        public async Task<List<Category>> GetAllCategories()
        {
            return await categoryRepository.GetAllCategories();
        }

    }
}

