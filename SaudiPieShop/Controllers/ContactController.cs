using Microsoft.AspNetCore.Mvc;

namespace SaudiPieShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
