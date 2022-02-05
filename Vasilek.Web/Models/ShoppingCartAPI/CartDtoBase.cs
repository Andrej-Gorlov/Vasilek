namespace Vasilek.Web.Models.ShoppingCartAPI
{
    public class CartDtoBase
    {
        public CartHeaderDtoBase? CartHeader { get; set; }
        public IEnumerable<CartDetailsDtoBase>? CartDetails { get; set; }
    }
}
