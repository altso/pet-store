using Microsoft.EntityFrameworkCore;
using PetStore.Core;

namespace PetStore.DataAccess
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PetConfiguration());
        }
    }
}
