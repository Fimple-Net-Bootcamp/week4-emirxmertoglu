using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Data;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class HealthStatusController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HealthStatusController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{petId}")]
        public IActionResult GetHealthStatusByPetId(int petId)
        {
            var healthStatus = _context.HealthStatuses.FirstOrDefault(h => h.PetId == petId);

            if (healthStatus == null)
                return NotFound();

            return Ok(healthStatus);
        }

        [HttpPatch("{petId}")]
        public async Task<IActionResult> UpdateHealthStatus(int petId, [FromBody] HealthStatus healthStatus)
        {
            if (healthStatus == null || healthStatus.PetId != petId)
                return BadRequest();

            var healthStatusToUpdate = _context.HealthStatuses.FirstOrDefault(h => h.PetId == petId);

            if (healthStatusToUpdate == null)
                return NotFound();

            healthStatusToUpdate.Name = healthStatus.Name;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
