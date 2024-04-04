using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class GenderTypeConfiguration : IEntityTypeConfiguration<GenderType>
    {
        public void Configure(EntityTypeBuilder<GenderType> builder)
        {
            var data = new SeedData();

            builder.HasData(new GenderType[] { data.MaleGender, data.FemaleGender, data.OtherGender });
        }
    }
}