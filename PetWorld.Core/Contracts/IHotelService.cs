using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Hotel;
using PetWorld.Infrastructure.Data.Models;


namespace PetWorld.Core.Contracts
{
    public interface IHotelService
    {
      //  Task<Room?> FindFirstAvailableRoomAsync(string roomType, DateTime? checkInDate, DateTime? checkOutDate);

      //  Task<IEnumerable<string>> AllRoomTypesAsync();

        Task<IEnumerable<string>> AllRoomTypeNamesAsync();

        Task<HotelRoomsQueryServiceModel> AllAsync(
            string? roomType = null,
            DateTime? checkInDate = null,
            DateTime? checkOutDate = null,
            HotelSorting sorting = HotelSorting.Newest,
            int currentPage = 1,
            int roomsPerPage = 1);
    }
}