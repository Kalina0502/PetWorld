using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
    }
}