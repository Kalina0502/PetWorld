using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Pet;
using PetWorld.Core.Models.Profile;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Contracts
{
    public interface IPetOwnerService
    {
        Task<PetOwner> FindPetOwnerByEmailAsync(string email);

        Task<int> CreateAsync(ProfileIndexViewModel model, string userId);

        Task<PetOwner> FindPetOwnerByIdAsync(string userId);

        Task<string> GetGenderTypeByIdAsync(int genderId);

        Task<List<PetServiceModel>> GetPetsByOwnerIdAsync(int ownerId);

        Task<AdoptionFormModel> PetDetailsByIdAsync(int id);

        Task<int> CreatePetAsync(PetServiceModel model, string userId);

        Task DeleteAsync(int petId);

        Task<IEnumerable<PetSpeciesServiceModel>> AllSpeciesAsync();


    }
}
