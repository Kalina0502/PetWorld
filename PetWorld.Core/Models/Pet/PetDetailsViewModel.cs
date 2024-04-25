using PetWorld.Core.Contracts;

namespace PetWorld.Core.Models.Pet
{
    public class PetDetailsViewModel : IPetModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}
