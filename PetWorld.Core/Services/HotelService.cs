﻿using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
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

            if (checkInDate >= checkOutDate)
            {
                return null;
            }

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
                    RoomType = hr.RoomType.Name,
                    IsAvailable = hr.IsAvailable
                })
                .FirstOrDefaultAsync();

            return availableRoom;
        }

        public async Task ReserveRoomAsync(int roomId,
         DateTime checkInDate, DateTime checkOutDate,
         bool includesFood, bool includesWalk, string userId)
        {
            var reservation = new RoomReservation
            {
                RoomId = roomId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                IncludesFood = includesFood,
                IncludesWalk = includesWalk,
                UserId = userId
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
                IsAvailable = true,
            };

            await repository.AddAsync(hotelRoom);
            await repository.SaveChangesAsync();

            return hotelRoom.Id;
        }

        public async Task<List<HotelRoomServiceModel>> GetUserReservationsAsync(string userId)
        {
            // Извличане на резервации за конкретния потребител
            var reservations = await repository.AllReadOnly<RoomReservation>()
                .Where(reservation => reservation.UserId == userId)
                .Include(rr => rr.Room)
                .ThenInclude(r => r.RoomType)
                .ToListAsync();

            // Конвертиране на списъка с резервации към списък от HotelRoomServiceModel
            var hotelReservations = reservations.Select(rr => new HotelRoomServiceModel
            {
                Id = rr.Id, // Използвате Id от RoomReservation
                CheckInDate = rr.CheckInDate,
                CheckOutDate = rr.CheckOutDate,
                IncludesFood = rr.IncludesFood,
                IncludesWalk = rr.IncludesWalk,
                RoomType = rr.Room.RoomType.Name
            }).ToList();

            // Връщане на списък от HotelRoomServiceModel
            return hotelReservations;
        }


        public async Task<bool> HasAgentWithIdAsync(int roomId, string userId)
        {
            return await repository.AllReadOnly<Room>()
                 .AnyAsync(r => r.Id == roomId && r.Agent.UserId == userId);
        }

        public async Task<IEnumerable<HotelRoomDetailsServiceModel>> GetRoomsByTypeAsync(int roomTypeId)
        {
            return await repository.AllReadOnly<Room>()
                .Where(r => r.RoomType.Id == roomTypeId) // Филтрирайте по избрания тип стая
                .Select(r => new HotelRoomDetailsServiceModel()
                {
                    Id = r.Id,
                    RoomType = r.RoomType.Name,
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        Email = r.Agent.User.Email,
                        PhoneNumber = r.Agent.PhoneNumber
                    }
                })
                .ToListAsync();
        }

        public async Task<HotelRoomServiceModel> ReservationDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<RoomReservation>()
                //.Where(aa => aa.IsApproved)
                .Where(rr => rr.Id == id)
                .Select(rr => new HotelRoomServiceModel()
                {
                    Id = rr.Id,
                    CheckInDate = rr.CheckInDate,
                    CheckOutDate = rr.CheckOutDate,
                    IncludesFood = rr.IncludesFood,
                    IncludesWalk = rr.IncludesWalk,
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<AllHotelRoomsQueryModel>> GetAllRoomsAsync()
        {
            // Извличане на всички стаи от базата данни
            var rooms = await repository.AllReadOnly<RoomReservation>()
                .Select(r => new AllHotelRoomsQueryModel
                {
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    RoomType = r.Room.RoomType.Name,
                })
                .ToListAsync();

            // Връщане на списъка с всички стаи
            return rooms;
        }
        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync<RoomReservation>(id);
            await repository.SaveChangesAsync();
        }
    }
}
