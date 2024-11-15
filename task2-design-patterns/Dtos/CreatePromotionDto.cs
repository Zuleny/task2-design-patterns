using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Dtos
{
    public class CreatePromotionDto
    {
        public string Name { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }
        public string State { get; set; }
    }
}
