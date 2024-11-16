using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;
using task2_design_patterns.Models;

namespace task2_design_patterns.Services
{
    public abstract class PizzaFactory
    {
        public static PizzaFactory GetPizzaFactory(string type)
        {
            Dictionary<string, PizzaFactory> pizzas = new Dictionary<string, PizzaFactory>
            {
                { "Personalizada", new CustomPizzaFactory() },
                { "Peperoni", new PepperoniPizzaFactory() },
                { "Margarita", new MargheritaPizzaFactory() }
            };

            if (pizzas.TryGetValue(type, out PizzaFactory pizzaFactory))
            {
                return pizzaFactory;
            }

            return pizzas["Personalizada"];

        }
        public abstract Pizza CreatePizza(CreatePizzaDto createPizzaDto);
    }
}
