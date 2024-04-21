using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomServiceModel
    {
        public int Id { get; set; }

        [Comment("Room Type Id")]
        public int RoomTypeId { get; set; }

        [Required]
        [Comment("Is Available")]
        public bool IsAvailable { get; set; }
    }
}