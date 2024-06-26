﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetWorld.Infrastructure.Constants.DataConstants;


namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Addoption description")]
    public class AdoptionAnimal
    {
        [Key]
        [Comment("Pet identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PetNameLength)]
        [Comment("Pet name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Pet age")]
        [Range(PetMinAge, PetMaxAge)]
        public int? Age { get; set; }

        [Required]
        [MaxLength(CityLength)]
        [Comment("Pet city")]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionLength)]
        [Comment("Pet for adopting")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Species")]
        public int SpeciesId { get; set; }

        [ForeignKey(nameof(SpeciesId))]
        public Species Species { get; set; } = null!;

        [Required]
        [Comment("Pet image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
    }
}