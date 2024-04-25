using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Pet;
using PetWorld.Core.Models.Profile;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;

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

        // Метод за извличане на типа пол по идентификатор
        public async Task<string> GetGenderTypeByIdAsync(int genderId)
        {
            // Извличане на типа пол от базата данни по идентификатор
            var genderType = await repository.AllReadOnly<GenderType>()
                .Where(g => g.Id == genderId)
                .Select(g => g.Name)
                .FirstOrDefaultAsync();

            // Връщане на типа пол като низ
            return genderType;
        }

        public async Task<PetOwner> FindPetOwnerByIdAsync(string userId)
        {
            // Query the PetOwner table using the provided ID
            var petOwner = await repository.AllReadOnly<PetOwner>()
                .FirstOrDefaultAsync(po => po.UserId == userId);

            // Return the found PetOwner or null if not found
            return petOwner;
        }

        //public async Task<List<Pet>> GetPetsByOwnerIdAsync(int ownerId)
        //{
        //    // Query the Pet table to retrieve all pets associated with the provided owner ID
        //    var pets = await repository.AllReadOnly<Pet>()
        //        .Where(p => p.PetOwnerId == ownerId)
        //        .ToListAsync();

        //    // Return the list of pets
        //    return pets;
        //}

        public async Task<List<PetServiceModel>> GetPetsByUserIdAsync(string userId)
        {
            // Query the Pet table to retrieve all pets associated with the provided owner ID
            var pets = await repository.AllReadOnly<Pet>()
                .Where(p => p.UserId == userId)
                .ToListAsync();

            // Конвертиране на списъка от `Pet` към списък от `PetServiceModel`
            var allPets = pets.Select(p => new PetServiceModel
            {
               // Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Description = p.Description,
                City = p.City,
                ImageUrl = p.ImageUrl
            }).ToList();

            // Връщане на списък от PetServiceModel
            return allPets;
        }
        public async Task<IEnumerable<PetSpeciesServiceModel>> AllSpeciesAsync()
        {
            return await repository.AllReadOnly<Species>()
                 .Select(c => new PetSpeciesServiceModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
                 .ToListAsync();
        }

        public async Task<int> CreatePetAsync(PetFormModel model, string userId)
        {
            //var petOwner = await FindPetOwnerByIdAsync(userId);

            //// Ако не е намерен petOwner, върнете грешка или обработете случая по някакъв начин
            //if (petOwner == null)
            //{
            //    throw new Exception("PetOwner not found");
            //} 

            Pet newPet = new Pet()
            {
               // Id = model.Id,
                Name = model.Name,
              //  Age = model.Age,
                Description = model.Description,
                City = model.City,
                ImageUrl = model.ImageUrl,
                UserId = userId,
                SpeciesId = model.SpeciesId,
            };

            await repository.AddAsync(newPet);
            await repository.SaveChangesAsync();

            return newPet.Id;
        }

        public async Task<AdoptionDetailsServiceModel> PetDetailsByIdAsync(int id)
        {
            var pet = await repository.AllReadOnly<Pet>()
                //.Where(aa => aa.IsApproved)
                .Where(p => p.Id == id)
                .Select(p => new AdoptionDetailsServiceModel()
                {
                    City = p.City,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Name = p.Name,
                  // Age = p.Age,
                    Species = p.Species.Name,
                })
                .FirstAsync();

            return pet;
        }

        public async Task DeleteAsync(int petId)
        {
            await repository.DeleteAsync<Pet>(petId);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> PetExistsAsync(int petId)
        {
            return await repository.AllReadOnly<Pet>()
                 .AnyAsync(p => p.Id == petId);
        }
    }
}

