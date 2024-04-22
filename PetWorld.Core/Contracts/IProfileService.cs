using PetWorld.Core.Models;
using PetWorld.Core.Models.Profile;

namespace PetWorld.Core.Contracts
{
    public interface IProfileService
    {
        Task<int> CreateAsync(ProfileIndexViewModel model, string userId);

    }
}
