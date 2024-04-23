using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetWorld.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetWorld.Core.Constants.MessageConstants;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Core.Models.Profile
{
    public class ProfileEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(FirstNameMaxLength,
          MinimumLength = FirstNameMinLength,
          ErrorMessage = LengthMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(LastNameMaxLength,
         MinimumLength = LastNameMinLength,
         ErrorMessage = LengthMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        //[Required]
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        //[StringLength(EmailLength, ErrorMessage = "Email must be less than {1} characters long.")]
        //public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneNumberMaxLength,
         MinimumLength = PhoneNumberMinLength,
         ErrorMessage = PhoneExists)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(PetOwnerMinAge, PetOwnerMaxAge, ErrorMessage = AgeMessage)]
        public int Age { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
    }
}
