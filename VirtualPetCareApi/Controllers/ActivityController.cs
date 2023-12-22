using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Data;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class ActivityController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ActivityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            if (activity == null)
                return BadRequest();

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivityByPetId), new { activityId = activity.Id }, activity);
        }

        [HttpGet("{petId}")]
        public IActionResult GetActivityByPetId(int petId)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.PetId == petId);

            if (activity == null)
                return NotFound();

            return Ok(activity);
        }
    }
}
