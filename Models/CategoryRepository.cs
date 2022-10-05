using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tezt.Data;
using tezt.Models;

namespace tezt.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> AllCategories => _applicationDbContext.Categories;

    }
}
