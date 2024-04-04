using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Models.Agent;

namespace PetWorld.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            var model = new BecomeAgentFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become (BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(AdoptionController.All), "Adoption");
        }
    }
}