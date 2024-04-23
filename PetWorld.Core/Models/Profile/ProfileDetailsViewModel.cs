using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Hotel;
using PetWorld.Core.Models.Pet;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Core.Models.Profile
{
    public class ProfileDetailsViewModel
    {
        public int Id { get; set; }

        public PetOwner PetOwner { get; set; } 

        public List<PetServiceModel> Pets { get; set; } = new List<PetServiceModel>();

        public List<HotelRoomServiceModel> HotelReservations { get; set; } = new List<HotelRoomServiceModel>();

        public List<AdoptionServiceModel> Adoptions { get; set; } = new List<AdoptionServiceModel>();

        public string Gender { get; set; } = string.Empty;

    }

}
