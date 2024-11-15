using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Dtos
{
    public class CreatePizzaDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public double Diameter { get; set; }
        public List<PizzaIngredientDto> PizzaIngredientDto { get; set; }
    }
}
