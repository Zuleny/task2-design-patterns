using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;

namespace task2_design_patterns.Services.Promotion
{
    public class PromotionContext
    {
        private readonly IPromotionStrategy _strategy;

        public PromotionContext(IPromotionStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal ApplyPromotion(CreateOrderDto order, decimal basePrice)
        {
            return _strategy.ApplyPromotion(order, basePrice);
        }
    }
}
