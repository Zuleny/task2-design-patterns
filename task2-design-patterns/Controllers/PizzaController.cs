using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;
using task2_design_patterns.Models;
using task2_design_patterns.Services;

namespace task2_design_patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController()
        {
            _pizzaService = new PizzaService();
        }

        [HttpPost]
        public IActionResult CreatePizza([FromBody] CreatePizzaDto pizzaDto)
        {
            try
            {
                Pizza pizza = _pizzaService.CreatePizza(pizzaDto);
                return Ok($"{pizza.ToString()} created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the pizza: {ex.Message}");
            }
        }
    }
}
