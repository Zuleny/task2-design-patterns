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
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            try
            {
                Order order = _orderService.CreateOrder(orderDto);
                return Ok($"{order} created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the order: {ex.Message}");
            }
        }
    }
}
