using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public string DeliveryType { get; set; }
        public string PaymentMethod { get; set; }

        // Relación con PizzaOrder (un pedido puede tener múltiples pizzas)
        public ICollection<PizzaOrder> PizzaOrders { get; set; }

        // Relación con Delivery (un pedido tiene una entrega)
        public Delivery Delivery { get; set; }

        // Relación con OrderPromotion (un pedido puede tener múltiples promociones)
        public ICollection<OrderPromotion> OrderPromotions { get; set; }
    }
}
