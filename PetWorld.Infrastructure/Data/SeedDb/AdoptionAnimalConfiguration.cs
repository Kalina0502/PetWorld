using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class AdoptionAnimalConfiguration : IEntityTypeConfiguration<AdoptionAnimal>
    {
        public void Configure(EntityTypeBuilder<AdoptionAnimal> builder)
        {
            builder
                .HasOne(aa => aa.Agent)
                .WithMany()
                .HasForeignKey(aa => aa.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new AdoptionAnimal[] { data.FirstAdoptionAnimal, data.SecondAdoptionAnimal });
        }
    }
}