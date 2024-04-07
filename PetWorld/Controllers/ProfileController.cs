using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Models.Profile;

namespace PetWorld.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var model = new ProfileIndexViewModel();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var model = new ProfileEditViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileEditViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> MyPets()
        {
            var model = new MyPetsViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyReservations()
        {
            var model = new MyReservationsViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyGroomingAppointments()
        {
            var model = new MyGroomingAppointmentsViewModel();
            return View(model);
        }
    }
}