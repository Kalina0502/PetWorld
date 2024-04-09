using PetWorld.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static PetWorld.Core.Constants.MessageConstants;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionFormModel
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

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        public IEnumerable<string> Species { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<AdoptionSpeciesServiceModel> AllSpecies { get; set; } =
            new List<AdoptionSpeciesServiceModel>();
    }
}
