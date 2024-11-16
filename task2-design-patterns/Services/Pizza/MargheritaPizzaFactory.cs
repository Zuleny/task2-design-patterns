using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;
using task2_design_patterns.Models;

namespace task2_design_patterns.Services
{
    public class MargheritaPizzaFactory : PizzaFactory
    {
        private readonly DatabaseHelper DbHelper;

        public MargheritaPizzaFactory()
        {
            DbHelper = DatabaseHelper.GetInstance();
        }
        public override Pizza CreatePizza(CreatePizzaDto createPizzaDto)
        {
            var pizzaTable = DbHelper.GetTable("Pizza");
            var pizzaIngredientTable = DbHelper.GetTable("PizzaIngredient");

            var newRow = pizzaTable.NewRow();
            newRow["name"] = createPizzaDto.Name;
            newRow["price"] = createPizzaDto.Price;
            newRow["size"] = createPizzaDto.Size;
            newRow["diameter"] = createPizzaDto.Diameter;
            pizzaTable.Rows.Add(newRow);

            int pizzaId = (int)newRow["id"];

            List<PizzaIngredient> pizzaIngredients = GetPepperoniIngredients(pizzaId);

            foreach (var pizzaIngredient in pizzaIngredients)
            {
                var pizzaIngredientRow = pizzaIngredientTable.NewRow();
                pizzaIngredientRow["PizzaId"] = pizzaId;
                pizzaIngredientRow["IngredientId"] = pizzaIngredient.IngredientId;
                pizzaIngredientRow["quantity"] = pizzaIngredient.Quantity;
                pizzaIngredientTable.Rows.Add(pizzaIngredientRow);
            }

            return new Pizza(pizzaId, newRow["name"].ToString(), (decimal)newRow["price"], newRow["size"].ToString(), (double)newRow["diameter"]);
        }

        private List<PizzaIngredient> GetPepperoniIngredients(int pizzaId)
        {
            List<PizzaIngredient> pizzaIngredients = new List<PizzaIngredient>();
            for (int i = 1; i < 5; i++)
            {
                pizzaIngredients.Add(new PizzaIngredient(pizzaId, i, 1));
            }

            return pizzaIngredients;
        }
    }
}
