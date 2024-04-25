using System.ComponentModel.DataAnnotations;
using static PetWorld.Core.Constants.MessageConstants;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Core.Models.Pet
{
    public class PetServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PetNameMaxLength,
        MinimumLength = PetNameMinLength,
        ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PetMaxAge,
        MinimumLength = PetMinAge,
        ErrorMessage = AgeMessage)]
        public int Age { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
        MinimumLength = DescriptionMinLength,
        ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CityMaxLength,
        MinimumLength = CityMinLength,
        ErrorMessage = LengthMessage)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
