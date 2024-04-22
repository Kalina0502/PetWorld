﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Attributes;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Hotel;
using System.Security.Claims;

namespace PetWorld.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotelService hotelService;

        private readonly IAgentService agentService;

        public HotelController(
            IHotelService _hotelService, IAgentService agentService)
        {
            hotelService = _hotelService;
            this.agentService = agentService;
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
            await hotelService.ReserveRoomAsync(roomId, checkInDate, checkOutDate, includesFood, includesWalk);

            return RedirectToAction("All");
        }



        //[HttpGet]
        //public async Task<IActionResult> Mine()
        //{
        //    var model = new MyRoomModel();

        //    return View(model);
        //}

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

        //[HttpPost]
        //public async Task<IActionResult> Leave(int id)
        //{
        //    return RedirectToAction(nameof(Mine));
        //}
    }
}