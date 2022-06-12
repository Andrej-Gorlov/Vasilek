using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Domain.Entity.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Укажите название продукта.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 1000000, ErrorMessage = "Цена не может быть меньше 1 и больше 1 000 000.")]
        public double Price { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите название категории.")]
        public CategoryDto? Category { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
