using PetWorld.Core.Models.Profile;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Contracts
{
    public interface IProfileService
    {
        Task<int> CreateAsync(ProfileIndexViewModel model, string userId);

        Task<PetOwner> FindPetOwnerByEmailAsync(string email);
    }
}