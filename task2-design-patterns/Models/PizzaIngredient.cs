using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class PizzaIngredient
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Quantity { get; set; }
    }
}
