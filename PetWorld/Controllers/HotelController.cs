using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Hotel;
using PetWorld.Core.Services;

namespace PetWorld.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotelService hotelService;

        public HotelController(
            IHotelService _hotelService)
        {
            hotelService = _hotelService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllHotelRoomsQueryModel model)
        {
            // Вземаме първата открита стая, която отговаря на критериите
            var hotelRoom = await hotelService.AllAsync(
                model.RoomType,
                model.CheckInDate,
                model.CheckOutDate);

            // Ако е намерена открита стая, връщаме моделът със стаята
            if (hotelRoom != null)
            {
                model.HotelRooms = new List<HotelRoomServiceModel> { hotelRoom };
                model.TotalHotelRoomsCount = 1; // Само една намерена стая
            }
            else
            {
                model.HotelRooms = new List<HotelRoomServiceModel>(); // Празен списък, ако няма намерена стая
                model.TotalHotelRoomsCount = 0; // Нула налични стаи
            }

            // Вземаме всички типове стаи за допълнителни данни
            model.RoomTypes = await hotelService.AllRoomTypeNamesAsync();

            // Връщаме модела към представката (View)
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Reserve(int roomId, DateTime checkInDate, DateTime checkOutDate, bool includesFood, bool includesWalk)
        {
            await hotelService.ReserveRoomAsync(roomId, checkInDate, checkOutDate, includesFood, includesWalk);

            return RedirectToAction("All");
        }



        //[HttpGet]
        //public async Task<IActionResult> Mine()
        //{
        //    var model = new MyRoomModel();

        //    return View(model);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var model = new RoomDetailsViewModel();

        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(RoomFormModel model)
        //{
        //    return RedirectToAction(nameof(Details), new { id = 1 });
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit()
        //{
        //    var model = new RoomFormModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, RoomFormModel model)
        //{
        //    return RedirectToAction(nameof(Details), new { id = 1 });
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete()
        //{
        //    var model = new RoomDetailsViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(RoomDetailsViewModel model)
        //{
        //    return RedirectToAction(nameof(All));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Leave(int id)
        //{
        //    return RedirectToAction(nameof(Mine));
        //}
    }
}