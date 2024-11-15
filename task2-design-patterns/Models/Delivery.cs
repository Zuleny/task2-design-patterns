using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
