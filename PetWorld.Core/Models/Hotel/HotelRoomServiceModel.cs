using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomServiceModel
    {
        internal bool IncludesWalk;

        public int Id { get; set; }

        [Comment("Room Type Id")]
        public int RoomTypeId { get; set; }


        [Comment("Is Available")]
        public bool IsAvailable { get; set; }

        public DateTime CheckInDate { get;  set; }

        public DateTime CheckOutDate { get;  set; }

        public bool IncludesFood { get;  set; }

        public string RoomType { get; set; } = string.Empty;
    }
}