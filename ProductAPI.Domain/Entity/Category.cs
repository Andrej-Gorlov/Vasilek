using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Domain.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string? CategoryName { get; set; } = string.Empty;
    }
}
