using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
