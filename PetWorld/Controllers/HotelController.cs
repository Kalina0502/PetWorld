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
        public async Task<IActionResult> All([FromQuery]AllHotelRoomsQueryModel model)
        {
           var hotelRooms =  await hotelService.AllAsync(
               model.RoomType,
               model.CheckInDate,
               model.CheckOutDate,
               model.Sorting,
               model.CurrentPage,
               model.HotelRoomsPerPage);

            model.TotalHotelRoomsCount = hotelRooms.TotalRoomsCount;
            model.HotelRooms = hotelRooms.HotelRooms;
            model.RoomTypes = await hotelService.AllRoomTypeNamesAsync();
            return View(model);
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
        //public async Task<IActionResult> Book(int id)
        //{
        //    return RedirectToAction(nameof(Mine));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Leave(int id)
        //{
        //    return RedirectToAction(nameof(Mine));
        //}
    }
}