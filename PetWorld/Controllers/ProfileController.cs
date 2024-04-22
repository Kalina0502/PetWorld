using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Attributes;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Models.Profile;
using PetWorld.Core.Services;
using System.Security.Claims;

namespace PetWorld.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IAdoptionService adoptionService;

        private readonly IAgentService agentService;
        private readonly IProfileService profileService;

        public ProfileController(
            IAdoptionService _adoptionService,
            IAgentService agentService,
            IProfileService profileService)
        {
            adoptionService = _adoptionService;
            this.agentService = agentService;
            this.profileService = profileService;
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Create()
        {
            var model = new PetOwnerFormModel()
            {

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profil(ProfileIndexViewModel model)
        {
            // Проверка на валидността на модела
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Identity?.Name;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Error", "Home");
            }

            int newPetOwnerId = await profileService.CreateAsync(model, userId);

            if (newPetOwnerId != 0)
            {
                return RedirectToAction("Details", new { id = newPetOwnerId });
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

        }



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