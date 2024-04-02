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

        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
    }
}