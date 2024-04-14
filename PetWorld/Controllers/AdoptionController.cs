using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetWorld.Attributes;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Adoption;
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
            model.SpeciesList = await adoptionService.AllSpeciesCategoriesAsync();

            return View(model);
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
                Species = await adoptionService.AllSpeciesNamesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(AdoptionFormModel model)
        {
            if (await adoptionService.SpeciesExistsAsync(model.SpeciesId) == false)
            {
                ModelState.AddModelError(nameof(model.SpeciesId), "Species does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Species = await adoptionService.AllSpeciesNamesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newAdoptionId = await adoptionService.CreateAsync(model, agentId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newAdoptionId, /*information = model.GetInformation()*/ });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await adoptionService.ExistsAsync(id) == false)
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
            if (await adoptionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

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
            if (await adoptionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await adoptionService.HasAgentWithIdAsync(id, User.Id()) == false)
            //      && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await adoptionService.SpeciesExistsAsync(model.SpeciesId) == false)
            {
                ModelState.AddModelError(nameof(model.SpeciesId), "Species does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Species = await adoptionService.AllSpeciesNamesAsync();

                return View(model);
            }

            await adoptionService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await adoptionService.ExistsAsync(id) == false)
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
            if (await adoptionService.ExistsAsync(model.Id) == false)
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

        [HttpPost]
        public async Task<IActionResult> ForAdoptionAsync(int id)
        {
            if (await adoptionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await agentService.ExistsByIdAsync(User.Id()))
            //  && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await adoptionService.IsAdoptedAsync(id))
            {
                return BadRequest();
            }

            await adoptionService.ForAdoptionAsync(id, User.Id());

           // TempData[UserMessageSuccess] = "You have successfully adopted the pet.";
            return RedirectToAction(nameof(All));
        }
    }
}