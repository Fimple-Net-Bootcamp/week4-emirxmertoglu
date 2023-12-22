using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Data;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FoodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllFood()
        {
            var food = _context.Foods.ToList();

            if (food == null)
                return NotFound();

            return Ok(food);
        }

        [HttpPost("{petId}")]
        public async Task<IActionResult> CreateFood(int petId, [FromBody] Food food)
        {
            if (food == null)
                return BadRequest();

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFoodByPetId), new { foodId = food.Id }, food);
        }

        [HttpGet("{petId}")]
        public IActionResult GetFoodByPetId(int petId)
        {
            var food = _context.Foods.FirstOrDefault(f => f.PetId == petId);

            if (food == null)
                return NotFound();

            return Ok(food);
        }
    }
}
