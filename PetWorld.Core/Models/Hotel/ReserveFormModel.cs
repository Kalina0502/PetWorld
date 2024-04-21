using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Hotel
{
    public class ReserveFormModel
    {
        public class ReserveRoomModel
        {
            [Required]
            public int RoomId { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime CheckInDate { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime CheckOutDate { get; set; }

            public bool IncludesFood { get; set; } = false;

            public bool IncludesWalk { get; set; } = false;
        }
    }
}
