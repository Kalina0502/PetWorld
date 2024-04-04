using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}