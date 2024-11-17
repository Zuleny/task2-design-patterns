using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;

namespace task2_design_patterns.Services
{
    public class TwoForOnePromotion : IPromotionStrategy
    {
        public decimal ApplyPromotion(CreateOrderDto order, decimal basePrice)
        {
            int totalPizzas = order.PizzaOrderDto.Count;
            int pizzasToPay = totalPizzas / 2 + totalPizzas % 2;
            return pizzasToPay * basePrice;
        }
    }
}
