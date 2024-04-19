using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace PetWorld.Core.Services
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly IRepository repository;

        public PetOwnerService(IRepository _repository)
        {
            repository = _repository;
        }

        // Метод за получаване на ID на собственик по UserID
        public async Task<int?> GetPetOwnerIdByUserIdAsync(string userId)
        {
            // Извличане на собственика на домашен любимец по userId
            var petOwner = await repository
                .All<PetOwner>()
                .FirstOrDefaultAsync(po => po.UserId == userId);

            // Връщане на PetOwnerId, ако съществува такъв запис, иначе null
            return petOwner?.Id;
        }
    }
}
