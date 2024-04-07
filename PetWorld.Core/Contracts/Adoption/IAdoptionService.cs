using PetWorld.Core.Models.Home;

namespace PetWorld.Core.Contracts.Adoption
{
    public interface IAdoptionService
    {
        Task<IEnumerable<AdoptionIndexServiceModel>> LastTrheePets();
    }
}