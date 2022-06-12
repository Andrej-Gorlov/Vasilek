using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Domain.Entity.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Укажите название категории.")]
        public string? CategoryName { get; set; } = string.Empty;
    }
}
