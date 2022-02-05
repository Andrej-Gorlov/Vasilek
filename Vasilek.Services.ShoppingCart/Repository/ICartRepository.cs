using Vasilek.Services.ShoppingCart.Models.Dto;

namespace Vasilek.Services.ShoppingCart.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);//current data cart
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);
    }
}
