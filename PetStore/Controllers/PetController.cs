using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Core;
using PetStore.DataAccess;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _petRepository.GetPets();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            Pet pet = await _petRepository.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pet>> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            pet = await _petRepository.UpdatePet(pet);

            if (pet == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            await _petRepository.CreatePet(pet);
            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> DeletePet(int id)
        {
            Pet pet = await _petRepository.DeletePet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }
    }
}
