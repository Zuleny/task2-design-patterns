using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class OrderPromotion
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
