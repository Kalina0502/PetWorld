using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Models.Adoption;

namespace PetWorld.Controllers
{
    [Authorize]
    public class AdoptionController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllAdoptionsQueryModel();

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new MyAnimalsForAdoptionModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new AdoptionDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdoptionFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var model = new AdoptionFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Edit (int id, AdoptionFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var model = new AdoptionDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Delete (AdoptionDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Adopt(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> ForAdoption(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}