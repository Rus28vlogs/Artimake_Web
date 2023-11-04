using Microsoft.AspNetCore.Mvc;

namespace Artimake_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
