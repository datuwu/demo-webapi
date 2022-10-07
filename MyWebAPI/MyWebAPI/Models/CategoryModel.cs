using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
