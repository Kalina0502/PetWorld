using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
               .HasOne(p => p.Gender)
               .WithMany()
               .HasForeignKey(p => p.GenderId)
               .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Pet[] { data.Dog, data.Cat, data.Bird });
        }
    }
}