using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vasilek.Services.ShoppingCart.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]// PK in not auto generation
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; } = string.Empty;
        [Range(1, 100000)]
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
