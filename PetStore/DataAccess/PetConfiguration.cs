using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Core;

namespace PetStore.DataAccess
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasDiscriminator(p => p.PetType)
                .HasValue<Cat>(nameof(Cat))
                .HasValue<Dog>(nameof(Dog));
            builder.Property(p => p.DateOfBirth).HasColumnType("DATE");
            builder.HasData(PetGenerator.GeneratePets());
        }
    }
}