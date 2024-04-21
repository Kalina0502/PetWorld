using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Reservation description")]
    public class RoomReservation
    {
        [Key]
        [Comment("Reservation identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Room identifier")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; } = null!;

       // [Required]
       // [Comment("Pet identifier")]
       // public int PetId { get; set; }

       // [ForeignKey(nameof(PetId))]
       // public Pet Pet { get; set; } = null!;

        [Required]
        [Comment("Check-in date")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Comment("Check-out date")]
        public DateTime CheckOutDate { get; set; }

        [Comment("Includes food")]
        public bool IncludesFood { get; set; } = false;

        [Comment("Includes walk")]
        public bool IncludesWalk { get; set; } = false;
    }
}
