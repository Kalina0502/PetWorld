using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Enumerations;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Home;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;
using System.Runtime.CompilerServices;

namespace PetWorld.Core.Services
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IRepository repository;

        public AdoptionService(IRepository _repository)
        {
            repository = _repository;
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
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        // FullName = $"{aa.Agent.User.FirstName} {aa.Agent.User.LastName}",
                        Email = aa.Agent.User.Email,
                        PhoneNumber = aa.Agent.PhoneNumber
                    },
                    Species = aa.Species.Name,
                    Description = aa.Description,
                    ImageUrl = aa.ImageUrl,
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

        public async Task<AdoptionQueryServiceModel> AllAsync(string? species = null,
            string? searchTerm = null,
            AdoptionSorting sorting = AdoptionSorting.Newest,
            int currentPage = 1,
            int adoptionPetsPerPage = 1)
        {
            var adoptionPetToShow = repository.AllReadOnly<AdoptionAnimal>();
            // .Where(h => h.IsApproved);

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
                _ => adoptionPetToShow
                .OrderByDescending(aa => aa.Id)
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

        public async Task<IEnumerable<AdoptionSpeciesServiceModel>> AllSpeciesCategoriesAsync()
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
                AgentId = agentId
            };

            await repository.AddAsync(adoptionAnimal);
            await repository.SaveChangesAsync();

            return adoptionAnimal.Id;
        }

        public Task DeleteAsync(int adoptionId)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int adoptionId, AdoptionFormModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<AdoptionAnimal>()
                .AnyAsync(aa => aa.Id == id);
        }

        public Task<AdoptionFormModel?> GetAdoptionFormModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdoptionServiceModel>> GetUnApprovedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasAgentWithIdAsync(int adoptionId, string userId)
        {
            throw new NotImplementedException();
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

        public async Task<bool> SpeciesExistsAsync(int speciesId)
        {
            return await repository.AllReadOnly<Species>()
                .AllAsync(s => s.Id == speciesId);
        }
    }
}
