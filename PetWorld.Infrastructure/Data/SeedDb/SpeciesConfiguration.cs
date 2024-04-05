using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            var data = new SeedData();

            builder.HasData(new Species[] { data.DogSpecies, data.CatSpecies, data.BirdSpecies, data.HorseSpecies });
        }
    }
}