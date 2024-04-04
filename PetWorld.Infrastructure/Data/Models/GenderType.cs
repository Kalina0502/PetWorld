using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Infrastructure.Data.Models
{
    public class GenderType
    {
        [Key]
        [Comment("GenderType identifier")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }
    }
}