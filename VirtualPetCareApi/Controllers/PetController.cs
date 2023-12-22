using Microsoft.AspNetCore.Mvc;
using VirtualPetCareApi.Data;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class PetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet([FromBody] Pet pet)
        {
            if (pet == null)
                return BadRequest();

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPetById), new { petId = pet.Id }, pet);
        }

        [HttpGet]
        public IActionResult GetAllPets()
        {
            var pets = _context.Pets.ToList();

            if (pets == null)
                return NotFound();

            return Ok(pets);
        }

        [HttpGet("{petId}")]
        public IActionResult GetPetById(int petId)
        {
            var pet = _context.Pets.FirstOrDefault(u => u.Id == petId);

            if (pet == null)
                return NotFound();

            return Ok(pet);
        }

        [HttpPut("{petId}")]
        public async Task<IActionResult> UpdatePet(int petId, [FromBody] Pet pet)
        {
            if (pet == null || pet.Id != petId)
                return BadRequest();

            var petToUpdate = _context.Pets.FirstOrDefault(u => u.Id == petId);

            if (petToUpdate == null)
                return NotFound();

            petToUpdate.Name = pet.Name;
            petToUpdate.UserId = pet.UserId;
            petToUpdate.HealthStatus = pet.HealthStatus;

            await _context.SaveChangesAsync();

            return Ok(petToUpdate);
        }
    }
}
