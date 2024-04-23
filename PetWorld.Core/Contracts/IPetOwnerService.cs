using PetWorld.Core.Models.Pet;
using PetWorld.Core.Models.Profile;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Contracts
{
    public interface IPetOwnerService
    {
        Task<PetOwner> FindPetOwnerByEmailAsync(string email);

        Task<int> CreateAsync(ProfileIndexViewModel model, string userId);

        Task<PetOwner> FindPetOwnerByIdAsync(int id);

        Task<string> GetGenderTypeByIdAsync(int genderId);

        Task<List<PetServiceModel>> GetPetsByOwnerIdAsync(int ownerId);
    }
}
