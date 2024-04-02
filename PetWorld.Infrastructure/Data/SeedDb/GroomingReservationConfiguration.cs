using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class GroomingReservationConfiguration : IEntityTypeConfiguration<GroomingReservation>
    {
        public void Configure(EntityTypeBuilder<GroomingReservation> builder)
        {
            var data = new SeedData();

            builder.HasData(new GroomingReservation[] { data.FirstGroomingReservation, data.SecondGroomingReservation });
        }
    }
}
