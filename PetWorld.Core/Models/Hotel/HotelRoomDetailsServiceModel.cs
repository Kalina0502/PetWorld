using PetWorld.Core.Models.Agent;

namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomDetailsServiceModel
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = null!;

        public AgentServiceModel Agent { get; set; } = null!;
    }
}
