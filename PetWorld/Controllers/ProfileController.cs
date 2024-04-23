using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Profile;

namespace PetWorld.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Create(ProfileIndexViewModel model)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Error", "Home");
            }

            var existingPetOwner = await profileService.FindPetOwnerByEmailAsync(model.Email);
            if (existingPetOwner != null)
            {
                ModelState.AddModelError("Email", "Email is already in use.");
                return View(model);
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
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            var email = User.Identity?.Name;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Error", "Home");
            }

            var existingPetOwner = await profileService.FindPetOwnerByEmailAsync(email);

            if (existingPetOwner != null)
            {
                return RedirectToAction("Details", new { id = existingPetOwner.Id });
            }
            else
            {
                return View("Create");
            }
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