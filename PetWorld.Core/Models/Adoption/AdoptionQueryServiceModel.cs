namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionQueryServiceModel
    {
        public int TotalAdoptionPetsCount { get; set; }

        public IEnumerable<AdoptionServiceModel> AdoptionPets { get; set; } =
            new List<AdoptionServiceModel>();
    }
}
