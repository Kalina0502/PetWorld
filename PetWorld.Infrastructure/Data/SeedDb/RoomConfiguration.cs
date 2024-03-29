using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            var data = new SeedData();

            builder.HasData(new Room[] { data.DogRooms, data.CatRooms, data.BirdRooms });
        }
    }
}