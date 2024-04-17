using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Agent
{
    public class AgentServiceModel
    {
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
