using PetWorld.Core.Models.Hotel;
using System.ComponentModel.DataAnnotations;
using static PetWorld.Core.Constants.MessageConstants;

namespace PetWorld.Controllers
{
    public class AllHotelRoomsQueryModel
    {
        public int HotelRoomsPerPage { get; } = 3;

        public string RoomType { get; init; } = null!;

        public DateTime? CheckInDate { get; init; }

        public DateTime? CheckOutDate { get; init; }

        public int TotalHotelRoomsCount { get; set; }

        [Display(Name = "All room types")]
        public IEnumerable<string> RoomTypes { get; set; } = null!;

        public IEnumerable<HotelRoomServiceModel> HotelRooms { get; set; } = new List<HotelRoomServiceModel>();
    }
}