using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Home;

namespace PetWorld.Core.Contracts
{
    public interface IAdoptionService
    {
        Task<IEnumerable<AdoptionIndexServiceModel>> LastTrheePetsAsync();

        Task<IEnumerable<string>> AllSpeciesNamesAsync();

        Task<bool> SpeciesExistsAsync(int speciesId);

        Task<int> CreateAsync (AdoptionFormModel model, int agentId);

        //  Task<IEnumerable<AdoptionFormModel>> GetAnimalsForAdoptionAsync();
        // Task<AdoptionFormModel> GetAnimalDetailsAsync(int id);

        Task<AdoptionQueryServiceModel> AllAsync(
          string? category = null,
          string? searchTerm = null,
          AdoptionSorting sorting = AdoptionSorting.Newest,
          int currentPage = 1,
          int housesPerPage = 1);
    }
}