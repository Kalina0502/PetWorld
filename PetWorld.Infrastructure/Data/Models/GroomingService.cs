using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Grooming Service description")]
    public class GroomingService
    {
        [Key]
        [Comment("Grooming Service identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Date of service")]
        public DateTime DateTime { get; set; }

        [Required]
        public int PetId { get; set; }

        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; } = null!;

        [Required]
        public int GroomerId { get; set; }

        [Required]
        [ForeignKey(nameof(GroomerId))]
        public Groomer Groomer { get; set; } = null!;

        [Required]
        public int ServiceTypeId { get; set; }

        [Required]
        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceType ServiceType { get; set; } = null!;
    }
}