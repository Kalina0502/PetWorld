using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWorld.Infrastructure.Data.Models
{
    public class RoomType
    {
        [Key]
        [Comment("RoomType identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("RoomType")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}