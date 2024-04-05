using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Pet description")]
    public class Pet
    {
        [Key]
        [Comment("Pet identifier")]
        public int Id { get; set; }

        [MaxLength(PetNameLength)]
        [Comment("Pet name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Pet age")]
        [Range(PetMinAge, PetMaxAge)]
        public int Age { get; set; }

        [Required]
        [Comment("Species")]
        public int SpeciesId { get; set; }

        [ForeignKey(nameof(SpeciesId))]
        public Species Species { get; set; } = null!;

        [Comment("Pet description")]
        [MaxLength(DescriptionLength)]
        public string? Description { get; set; }

        [Required]
        [Comment("Pet owner")]
        public int PetOwnerId { get; set; }

        [ForeignKey(nameof(PetOwnerId))]
        public PetOwner Owner { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Gender))]
        [Comment("Pet gender")]
        public int GenderId { get; set; }

        public GenderType Gender { get; set; } = null!;
    }
}