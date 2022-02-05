namespace Vasilek.Web.Models.ShoppingCartAPI
{
    public class CartDetailsDtoBase
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public virtual CartHeaderDtoBase? CartHeader { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDtoBase? Product { get; set; }
        public int Count { get; set; }
    }
}
