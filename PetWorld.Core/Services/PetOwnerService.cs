using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Profile;
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

        public async Task<PetOwner> FindPetOwnerByEmailAsync(string email)
        {
            var petOwner = await repository.AllReadOnly<PetOwner>()
                .Where(po => po.Email == email)
                .FirstOrDefaultAsync();

            return petOwner;
        }

        public async Task<int> CreateAsync(ProfileIndexViewModel model, string userId)
        {
            PetOwner petOwner = new PetOwner()
            {
                PetOwnerFirstName = model.FirstName,
                PetOwnerLastName = model.LastName,
                Age = model.Age,
                GenderId = model.GenderId,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                UserId = userId
            };

            await repository.AddAsync(petOwner);
            await repository.SaveChangesAsync();

            return petOwner.Id;
        }

        public async Task<PetOwner> FindPetOwnerByIdAsync(int id)
        {
            // Query the PetOwner table using the provided ID
            var petOwner = await repository.AllReadOnly<PetOwner>()
                .FirstOrDefaultAsync(po => po.Id == id);

            // Return the found PetOwner or null if not found
            return petOwner;
        }

        public async Task<List<Pet>> GetPetsByOwnerIdAsync(int ownerId)
        {
            // Query the Pet table to retrieve all pets associated with the provided owner ID
            var pets = await repository.AllReadOnly<Pet>()
                .Where(p => p.PetOwnerId == ownerId)
                .ToListAsync();

            // Return the list of pets
            return pets;
        }

    }
}

