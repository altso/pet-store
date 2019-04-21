using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetStore.Core;

namespace PetStore.DataAccess
{
    public class PetRepository : IPetRepository
    {
        private readonly PetStoreDbContext _dbContext;

        public PetRepository(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Pet>> GetPets()
        {
            return _dbContext.Pets.AsNoTracking().ToListAsync();
        }

        public Task<Pet> GetPet(int id)
        {
            return _dbContext.Pets.FindAsync(id);
        }

        public async Task<Pet> CreatePet(Pet pet)
        {
            _dbContext.Pets.Add(pet);
            await _dbContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            _dbContext.Entry(pet).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
                return pet;
            }
            catch (DbUpdateConcurrencyException)
            {
                pet = await GetPet(pet.Id);
                if (pet == null)
                {
                    return null;
                }

                throw;
            }
        }

        public async Task<Pet> DeletePet(int id)
        {
            Pet pet = await _dbContext.Pets.FindAsync(id);
            if (pet != null)
            {
                _dbContext.Pets.Remove(pet);
                await _dbContext.SaveChangesAsync();
                return pet;
            }

            return null;
        }
    }
}