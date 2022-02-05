using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vasilek.Services.ShoppingCart.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]// PK in not auto generation
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(1, 100000)]
        public double Price { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
