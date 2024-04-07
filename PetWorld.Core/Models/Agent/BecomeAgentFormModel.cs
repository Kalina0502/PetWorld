using System.ComponentModel.DataAnnotations;
using static PetWorld.Core.Constants.MessageConstats;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneNumberLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage =LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}