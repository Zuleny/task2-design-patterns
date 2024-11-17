using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Services
{
    public class PromotionStrategyFactory
    {
        public static IPromotionStrategy GetStrategy(int promotionId)
        {
            return promotionId switch
            {
                1 => new TwoForOnePromotion(),    // Promoción "2x1"
                2 => new FreeDeliveryPromotion(), // Promoción "Delivery Gratis"
                _ => throw new ArgumentException($"No strategy found for promotion ID: {promotionId}")
            };
        }
    }
}
