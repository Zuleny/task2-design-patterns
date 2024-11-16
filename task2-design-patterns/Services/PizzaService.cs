using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;
using task2_design_patterns.Models;

namespace task2_design_patterns.Services
{
    public class PizzaService
    {
        private readonly DatabaseHelper DbHelper;

        public PizzaService()
        {
            DbHelper = DatabaseHelper.GetInstance();
        }

        public Pizza CreatePizza(CreatePizzaDto pizzaDto)
        {
            return PizzaFactory.GetPizzaFactory(pizzaDto.Type).CreatePizza(pizzaDto);
        }
    }
}
