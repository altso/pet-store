using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Core;

namespace PetStore.DataAccess
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPets();

        Task<Pet> GetPet(int id);

        Task<Pet> CreatePet(Pet pet);

        Task<Pet> UpdatePet(Pet pet);

        Task<Pet> DeletePet(int id);
    }
}