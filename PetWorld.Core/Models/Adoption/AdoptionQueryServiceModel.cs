namespace PetWorld.Core.Models.Adoption
{
    public class AdoptionQueryServiceModel
    {
        public int TotalAdoptionsCount { get; set; }
        public IEnumerable<AdoptionServiceModel> Adoptions { get; set; } =
            new List<AdoptionServiceModel>();
    }
}
