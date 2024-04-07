using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetWorld.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
