using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Domain.Entity.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Укажите название категории.")]
        public string? CategoryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
