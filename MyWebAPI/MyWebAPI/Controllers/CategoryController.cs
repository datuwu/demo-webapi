using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Data;
using MyWebAPI.Models;
using System.Linq;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        public CategoryController(MyDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _dbContext.Categories.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var category = _dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName,
                };
                _dbContext.Add(category);
                _dbContext.SaveChanges();

                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditById(int id, CategoryModel model)
        {
            try
            {
                var category = _dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return NotFound();
                }
                category.CategoryName = model.CategoryName;
                _dbContext.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                var category = _dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return NotFound();
                }
                
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
