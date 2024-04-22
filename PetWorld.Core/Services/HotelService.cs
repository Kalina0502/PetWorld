using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Hotel;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;
using System.Reflection.Metadata;

namespace PetWorld.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository repository;

        public HotelService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<RoomTypeServiceModel>> AllRoomTypesAsync()
        {
            return await repository.AllReadOnly<RoomType>()
                 .Select(c => new RoomTypeServiceModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllRoomTypeNamesAsync()
        {
            return await repository.AllReadOnly<RoomType>()
                .Select(rt => rt.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<HotelRoomServiceModel?> AllAsync(
      string? roomType = null,
      DateTime? checkInDate = null,
      DateTime? checkOutDate = null)
        {
            checkInDate ??= DateTime.Today;
            checkOutDate ??= DateTime.Today;

            var hotelRoomsToShow = repository.AllReadOnly<Room>();

            // Филтриране на стаите по тип, ако е зададен roomType
            if (roomType != null)
            {
                hotelRoomsToShow = hotelRoomsToShow
                    .Where(hr => hr.RoomType.Name == roomType);
            }

            // Проверка за наличност и вземане на първата свободна стая
            var availableRoom = await hotelRoomsToShow
                .Where(r => !repository.AllReadOnly<RoomReservation>()
                    .Any(rr => rr.RoomId == r.Id &&
                        (rr.CheckInDate <= checkOutDate.Value) && (rr.CheckOutDate >= checkInDate.Value)))
                .Select(hr => new HotelRoomServiceModel
                {
                    Id = hr.Id,
                    RoomTypeId = hr.RoomTypeId,
                    IsAvailable = hr.IsAvailable
                })
                .FirstOrDefaultAsync(); // Взимаме първата налична стая

            return availableRoom;
        }


        public async Task ReserveRoomAsync(int roomId,
         DateTime checkInDate, DateTime checkOutDate,
         bool includesFood, bool includesWalk)
        {
            var reservation = new RoomReservation
            {
                RoomId = roomId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                IncludesFood = includesFood, 
                IncludesWalk = includesWalk, 
            };

            await repository.AddAsync(reservation);
            await repository.SaveChangesAsync();
        }
    }
}
