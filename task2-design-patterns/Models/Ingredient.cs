using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        // Relación con PizzaIngredient (un ingrediente puede estar en múltiples pizzas)
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
