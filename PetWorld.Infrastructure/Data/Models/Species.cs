using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Species description")]
    public class Species
    {
        [Key]
        [Comment("Species identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SpeciesNameMaxLength)]
        [Comment("Species Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
    }
}