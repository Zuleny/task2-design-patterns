using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }
        public string State { get; set; }

        // Relación con OrderPromotion (una promoción puede estar en múltiples pedidos)
        public ICollection<OrderPromotion> OrderPromotions { get; set; }
    }
}
