namespace Vasilek.Web.Models.CouponAPI
{
    public class CouponDtoBase
    {
        public int CouponId { get; set; }
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
