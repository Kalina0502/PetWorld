using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Hotel;
using PetWorld.Infrastructure.Data.Models;


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
        Task ReserveRoomAsync(int roomId, DateTime checkInDate, DateTime checkOutDate, bool includesFood, bool includesWalk);

        Task<int> CreateAsync(HotelRoomFormModel model, int agentId);

        Task<IEnumerable<RoomReservation>> GetUserReservationsAsync(string userId);

        Task<IEnumerable<RoomReservation>> AllReservationsByAgentIdAsync(int agentId);


    }
}