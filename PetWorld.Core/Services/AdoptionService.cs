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

        public async Task ForAdoptionAsync(int id, string userId)
        {
            var adoption = await repository.GetByIdAsync<AdoptionAnimal>(userId);

            if (adoption != null)
            {
                if (adoption.UserId != userId)
                {
                    // throw new UnauthorizedActionException("The user is not the renter");
                }

                adoption.UserId = null;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<AdoptionDetailsServiceModel> AdoptionDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<AdoptionAnimal>()
                //.Where(aa => aa.IsApproved)
                .Where(aa => aa.Id == id)
                .Select(aa => new AdoptionDetailsServiceModel()
                {
                    Id = aa.Id,
                    City = aa.City,
                    ImageUrl = aa.ImageUrl,
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        // FullName = $"{aa.Agent.User.FirstName} {aa.Agent.User.LastName}",
                        Email = aa.Agent.User.Email,
                        PhoneNumber = aa.Agent.PhoneNumber
                    },
                    Species = aa.Species.Name,
                    Description = aa.Description,
                    Name = aa.Name
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<AdoptionServiceModel>> AllAdoptionsByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<AdoptionAnimal>()
                .Where(aa => aa.AgentId == agentId)
                .ProjectToAdoptionServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<AdoptionServiceModel>> AllAdoptionsByUserId(string userId)
        {
            return await repository.AllReadOnly<AdoptionAnimal>()
               .Where(aa => aa.UserId == userId)
               .ProjectToAdoptionServiceModel()
               .ToListAsync();
        }

        public async Task<AdoptionQueryServiceModel> AllAsync(
            string? species = null,
            string? searchTerm = null,
            AdoptionSorting sorting = AdoptionSorting.Newest,
            int currentPage = 1,
            int adoptionPetsPerPage = 3)
        {
            var adoptionPetToShow = repository.AllReadOnly<AdoptionAnimal>();

            if (species != null)
            {
                adoptionPetToShow = adoptionPetToShow
                        .Where(aa => aa.Species.Name == species);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                adoptionPetToShow = adoptionPetToShow
                    .Where(aa => (aa.Name.ToLower().Contains(normalizedSearchTerm) ||
                                aa.City.ToLower().Contains(normalizedSearchTerm) ||
                                aa.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            adoptionPetToShow = sorting switch
            {
                AdoptionSorting.Newest => adoptionPetToShow.OrderByDescending(aa => aa.Id),
                AdoptionSorting.Oldest => adoptionPetToShow.OrderBy(aa => aa.Id),
                _ => adoptionPetToShow.OrderByDescending(aa => aa.Id), // По подразбиране сортирайте по най-нови
            };

            var adoptionPets = await adoptionPetToShow
                .Skip((currentPage - 1) * adoptionPetsPerPage)
                .Take(adoptionPetsPerPage)
                .ProjectToAdoptionServiceModel()
                .ToListAsync();

            int totalAdoptionPets = await adoptionPetToShow.CountAsync();

            return new AdoptionQueryServiceModel()
            {
                AdoptionPets = adoptionPets,
                TotalAdoptionPetsCount = totalAdoptionPets
            };
        }

        public async Task<IEnumerable<AdoptionSpeciesServiceModel>> AllSpeciesAsync()
        {
            return await repository.AllReadOnly<Species>()
                 .Select(c => new AdoptionSpeciesServiceModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
                 .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllSpeciesNamesAsync()
        {
            return await repository.AllReadOnly<Species>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public Task ApproveAdoptionPetAsync(int adoptionId)
        {
            throw new NotImplementedException();
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
                AgentId = agentId,
                ImageUrl = model.ImageUrl
            };

            await repository.AddAsync(adoptionAnimal);
            await repository.SaveChangesAsync();

            return adoptionAnimal.Id;
        }

        public async Task DeleteAsync(int adoptionId)
        {
            await repository.DeleteAsync<AdoptionAnimal>(adoptionId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int adoptionId, AdoptionFormModel model)
        {
            var adoption = await repository.GetByIdAsync<AdoptionAnimal>(adoptionId);

            if (adoption != null)
            {
                adoption.City = model.City;
                adoption.SpeciesId = model.SpeciesId;
                adoption.Age = model.Age;
                adoption.Description = model.Description;
                adoption.ImageUrl = model.ImageUrl;
                adoption.Name = model.Name;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> SpeciesExistsAsync(int speciesid)
        {
            return await repository.AllReadOnly<AdoptionAnimal>()
                .AnyAsync(aa => aa.Id == speciesid);
        }

        public async Task<AdoptionFormModel?> GetAdoptionFormModelByIdAsync(int id)
        {
            var adoption = await repository.AllReadOnly<AdoptionAnimal>()
                   .Where(aa => aa.Id == id)
                   .Select(aa => new AdoptionFormModel()
                   {
                       City = aa.City,
                       SpeciesId = aa.SpeciesId,
                       Description = aa.Description,
                       Age = aa.Age,
                       ImageUrl = aa.ImageUrl,
                       Name = aa.Name,
                   })
                   .FirstOrDefaultAsync();

            if (adoption != null)
            {
                adoption.AllSpecies = await AllSpeciesAsync();
            }

            return adoption;
        }

        public Task<IEnumerable<AdoptionServiceModel>> GetUnApprovedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasAgentWithIdAsync(int adoptionId, string userId)
        {
            return await repository.AllReadOnly<AdoptionAnimal>()
                 .AnyAsync(aa => aa.Id == adoptionId && aa.Agent.UserId == userId);
        }

        public async Task<bool> IsAdoptedAsync(int adoptionId)
        {
            bool result = false;
            var adoption = await repository.GetByIdAsync<AdoptionAnimal>(adoptionId);

            if (adoption != null)
            {
                result = adoption.UserId != null;
            }

            return result;
        }

        public async Task<bool> IsAdoptedByIUserWithIdAsync(int adoptionId, string userId)
        {
            bool result = false;
            var adoption = await repository.GetByIdAsync<AdoptionAnimal>(adoptionId);

            if (adoption != null)
            {
                result = adoption.UserId == userId;
            }

            return result;
        }

        public async Task<IEnumerable<AdoptionIndexServiceModel>> LastThreePetsAsync()
        {

            return await repository
                .AllReadOnly<AdoptionAnimal>()
                .OrderByDescending(a => a.Id)
                .Take(3)
                .Select(a => new AdoptionIndexServiceModel()
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task AdoptAsync(int id, string userId)
        {
            var adoption = await repository.GetByIdAsync<AdoptionAnimal>(id);

            if (adoption != null)
            {
                adoption.UserId = userId;
                await repository.SaveChangesAsync();
            }
        }
    }
}
