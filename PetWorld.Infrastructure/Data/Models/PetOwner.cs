using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetWorld.Infrastructure.Constants.DataConstants;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Pet Owner")]
    public class PetOwner
    {
        [Key]
        [Comment("Pet owner identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameLength)]
        [Comment("Pet owner first name")]
        public string PetOwnerFirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameLength)]
        [Comment("Pet owner last name")]
        public string PetOwnerLastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(EmailLength)]
        [Comment("Pet Owner email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneNumberLength)]
        [Comment("Pet owner phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Range(PetOwnerMinAge, PetOwnerMaxAge)]
        [Comment("Pet owner age")]
        public int Age { get; set; }

        [Required]
        [ForeignKey(nameof(Gender))]
        [Comment("Pet Owner gender")]
        public int GenderId { get; set; }

        public GenderType Gender { get; set; } = null!;

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}