using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
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

        public async Task<PetOwner> FindPetOwnerByEmailAsync(string email)
        {
            var petOwner = await repository.AllReadOnly<PetOwner>()
                .Where(po => po.Email == email)
                .FirstOrDefaultAsync();

            return petOwner;
        }
    }
}