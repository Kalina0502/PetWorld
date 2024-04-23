namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomFormModel
    {
        public int Id { get; set; }

        public int RoomTypeId { get; set; }

        public IEnumerable<RoomTypeServiceModel> AllRoomTypes { get; set; } =
            new List<RoomTypeServiceModel>();
    }
}
