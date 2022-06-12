using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Domain.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; } = string.Empty;   
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
