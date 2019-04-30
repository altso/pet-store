using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.DataAccess;
using PetStore.SchemaFirst.Generated;

namespace PetStore.SchemaFirst.Controllers
{
    public class PetController : PetControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public override async Task<ActionResult<ICollection<Pet>>> GetPets(CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetPets();
            return _mapper.Map<List<Pet>>(pets);
        }

        public override async Task<ActionResult<Pet>> GetPet(int id, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return _mapper.Map<Pet>(pet);
        }

        public override async Task<IActionResult> PutPet(int id, Pet pet, CancellationToken cancellationToken)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            Core.Pet updatedPet = await _petRepository.UpdatePet(_mapper.Map<Core.Pet>(pet));

            if (updatedPet == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        public override async Task<ActionResult<Pet>> PostPet(Pet pet, CancellationToken cancellationToken)
        {
            Core.Pet createdPet = await _petRepository.CreatePet(_mapper.Map<Core.Pet>(pet));
            return CreatedAtAction("GetPet", new { id = pet.Id }, _mapper.Map<Pet>(createdPet));
        }

        public override async Task<ActionResult<Pet>> DeletePet(int id, CancellationToken cancellationToken)
        {
            Core.Pet pet = await _petRepository.DeletePet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return _mapper.Map<Pet>(pet);
        }
    }
}