using Microsoft.AspNetCore.Mvc;
using PetWorld.Attributes;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Agent;
using System.Security.Claims;
using static PetWorld.Core.Constants.MessageConstants;

namespace PetWorld.Controllers
{
    public class AgentController : BaseController
    {

        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        [NotAnAgent]
        public IActionResult JoinUs()
        {
            var model = new JoinUsFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> JoinUs(JoinUsFormModel model)
        {
            if (await agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await agentService.CreateAsync(User.Id(), model.PhoneNumber);

            return RedirectToAction(nameof(AdoptionController.All), "Adoption");
        }
    }
}