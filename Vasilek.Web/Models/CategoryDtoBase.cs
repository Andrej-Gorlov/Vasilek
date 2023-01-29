using System.ComponentModel.DataAnnotations;

namespace Vasilek.Web.Models
{
    public class CategoryDtoBase
    {
        public int CategoryId { get; set; }
        [Display(Name = "Название")]
        public string? CategoryName { get; set; } = string.Empty;
        [Display(Name = "Url Изображения")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
