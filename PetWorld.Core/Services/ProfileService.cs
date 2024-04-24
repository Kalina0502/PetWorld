using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Profile;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository repository;

        private readonly IPetOwnerService petOwnerService;
        private readonly IAdoptionService adoptionService;
        private readonly IHotelService hotelService;

        public ProfileService(IRepository _repository,
            IPetOwnerService _petOwnerService,
            IAdoptionService _adoptionService,
            IHotelService _hotelService)
        {
            repository = _repository;
            petOwnerService = _petOwnerService;
            adoptionService = _adoptionService;
            hotelService = _hotelService;
        }

        public async Task<ProfileIndexViewModel?> GetProfileIndexViewModelByIdAsync(string userId)
        {
            var petOwner = await repository.AllReadOnly<PetOwner>()
                   .Where(pt => pt.UserId == userId)
                   .Select(pt => new ProfileIndexViewModel()
                   {
                       FirstName = pt.PetOwnerFirstName,
                       LastName = pt.PetOwnerLastName,
                       Age = pt.Age,
                       Email = pt.Email,
                       GenderId = pt.GenderId,
                       PhoneNumber = pt.PhoneNumber,
                   })
                   .FirstOrDefaultAsync();

            return petOwner;
        }

        public async Task<PetOwner> GetPetOwnerByUserIdAsync(string userId)
        {
            // Извличане на обекта PetOwner с даден userId
            var petOwner = await repository.AllReadOnly<PetOwner>()
                .FirstOrDefaultAsync(po => po.UserId == userId);

            // Връщане на намерения обект PetOwner (или null, ако няма такъв)
            return petOwner;
        }


        public async Task UpdatePetOwnerAsync(ProfileIndexViewModel model, string userId)
        {
            // Извличане на съществуващ обект PetOwner
            var petOwner = await repository.AllReadOnly<PetOwner>()
                 .FirstOrDefaultAsync(po => po.UserId == userId);

            // Проверка дали обектът е намерен
            if (petOwner != null)
            {
                // Актуализиране на данните на съществуващия PetOwner
                petOwner.PetOwnerFirstName = model.FirstName;
                petOwner.PetOwnerLastName = model.LastName;
                petOwner.Age = model.Age;
                petOwner.GenderId = model.GenderId;
                petOwner.PhoneNumber = model.PhoneNumber;
                petOwner.Email = model.Email;

                // Запазване на промените
                await repository.SaveChangesAsync();
            }
        }

        public async Task<List<AdoptionServiceModel>> GetAdoptionsByOwnerIdAsync(string userId)
        {
            // Извличане на списък с AdoptionAnimal обекти, които имат съответното userId
            var adoptionAnimals = await repository.AllReadOnly<AdoptionAnimal>()
                .Where(aa => aa.UserId == userId)
                .ToListAsync();

            // Преобразуване на списъка от AdoptionAnimal обекти в AdoptionServiceModel
            var adoptionServiceModels = adoptionAnimals.Select(aa => new AdoptionServiceModel
            {
                Id = aa.Id,
                Name = aa.Name,
                City = aa.City,
                Description = aa.Description,
                ImageUrl = aa.ImageUrl
            }).ToList();

            // Връщане на списъка с AdoptionServiceModel
            return adoptionServiceModels;
        }
    }

}
