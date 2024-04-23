using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Attributes;
using PetWorld.Core.Constants;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models;
using PetWorld.Core.Models.Adoption;
using PetWorld.Core.Services;
using System.Security.Claims;

namespace PetWorld.Controllers
{
    public class AdoptionController : BaseController
    {
        private readonly IAdoptionService adoptionService;

        private readonly IAgentService agentService;

        public AdoptionController(
            IAdoptionService _adoptionService,
            IAgentService agentService)
        {
            adoptionService = _adoptionService;
            this.agentService = agentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllAdoptionsQueryModel model)
        {
            var adoptionPets = await adoptionService.AllAsync(
                model.Species,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.AdoptionPetsPerPage);

            model.TotalAdoptionPetsCount = adoptionPets.TotalAdoptionPetsCount;
            model.Adoptions = adoptionPets.AdoptionPets;
            model.SpeciesList = await adoptionService.AllSpeciesNamesAsync();

            var totalPages = (int)Math.Ceiling((double)model.TotalAdoptionPetsCount / model.AdoptionPetsPerPage);
            var аllAdoptionsQueryModel = new AllAdoptionsQueryModel
            {
                CurrentPage = model.CurrentPage,
                TotalPages = totalPages,
                HasPreviousPage = model.CurrentPage > 1,
                HasNextPage = model.CurrentPage < totalPages
            };

            ViewBag.PaginationViewModel = аllAdoptionsQueryModel;


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Adopt(int id, PetOwnerFormModel petOwnerModel)
        {
            //   if (await adoptionService.SpeciesExistsAsync(id) == false)
            // {
            //     return BadRequest();
            // }

            if (await agentService.ExistsByIdAsync(User.Id()) == false)
            //&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await adoptionService.IsAdoptedAsync(id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(petOwnerModel);
            }


            return RedirectToAction(nameof(ProvideOwnerDetails), new { adoptionId = id });


            //  await adoptionService.AdoptAsync(id, User.Id(), petOwnerModel);

            //TempData[MessageConstants.UserMessageSuccess] = "You have successfully adopted the pet! We will call you soon!";

            //return RedirectToAction(nameof(All));
        }



        [HttpPost]
        public async Task<IActionResult> ProvideOwnerDetails(int adoptionId, PetOwnerFormModel petOwnerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(petOwnerModel);
            }

            // Продължаване с процеса по осиновяване
            await adoptionService.AdoptAsync(adoptionId, User.Id(), petOwnerModel);

            TempData[MessageConstants.UserMessageSuccess] = "You have successfully adopted the pet! We will call you soon!";

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<AdoptionServiceModel> model;

            //  if (User.IsAdmin())
            //{
            //  return RedirectToAction("Mine", "House", new { area = "Admin" });
            //}

            if (await agentService.ExistsByIdAsync(userId))
            {
                int agentId = await agentService.GetAgentIdAsync(userId) ?? 0;
                model = await adoptionService.AllAdoptionsByAgentIdAsync(agentId);
            }
            else
            {
                model = await adoptionService.AllAdoptionsByUserId(userId);
            }

            return View(model);
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
            var model = new AdoptionFormModel()
            {
                AllSpecies = await adoptionService.AllSpeciesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(AdoptionFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.AllSpecies = await adoptionService.AllSpeciesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newAdoptionId = await adoptionService.CreateAsync(model, agentId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newAdoptionId, /*information = model.GetInformation()*/ });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await adoptionService.SpeciesExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await adoptionService.AdoptionDetailsByIdAsync(id);

            //if (information != model.GetInformation())
            //{
            //  return BadRequest();
            //x}

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await adoptionService.HasAgentWithIdAsync(id, User.Id()) == false)
            //&& User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await adoptionService.GetAdoptionFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdoptionFormModel model)
        {
            if (await adoptionService.SpeciesExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await adoptionService.HasAgentWithIdAsync(id, User.Id()) == false)
            //      && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                model.AllSpecies = await adoptionService.AllSpeciesAsync();

                return View(model);
            }

            await adoptionService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await adoptionService.SpeciesExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await adoptionService.HasAgentWithIdAsync(id, User.Id()) == false)
            //  && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var adoption = await adoptionService.AdoptionDetailsByIdAsync(id);

            var model = new AdoptionDetailsViewModel()
            {
                Id = adoption.Id,
                City = adoption.City,
                ImageUrl = adoption.ImageUrl,
                Name = adoption.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AdoptionDetailsViewModel model)
        {
            if (await adoptionService.SpeciesExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await adoptionService.HasAgentWithIdAsync(model.Id, User.Id()) == false)
            //  && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await adoptionService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

    }
}