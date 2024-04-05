using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class GroomingTypeConfiguration : IEntityTypeConfiguration<GroomingType>
    {
        public void Configure(EntityTypeBuilder<GroomingType> builder)
        {
            var data = new SeedData();

            builder.HasData(new GroomingType[] { data.FirstGroomingType, data.SecondGroomingType, data.ThirdGroomingType });
        }
    }
}
