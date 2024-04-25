﻿using PetWorld.Core.Models.Hotel;


namespace PetWorld.Core.Contracts
{
    public interface IHotelService
    {
        Task<IEnumerable<RoomTypeServiceModel>> AllRoomTypesAsync();

        Task<IEnumerable<string>> AllRoomTypeNamesAsync();

        Task<HotelRoomServiceModel> AllAsync(
             string? roomType = null,
            DateTime? checkInDate = null,
            DateTime? checkOutDate = null);
        Task ReserveRoomAsync(int roomId, DateTime checkInDate, DateTime checkOutDate, bool includesFood, bool includesWalk, string userId);

        Task<int> CreateAsync(HotelRoomFormModel model, int agentId);

        Task<List<HotelRoomServiceModel>> GetUserReservationsAsync(string userId);

        Task<IEnumerable<AllHotelRoomsQueryModel>> GetAllRoomsAsync();

        Task DeleteAsync(int id);

        Task<HotelRoomServiceModel> ReservationDetailsByIdAsync(int id);



    }
}