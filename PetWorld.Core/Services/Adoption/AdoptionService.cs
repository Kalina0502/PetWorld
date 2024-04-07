using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts.Adoption;
using PetWorld.Core.Models.Home;
using PetWorld.Infrastructure.Common;

namespace PetWorld.Core.Services.Adoption
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IRepository repository;
        public AdoptionService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<AdoptionIndexServiceModel>> LastTrheePets()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.AdoptionAnimal>()
                .OrderByDescending(a => a.Id)
                .Take(3)
                .Select(a => new AdoptionIndexServiceModel()
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    Title = a.Name
                })
                .ToListAsync();
        }
    }
}
