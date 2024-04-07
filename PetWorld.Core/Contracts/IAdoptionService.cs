using PetWorld.Core.Models.Home;

namespace PetWorld.Core.Contracts
{
    public interface IAdoptionService
    {
        Task<IEnumerable<AdoptionIndexServiceModel>> LastTrheePets();
    }
}