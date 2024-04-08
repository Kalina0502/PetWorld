using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Contracts;
using PetWorld.Models;
using System.Diagnostics;

namespace PetWorld.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdoptionService adoptionService;
        public HomeController(
            ILogger<HomeController> logger,
            IAdoptionService _adoptionService)
        {
            _logger = logger;
            adoptionService = _adoptionService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await adoptionService.LastTrheePetsAsync();
            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
