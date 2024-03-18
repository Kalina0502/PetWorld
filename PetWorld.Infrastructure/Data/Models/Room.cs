using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Room description")]
    public class Room
    {
        [Key]
        [Comment("Room identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Room type")]
        public string RoomType { get; set; } = string.Empty;

        [Required]
        [Comment("Room type")]
        public Species? Species { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}