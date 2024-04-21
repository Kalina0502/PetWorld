namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomsQueryServiceModel
    {
        public int TotalRoomsCount { get; set; }

        public IEnumerable<HotelRoomServiceModel> HotelRooms { get; set; } = new List<HotelRoomServiceModel>();
    }
}
