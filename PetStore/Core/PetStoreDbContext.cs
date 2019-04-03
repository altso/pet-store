using Microsoft.EntityFrameworkCore;

namespace PetStore.Core
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
            modelBuilder.Entity<Pet>()
                .HasDiscriminator(p => p.PetType)
                .HasValue<Cat>(nameof(Cat))
                .HasValue<Dog>(nameof(Dog));
        }
    }
}
