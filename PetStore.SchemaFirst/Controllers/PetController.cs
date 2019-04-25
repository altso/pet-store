using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.Core;
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

        public override async Task<ActionResult<ICollection<PetViewModel>>> GetPets(CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetPets();
            return _mapper.Map<List<PetViewModel>>(pets);
        }

        public override async Task<ActionResult<PetViewModel>> GetPet(int id, CancellationToken cancellationToken)
        {
            Pet pet = await _petRepository.GetPet(id);

            if (pet == null)
            {
                return NotFound();
            }

            return _mapper.Map<PetViewModel>(pet);
        }

        public override async Task<IActionResult> PutPet(int id, PetViewModel pet, CancellationToken cancellationToken)
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

        public override async Task<ActionResult<PetViewModel>> PostPet(PetViewModel pet, CancellationToken cancellationToken)
        {
            Pet createdPet = await _petRepository.CreatePet(_mapper.Map<Pet>(pet));
            return CreatedAtAction("GetPet", new { id = pet.Id }, _mapper.Map<PetViewModel>(createdPet));
        }

        public override async Task<ActionResult<PetViewModel>> DeletePet(int id, CancellationToken cancellationToken)
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