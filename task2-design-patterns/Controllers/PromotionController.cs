using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2_design_patterns.Dtos;
using task2_design_patterns.Services;

namespace task2_design_patterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionService;

        public PromotionController()
        {
            _promotionService = new PromotionService();
        }

        [HttpPost]
        public IActionResult CreatePromotion([FromBody] CreatePromotionDto promotionDto)
        {
            try
            {
                int promotionId = _promotionService.CreatePromotion(promotionDto);
                return Ok($"Promotion {promotionId} created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the promotion: {ex.Message}");
            }
        }

    }
}
