using PetWorld.Core.Models.Agent;
using System.ComponentModel.DataAnnotations;

namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionDetailsServiceModel : AdoptionServiceModel
    {
        public string Species { get; set; } = null!;

        public AgentServiceModel Agent { get; set; } = null!;
    }
}
