using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Home;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Services
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IRepository repository;
        public AdoptionService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<AdoptionQueryServiceModel> AllAsync(string? species = null,
            string? searchTerm = null,
            AdoptionSorting sorting = AdoptionSorting.Newest,
            int currentPage = 1,
            int adoptionsPerPage = 1)
        {
            var adoptionToShow = repository.AllReadOnly<AdoptionAnimal>();
            //.Where(aa => aa.IsApproved);

            if (species != null)
            {
                adoptionToShow = adoptionToShow
                    .Where(a => a.Species.Name == species);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                adoptionToShow = adoptionToShow
                    .Where(a => a.City.ToLower().Contains(normalizedSearchTerm) ||
                                (a.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            adoptionToShow = sorting switch
            {
                AdoptionSorting.Newest => adoptionToShow.OrderByDescending(a => a.Id),
                AdoptionSorting.Oldest => adoptionToShow.OrderBy(a => a.Id),
                AdoptionSorting.NameDescending => adoptionToShow.OrderByDescending(a => a.Name),
                _ => adoptionToShow.OrderByDescending(a => a.Id)
            };


            var adoptions = await adoptionToShow
                .Skip((currentPage - 1) * adoptionsPerPage)
                .Take(adoptionsPerPage)
                .Select(a => new AdoptionServiceModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    City = a.City,
                    Description = a.Description,
                })
                .ToListAsync();

            int totalHouses = await adoptionToShow.CountAsync();

            return new AdoptionQueryServiceModel()
            {
                Adoptions = adoptions,
                TotalAdoptionsCount = totalHouses
            };
        }

        public async Task<IEnumerable<string>> AllSpeciesNamesAsync()
        {
            return await repository.AllReadOnly<Species>()
                .Select(s => s.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptionIndexServiceModel>> LastTrheePetsAsync()
        {
            return await repository
                .AllReadOnly<AdoptionAnimal>()
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

        public async Task<bool> SpeciesExistsAsync(int speciesId)
        {
            return await repository.AllReadOnly<Species>()
                .AllAsync(s => s.Id == speciesId);
        }

        public async Task<int> CreateAsync(AdoptionFormModel model, int agentId)
        {
            AdoptionAnimal adoptionAnimal = new AdoptionAnimal()
            {
                Name = model.Name,
                Age = model.Age,
                Description = model.Description,
                SpeciesId = model.SpeciesId,
                City = model.City,
                AgentId = agentId
            };

            await repository.AddAsync(adoptionAnimal);
            await repository.SaveChangesAsync();

            return adoptionAnimal.Id;
        }

        /*  public async Task<IEnumerable<AdoptionFormModel>> GetAnimalsForAdoptionAsync()
          {
              var adoptionAnimals = repository.AllReadOnly<AdoptionAnimal>()
                  .OrderByDescending(a => a.Id)
                  .Select(a => new AdoptionFormModel()
                  {
                      Name = a.Name,
                      City = a.City,
                      ImageUrl = a.ImageUrl,
                      SpeciesId = a.SpeciesId,
                  });

              return await adoptionAnimals.ToListAsync();
          }*/

        /* public async Task<AdoptionFormModel> GetAnimalDetailsAsync(int id)
         {
             var adoptionAnimal = await repository.AllReadOnly<AdoptionAnimal>()
                 .Where(a => a.Id == id)
                 .Select(a => new AdoptionFormModel()
                 {
                     Name = a.Name,
                     Age = a.Age.HasValue ? a.Age.Value.ToString() : "No age specified",
                     City = a.City,
                     Description = a.Description,
                     ImageUrl = a.ImageUrl,
                     SpeciesId = a.SpeciesId,
                 })
                 .FirstOrDefaultAsync();

             return adoptionAnimal;
         }*/
    }
}
