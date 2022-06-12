using System.ComponentModel.DataAnnotations;

namespace Vasilek.Web.Models
{
    public class CategoryDtoBase
    {
        public int CategoryId { get; set; }
        [Display(Name = "Названия")]
        public string? CategoryName { get; set; } = string.Empty;
    }
}
