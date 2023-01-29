using System.ComponentModel.DataAnnotations;

namespace Vasilek.Web.Models.VM
{
    public class ProductDtoVM
    {
        public List<ProductDtoBase>? Products { get; set; }
        public ProductDtoBase? Product { get; set; }
    }
}
