using PetWorld.Core.Models.Adoption;
using System.ComponentModel.DataAnnotations;
using static PetWorld.Core.Constants.MessageConstants;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Core.Models.Pet
{
    public class PetFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PetNameMaxLength,
          MinimumLength = PetNameMinLength,
          ErrorMessage = LengthMessage)]
        public string Name { get; set; } = null!;

        [Range(PetMinAge, PetMaxAge, ErrorMessage = "Age must be between {1} and {2}")]
        public int? Age { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CityMaxLength,
            MinimumLength = CityMinLength,
            ErrorMessage = LengthMessage)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        public int PetOwnerId { get; set; }

        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        public IEnumerable<PetSpeciesServiceModel> AllSpecies { get; set; } =
            new List<PetSpeciesServiceModel>();
    }
}
