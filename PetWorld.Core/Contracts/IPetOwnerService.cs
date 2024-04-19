namespace PetWorld.Core.Contracts
{
    public interface IPetOwnerService
    {
        Task<int?> GetPetOwnerIdByUserIdAsync(string userId);
    }
}
