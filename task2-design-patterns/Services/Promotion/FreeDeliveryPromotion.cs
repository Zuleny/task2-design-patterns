using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;

namespace task2_design_patterns.Services
{
    public class FreeDeliveryPromotion : IPromotionStrategy
    {
        public decimal ApplyPromotion(CreateOrderDto order, decimal basePrice)
        {
            decimal deliveryFee = 0;
            return basePrice + deliveryFee;
        }
    }
}
