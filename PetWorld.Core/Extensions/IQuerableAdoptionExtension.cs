using PetWorld.Core.Models.Adoption;
using PetWorld.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableAdoptionExtension
    {
        public static IQueryable<AdoptionServiceModel> ProjectToAdoptionServiceModel(this IQueryable<AdoptionAnimal> adoptions)
        {
            return adoptions
                .Select(a => new AdoptionServiceModel()
                {
                    Id = a.Id,
                    City = a.City,
                    ImageUrl = a.ImageUrl,
                    Description = a.Description,
                    Name = a.Name
                });
        }
    }
}
