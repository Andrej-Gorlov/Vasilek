﻿using System.ComponentModel.DataAnnotations;

namespace Vasilek.Services.ShoppingCart.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
