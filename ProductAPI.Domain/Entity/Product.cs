using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Domain.Entity
{
    public class Product
    {
        [Key]
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
