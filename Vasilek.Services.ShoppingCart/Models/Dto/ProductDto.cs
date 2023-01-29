

namespace Vasilek.Services.ShoppingCart.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }


        public string Name { get; set; } = string.Empty;


        public double Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }


        public CategoryDto? Category { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
