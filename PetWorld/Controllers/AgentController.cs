﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Contracts;
using PetWorld.Core.Models.Agent;
using PetWorld.Core.Services;

namespace PetWorld.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

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