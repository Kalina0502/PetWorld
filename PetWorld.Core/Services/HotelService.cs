using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Hotel;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;

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

            if (roomType != null)
            {
                hotelRoomsToShow = hotelRoomsToShow
                    .Where(hr => hr.RoomType.Name == roomType);
            }

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
                .FirstOrDefaultAsync();

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

        public async Task<int> CreateAsync(HotelRoomFormModel model, int agentId)
        {
            Room hotelRoom = new Room()
            {
                Id = model.Id,
                AgentId = agentId,
                RoomTypeId = model.RoomTypeId,
            };

            await repository.AddAsync(hotelRoom);
            await repository.SaveChangesAsync();

            return hotelRoom.Id;
        }

        public async Task<IEnumerable<RoomReservation>> GetUserReservationsAsync(string userId)
        {
            return await repository.AllReadOnly<RoomReservation>()
                .Where(reservation => reservation.UserId == userId)
                 .Include(rr => rr.Room) 
                .ThenInclude(r => r.RoomType) 
                .Select(rr => new RoomReservation
                {
                    Id = rr.RoomId, 
                    CheckInDate = rr.CheckInDate, 
                    CheckOutDate = rr.CheckOutDate, 
                    IncludesFood = rr.IncludesFood,
                    IncludesWalk = rr.IncludesWalk, 
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RoomReservation>> AllReservationsByAgentIdAsync(int agentId)
        {
            var reservations = await repository.AllReadOnly<RoomReservation>()
                .Where(rr => rr.AgentId == agentId) 
                .Include(rr => rr.Room) 
                .ThenInclude(r => r.RoomType) 
                .Select(rr => new RoomReservation
                {
                   Id = rr.RoomId, 
                   CheckInDate = rr.CheckInDate, 
                   CheckOutDate = rr.CheckOutDate, 
                   IncludesFood = rr.IncludesFood, 
                   IncludesWalk = rr.IncludesWalk,
                })
                .ToListAsync();

            return reservations;
        }

    }
}
