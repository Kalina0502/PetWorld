﻿using PetWorld.Core.Models.Agent;

namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionDetailsServiceModel : AdoptionServiceModel
    {
      //  public string Description { get; set; } = null!;

        public string Species { get; set; } = null!;

        public AgentServiceModel Agent { get; set; } = null!;   
    }
}