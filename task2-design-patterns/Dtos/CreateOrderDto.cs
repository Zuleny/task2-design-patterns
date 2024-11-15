using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Dtos
{
    public class CreateOrderDto
    {
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public string DeliveryType { get; set; }
        public string PaymentMethod { get; set; }
        public List<PizzaOrderDto> PizzaOrderDto { get; set; }
        public List<int> PromotionIds { get; set; }
    }
}
