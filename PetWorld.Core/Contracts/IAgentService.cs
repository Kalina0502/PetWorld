namespace PetWorld.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        Task CreateAsync(string userId, string phoneNumber);

        Task<int?> GetAgentIdAsync(string userId);
    }
}
