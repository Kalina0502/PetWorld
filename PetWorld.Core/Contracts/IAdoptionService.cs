using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Home;

namespace PetWorld.Core.Contracts
{
    public interface IAdoptionService
    {
        Task<IEnumerable<AdoptionIndexServiceModel>> LastThreePetsAsync();

        Task<IEnumerable<AdoptionSpeciesServiceModel>> AllSpeciesCategoriesAsync();

        Task<bool> SpeciesExistsAsync(int speciesId);

        Task<int> CreateAsync(AdoptionFormModel model, int agentId);
        Task<AdoptionQueryServiceModel> AllAsync(
            string? species = null,
            string? searchTerm = null,
            AdoptionSorting sorting = AdoptionSorting.Newest,
            int currentPage = 1,
            int adoptionPetsPerPage = 3);

        Task<IEnumerable<string>> AllSpeciesNamesAsync();

        Task<IEnumerable<AdoptionServiceModel>> AllAdoptionsByAgentIdAsync(int agentId);

        Task<IEnumerable<AdoptionServiceModel>> AllAdoptionsByUserId(string userId);

        Task<bool> ExistsAsync(int id);

        Task<AdoptionDetailsServiceModel> AdoptionDetailsByIdAsync(int id);

        Task EditAsync(int adoptionId, AdoptionFormModel model);

        Task<bool> HasAgentWithIdAsync(int adoptionId, string userId);

        Task<AdoptionFormModel?> GetAdoptionFormModelByIdAsync(int id);

        Task DeleteAsync(int adoptionId);

        Task<IEnumerable<AdoptionServiceModel>> GetUnApprovedAsync();

        Task ApproveAdoptionPetAsync(int adoptionId);

        Task<bool> IsAdoptedAsync(int adoptionId);

        Task<bool> IsAdoptedByIUserWithIdAsync(int adoptionId, string userId);

        Task ForAdoptionAsync(int id, string userId);

        Task AdoptAsync(int id, string userId);
    }
}