using PetWorld.Core.Models.Profile;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Contracts
{
    public interface IProfileService
    {
        Task UpdatePetOwnerAsync(ProfileIndexViewModel model, string userId);

        Task<PetOwner> GetPetOwnerByUserIdAsync(string userId);


        Task<ProfileIndexViewModel?> GetProfileIndexViewModelByIdAsync(string userId);

    }
}