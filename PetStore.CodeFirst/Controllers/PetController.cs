using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.CodeFirst.Models;
using PetStore.Core;
using PetStore.DataAccess;

namespace PetStore.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetViewModel>>> GetPets()
        {
            var pets = await _petRepository.GetPets();
            return _mapper.Map<List<PetViewModel>>(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetViewModel>> GetPet(int id)
        {
            Pet pet = await _petRepository.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return _mapper.Map<PetViewModel>(pet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PetViewModel>> PutPet(int id, PetViewModel pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            Pet updatedPet = await _petRepository.UpdatePet(_mapper.Map<Pet>(pet));

            if (updatedPet == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PetViewModel>> PostPet(PetViewModel pet)
        {
            await _petRepository.CreatePet(_mapper.Map<Pet>(pet));
            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PetViewModel>> DeletePet(int id)
        {
            Pet pet = await _petRepository.DeletePet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return _mapper.Map<PetViewModel>(pet);
        }
    }
}
