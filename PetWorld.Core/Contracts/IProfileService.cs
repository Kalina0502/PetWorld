using PetWorld.Core.Models.Profile;

namespace PetWorld.Core.Contracts
{
    public interface IProfileService
    {
        Task UpdatePetOwnerAsync(ProfileIndexViewModel model, string userId);

        Task<ProfileIndexViewModel?> GetProfileIndexViewModelByIdAsync(int id);

    }
}