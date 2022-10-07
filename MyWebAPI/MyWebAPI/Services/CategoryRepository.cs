using MyWebAPI.Data;
using MyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly MyDbContext _dbContext;
        public CategoryRepository(MyDbContext context)
        {
            _dbContext = context;
        }
        public CategoryVM Add(CategoryModel category)
        {
            var _category = new Category
            {
                CategoryName = category.CategoryName
            };
            _dbContext.Add(_category);
            _dbContext.SaveChanges();
            return new CategoryVM
            {
                CategoryId = _category.CategoryId,
                CategoryName = category.CategoryName,
            };
        }

        public void Delete(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category != null)
            {
                _dbContext.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var list = _dbContext.Categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            });
            return list.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                return new CategoryVM 
                { 
                    CategoryId = category.CategoryId, 
                    CategoryName = category.CategoryName 
                };
            }
            return null;
        }

        public void Update(CategoryVM category)
        {
            var _category = _dbContext.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            _category.CategoryName = category.CategoryName;
            _dbContext.SaveChanges();
        }
    }
}
