using MyWebAPI.Data;
using MyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPI.Services
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> categories = new List<CategoryVM>
        {
            new CategoryVM {CategoryId = 1, CategoryName = "TV"},
            new CategoryVM {CategoryId = 2, CategoryName = "Smartphone"},
            new CategoryVM {CategoryId = 3, CategoryName = "Gia dung"},
            new CategoryVM {CategoryId = 4, CategoryName = "May lanh"}
        };
        public CategoryVM Add(CategoryModel category)
        {
            var _category = new CategoryVM
            {
                CategoryId = categories.Max(c => c.CategoryId) + 1,
                CategoryName = category.CategoryName
            };
            categories.Add(_category);
            return _category;
        }

        public void Delete(int id)
        {
            var _category = categories.SingleOrDefault(c => c.CategoryId == id);

            categories.Remove(_category);
        }

        public List<CategoryVM> GetAll()
        {
            return categories;
        }

        public CategoryVM GetById(int id)
        {
            return categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public void Update(CategoryVM category)
        {
            var _category = categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
            }
        }
    }
}
