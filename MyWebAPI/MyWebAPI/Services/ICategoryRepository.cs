using MyWebAPI.Data;
using MyWebAPI.Models;
using System.Collections.Generic;

namespace MyWebAPI.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Add(CategoryModel category);
        void Update(CategoryVM category);
        void Delete(int id);
    }
}
