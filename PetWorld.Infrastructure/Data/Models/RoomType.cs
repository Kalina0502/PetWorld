using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        // Навигационно свойство за обратна връзка към стаите
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
