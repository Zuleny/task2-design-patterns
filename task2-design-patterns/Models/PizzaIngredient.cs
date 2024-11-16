using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2_design_patterns.Models
{
    public class PizzaIngredient
    {
        public PizzaIngredient(int PizzaId, int IngredientId, int Quantity)
        {
            this.PizzaId = PizzaId;
            this.IngredientId = IngredientId;
            this.Quantity = Quantity;
        }
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
    }
}
