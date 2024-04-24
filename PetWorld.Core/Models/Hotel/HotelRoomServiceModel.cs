using Microsoft.EntityFrameworkCore;

namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomServiceModel
    {
        public int Id { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        [Comment("Room Type Id")]
        public string RoomType { get; set; } = string.Empty;

        [Comment("Is Available")]
        public bool IsAvailable { get; set; }

        public bool IncludesFood { get; set; }

        public bool IncludesWalk { get; set; }

    }
}