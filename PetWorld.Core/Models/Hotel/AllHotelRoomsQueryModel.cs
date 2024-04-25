using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Hotel
{
    public class AllHotelRoomsQueryModel
    {
        public string RoomType { get; init; } = null!;

        public DateTime? CheckInDate { get; init; }

        public DateTime? CheckOutDate { get; init; }

        public int TotalHotelRoomsCount { get; set; }

        [Display(Name = "All room types")]
        public IEnumerable<string> RoomTypes { get; set; } = null!;

        public IEnumerable<HotelRoomServiceModel> HotelRooms { get; set; } = new List<HotelRoomServiceModel>();
    }
}