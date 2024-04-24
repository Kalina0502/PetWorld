using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Hotel;
using PetWorld.Core.Models.Profile;
using PetWorld.Core.Services;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data.Models;
using System.Security.Claims;

namespace PetWorld.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IRepository repository;
        private readonly IAdoptionService adoptionService;
        private readonly IAgentService agentService;
        private readonly IProfileService profileService;
        private readonly IHotelService hotelService;
        private readonly IPetOwnerService petOwnerService;

        public ProfileController(
            IRepository repository,
            IAdoptionService _adoptionService,
            IAgentService agentService,
            IProfileService profileService,
            IHotelService hotelService,
            IPetOwnerService petOwnerService)
        {
            this.repository = repository;
            adoptionService = _adoptionService;
            this.agentService = agentService;
            this.profileService = profileService;
            this.hotelService = hotelService;
            this.petOwnerService = petOwnerService;
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

            var existingPetOwner = await petOwnerService.FindPetOwnerByEmailAsync(model.Email);
            if (existingPetOwner != null)
            {
                ModelState.AddModelError("Email", "Email is already in use.");
                return View(model);
            }

            int newPetOwnerId = await petOwnerService.CreateAsync(model, userId);

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

            var existingPetOwner = await petOwnerService.FindPetOwnerByEmailAsync(email);

            if (existingPetOwner != null)
            {
                return RedirectToAction((nameof(Details)), new { id = existingPetOwner.Id });
            }
            else
            {
                return View("Create");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            // Извличане на информация за `PetOwner`
            var petOwner = await petOwnerService.FindPetOwnerByIdAsync(userId);

            // Проверка дали `PetOwner` съществува
            if (petOwner == null)
            {
                return RedirectToAction("Error", "Home");
            }

            // Извличане на списъка с животни
            var pets = await petOwnerService.GetPetsByOwnerIdAsync(petOwner.Id);

            // Извличане на списъка с резервации за хотел
            var hotelReservations = await hotelService.GetUserReservationsAsync(userId);
            /// var hotelReservations = await hotelService.GetReservationsByOwnerIdAsync(petOwner.Id);

            // Извличане на списъка с осиновени животни
            // var adoptions = await adoptionService.GetAdoptionsByOwnerIdAsync(petOwner.Id);

            string genderType = await petOwnerService.GetGenderTypeByIdAsync(petOwner.GenderId);

            // Създаване на модел за данни
            var model = new ProfileDetailsViewModel
            {
                Id = id,
                PetOwner = petOwner,
                Pets = pets,
                HotelReservations = hotelReservations,
                Gender = genderType
                //Adoptions = adoptions

            };

            // Връщане на `View` с модела за данни
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            // Извличане на userId на текущия потребител
            var userId = User.Id();

            // Извличане на обект PetOwner с даден userId
            var petOwner = await profileService.GetPetOwnerByUserIdAsync(userId);

            // Проверка дали е намерен PetOwner
            if (petOwner == null)
            {
                // Ако няма PetOwner с този userId, връщане на NotFound()
                return NotFound();
            }

            var model = await profileService.GetProfileIndexViewModelByIdAsync(userId);

            // Връщане на изглед с модела за редактиране
            return View(model);
        }


        // Метод за обработка на заявката за редактиране
        [HttpPost]
        public async Task<IActionResult> Edit(ProfileIndexViewModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            if (userId == null)
            {
                return NotFound();
            }

            // Актуализиране на информацията за собственика
            await profileService.UpdatePetOwnerAsync(model, userId);

            // Пренасочване към страницата за детайли
            return RedirectToAction(nameof(Details), new { userId });
        }





        [HttpGet]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            // Извличане на резервация по id
            //var reservation = await repository.AllReadOnly<RoomReservation>()
            //                                  .FirstOrDefaultAsync(r => r.Id == id);

            var roomReservation = await hotelService.ReservationDetailsByIdAsync(id);
            //var model = await hotelService.GetHotelRoomServiceModelByIdAsync(reservation);

            // Създаване на модел за изтриване
            var model = new HotelRoomServiceModel
            {
                Id = roomReservation.Id,
                CheckInDate = roomReservation.CheckInDate,
                CheckOutDate = roomReservation.CheckOutDate,
                IncludesFood = roomReservation.IncludesFood,
                IncludesWalk = roomReservation.IncludesWalk,
            };

            // Връщане на изгледа за изтриване с модела
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(HotelRoomServiceModel model)
        {
            await hotelService.DeleteAsync(model.Id);

            TempData["SuccessMessage"] = "Reservation successfully deleted.";

            return RedirectToAction("Details");
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