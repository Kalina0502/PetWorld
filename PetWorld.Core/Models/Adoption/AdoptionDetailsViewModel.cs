using PetWorld.Core.Contracts;

namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionDetailsViewModel : IAdoptionModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
