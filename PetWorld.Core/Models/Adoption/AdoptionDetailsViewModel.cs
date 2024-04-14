using PetWorld.Core.Contracts;

namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionDetailsViewModel : IAdoptionModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
