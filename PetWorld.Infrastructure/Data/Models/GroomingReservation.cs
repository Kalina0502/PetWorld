using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWorld.Infrastructure.Data.Models
{
    public class GroomingReservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Pet")]
        public int PetId { get; set; }

        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; } = null!;

        [Required]
        [Comment("Check-in date")]
        public DateTime StartTime { get; set; }

        [Required]
        [Comment("Check-out date")]
        public DateTime EndTime { get; set; }

        [Required]
        public int GroomerId { get; set; }

        [Required]
        [ForeignKey(nameof(GroomerId))]
        public Groomer Groomer { get; set; } = null!;

        [Required]
        public int GroomingTypeId { get; set; }

        [Required]
        [ForeignKey(nameof(GroomingTypeId))]
        public GroomingType GroomingType { get; set; } = null!;
    }
}