using System.ComponentModel.DataAnnotations;

namespace Vasilek.Web.Models
{
    public class ProductDtoBase
    {
        public ProductDtoBase()
        {
            Count = 1;
        }
        public int ProductId { get; set; }
        [Display(Name = "Названия")]
        public string? Name { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public CategoryDtoBase? Category { get; set; }
        [Display(Name = "Url Изображения")]
        public string? ImageUrl { get; set; }
        [Range(1, 100)]
        public int Count { get; set; }
    }
}
