using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Room description")]
    public class Room
    {
        [Key]
        [Comment("Room identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("RoomType identifier")]
        public int RoomTypeId { get; set; }

        // Свързване към RoomType
        [ForeignKey(nameof(RoomTypeId))]
        public RoomType RoomType { get; set; } = null!;

        [Required]
        [Comment("Is Available")]
        public bool IsAvailable { get; set; }

        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        public List<RoomReservation> Reservations { get; set; } = new List<RoomReservation>();
    }
}