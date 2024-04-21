using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Hotel;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Controllers
{
    public class AllHotelRoomsQueryModel
    {
        public int HotelRoomsPerPage { get; } = 3;

        public string RoomType { get; init; } = null!;

        public DateTime? CheckInDate { get; init; }

        public DateTime? CheckOutDate { get; init; }

        public HotelSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public int TotalHotelRoomsCount { get; set; }

        [Display(Name = "Speciest List")]
        public IEnumerable<string> RoomTypes { get; set; } = null!;

        public IEnumerable<HotelRoomServiceModel> HotelRooms { get; set; } = new List<HotelRoomServiceModel>();
    }
}