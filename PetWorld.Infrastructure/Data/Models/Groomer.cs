using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Groomer description")]
    public class Groomer
    {
        [Key]
        [Comment("Groomer identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Groomer name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Groomer age")]
        public int Age { get; set; }

        [Required]
        [Comment("Groomer short description")]
        public string Description { get; set; } = null!;
    }
}