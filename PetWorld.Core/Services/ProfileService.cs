using PetWorld.Core.Contracts;
using PetWorld.Infrastructure.Common;

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

    }
}