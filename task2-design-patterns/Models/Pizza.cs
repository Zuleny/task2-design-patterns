using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public double Diameter { get; set; }

        // Relación con PizzaIngredient (una Pizza puede tener múltiples ingredientes)
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }

        // Relación con PizzaOrder (una Pizza puede estar en muchos pedidos)
        public ICollection<PizzaOrder> PizzaOrders { get; set; }
    }
}
