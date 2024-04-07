using Microsoft.AspNetCore.Mvc;
using PetWorld.Core.Contracts.Adoption;
using PetWorld.Core.Models.Home;
using PetWorld.Models;
using System.Diagnostics;

namespace PetWorld.Controllers
{
    public class HomeController : Controller
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

        public async Task<IActionResult> Index()
        {
            var model = await adoptionService.LastTrheePets();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
