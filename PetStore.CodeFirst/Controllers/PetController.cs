using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.CodeFirst.Models;
using PetStore.Core;
using PetStore.DataAccess;

namespace PetStore.CodeFirst.Controllers
{
    /// <summary>
    /// Pet controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
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

        /// <summary>Gets the pets.</summary>
        /// <returns>A list of pets.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetViewModel>>> GetPets()
        {
            var pets = await _petRepository.GetPets();
            return _mapper.Map<List<PetViewModel>>(pets);
        }

        /// <summary>Gets the pet.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The pet.</returns>
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

        /// <summary>
        /// Puts the pet.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="pet">The pet.</param>
        /// <returns>The pet.</returns>
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

        /// <summary>
        /// Posts the pet.
        /// </summary>
        /// <param name="pet">The pet.</param>
        /// <returns>The pet.</returns>
        [HttpPost]
        public async Task<ActionResult<PetViewModel>> PostPet(PetViewModel pet)
        {
            Pet createdPet = await _petRepository.CreatePet(_mapper.Map<Pet>(pet));
            return CreatedAtAction("GetPet", new { id = pet.Id }, _mapper.Map<PetViewModel>(createdPet));
        }

        /// <summary>
        /// Deletes the pet.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The pet.</returns>
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
