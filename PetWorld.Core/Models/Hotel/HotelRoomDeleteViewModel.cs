namespace PetWorld.Core.Models.Hotel
{
    public class HotelRoomDeleteViewModel
    {
        public IEnumerable<string> RoomTypes { get; set; } = Enumerable.Empty<string>();
        public string SelectedRoomType { get; set; } = string.Empty;
    }
}
