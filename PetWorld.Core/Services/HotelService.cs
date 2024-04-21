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

        public async Task<HotelRoomsQueryServiceModel> AllAsync(
            string? roomType = null,
            DateTime? checkInDate = null,
            DateTime? checkOutDate = null,
            HotelSorting sorting = HotelSorting.Newest,
            int currentPage = 1,
            int roomsPerPage = 1)
        {
            checkInDate ??= DateTime.Today;
            checkOutDate ??= DateTime.Today;

            var hotelRoomsToShow = repository.AllReadOnly<Room>();

            if (roomType != null)
            {
                hotelRoomsToShow = hotelRoomsToShow
                    .Where(hr => hr.RoomType.Name == roomType);
            }

            if (checkInDate.HasValue && checkOutDate.HasValue)
            {
                hotelRoomsToShow = hotelRoomsToShow
                    .Where(hr => !repository.AllReadOnly<RoomReservation>()
                        .Any(r => r.RoomId == hr.Id &&
                                  (r.CheckInDate <= checkOutDate.Value) && (r.CheckOutDate >= checkInDate.Value)));
            }

            var hotelRooms = await hotelRoomsToShow
                .Skip((currentPage - 1) * roomsPerPage)
                .Take(roomsPerPage)
                .Select(hr => new HotelRoomServiceModel
                {
                    Id = hr.Id,
                    RoomTypeId = hr.RoomTypeId,
                    IsAvailable = hr.IsAvailable
                })
                .ToListAsync();

            int totalRoomsCount = await hotelRoomsToShow.CountAsync();

            return new HotelRoomsQueryServiceModel
            {
                TotalRoomsCount = totalRoomsCount,
                HotelRooms = hotelRooms
            };
        }

        public async Task ReserveRoomAsync(int roomId, 
            DateTime checkInDate, DateTime checkOutDate, 
            bool includesFood = false, bool includesWalk = false)
        {
            var reservation = new RoomReservation
            {
                RoomId = roomId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                IncludesFood = false,
                IncludesWalk = false,
            };

            await repository.AddAsync(reservation);
            await repository.SaveChangesAsync();
        }



    }
}
