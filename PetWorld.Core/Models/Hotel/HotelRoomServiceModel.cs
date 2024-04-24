namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomServiceModel
    {
        public int Id { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public string RoomType { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

        public bool IncludesFood { get; set; }

        public bool IncludesWalk { get; set; }

    }
}