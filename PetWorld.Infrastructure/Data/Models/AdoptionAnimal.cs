using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        [Comment("Pet species")]
        public Species? Species { get; set; }

        [Required]
        [Comment("Pet image url")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}