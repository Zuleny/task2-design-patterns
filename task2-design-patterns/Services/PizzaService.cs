using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;

namespace task2_design_patterns.Services
{
    public class PizzaService
    {
        private readonly DatabaseHelper DbHelper;

        public PizzaService()
        {
            DbHelper = DatabaseHelper.GetInstance();
        }

        public int CreatePizza(CreatePizzaDto pizzaDto)
        {
            var pizzaTable = DbHelper.GetTable("Pizza");
            var pizzaIngredientTable = DbHelper.GetTable("PizzaIngredient");

            var newRow = pizzaTable.NewRow();
            newRow["name"] = pizzaDto.Name;
            newRow["price"] = pizzaDto.Price;
            newRow["size"] = pizzaDto.Size;
            newRow["diameter"] = pizzaDto.Diameter;
            pizzaTable.Rows.Add(newRow);

            int pizzaId = (int)newRow["id"];

            foreach (var pizzaIngredient in pizzaDto.PizzaIngredientDto)
            {
                var pizzaIngredientRow = pizzaIngredientTable.NewRow();
                pizzaIngredientRow["PizzaId"] = pizzaId;
                pizzaIngredientRow["IngredientId"] = pizzaIngredient.IngredientId;
                pizzaIngredientRow["quantity"] = pizzaIngredient.Quantity;
                pizzaIngredientTable.Rows.Add(pizzaIngredientRow);
            }

            return pizzaId;
        }
    }
}
