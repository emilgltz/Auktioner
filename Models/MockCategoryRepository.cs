using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace tezt.Models
{
    public class MockCategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Transport", Description="Cars etc"},
                new Category{CategoryId=2, CategoryName="Decoration", Description="Arts etc"},
                new Category{CategoryId=3, CategoryName="HouseHold", Description="Chairs etc"}
            };
    }
}
