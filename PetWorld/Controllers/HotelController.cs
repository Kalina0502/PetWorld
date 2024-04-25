using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetWorld.Attributes;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Hotel;
using PetWorld.Core.Services;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PetWorld.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotelService hotelService;

        private readonly IAgentService agentService;

        private readonly IRepository repository;

        public HotelController(
            IHotelService _hotelService, IAgentService agentService, IRepository repository)
        {
            hotelService = _hotelService;
            this.agentService = agentService;
            this.repository = repository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllHotelRoomsQueryModel model)
        {
            var hotelRoom = await hotelService.AllAsync(
                model.RoomType,
                model.CheckInDate,
                model.CheckOutDate);

            if (hotelRoom != null)
            {
                model.HotelRooms = new List<HotelRoomServiceModel> { hotelRoom };
                model.TotalHotelRoomsCount = 1;
            }
            else
            {
                model.HotelRooms = new List<HotelRoomServiceModel>();
                model.TotalHotelRoomsCount = 0;
            }

            model.RoomTypes = await hotelService.AllRoomTypeNamesAsync();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Reserve(int roomId, DateTime checkInDate, DateTime checkOutDate, bool includesFood, bool includesWalk)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            await hotelService.ReserveRoomAsync(roomId, checkInDate, checkOutDate, includesFood, includesWalk, userId);

            TempData["SuccessMessage"] = "Reservation made successfully !";

            return RedirectToAction("All");
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
            var model = new HotelRoomFormModel()
            {
                AllRoomTypes = await hotelService.AllRoomTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(HotelRoomFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.AllRoomTypes = await hotelService.AllRoomTypesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newhotelRoomId = await hotelService.CreateAsync(model, agentId ?? 0);

            TempData["SuccessMessage"] = "Successfully added a new room!";

            return RedirectToAction(nameof(All), new { id = newhotelRoomId, /*information = model.GetInformation()*/ });
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var rooms = await hotelService.GetAllRoomsAsync();

            return View(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HotelRoomServiceModel model)
        {
            await hotelService.DeleteAsync(model.Id);

            return RedirectToAction("Details");
        }

    }
}

