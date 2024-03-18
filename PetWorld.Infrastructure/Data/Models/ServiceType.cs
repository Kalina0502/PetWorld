using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Infrastructure.Data.Models
{
    [Comment("Service Type description")]
    public class ServiceType
    {
        [Key]
        [Comment("ServiceType identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the service")]
        public string Name { get; set; } = null!;
    }
}