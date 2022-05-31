using Vasilek.Web.Models;
using Vasilek.Web.Models.ShoppingCartAPI;

namespace Vasilek.Web.Services.IServices
{
    public interface IShoppingCartService
    {
        Task<T> GetCartByUserIdAsnyc<T>(string userId, string? token = null);
        Task<T> AddToCartAsync<T>(CartDtoBase cartDto, string? token = null);
        Task<T> UpdateCartAsync<T>(CartDtoBase cartDto, string? token = null);
        Task<T> RemoveFromCartAsync<T>(int cartId, string? token = null);
        Task<T> ApplyCoupon<T>(CartDtoBase cartDto, string? token = null);
        Task<T> RemoveCoupon<T>(string userId, string? token = null);
        Task<T> Checkout<T>(CartHeaderDtoBase cartHeader, string? token = null);
    }
}
