using Microsoft.AspNetCore.Mvc;
using SaudiPieShop.Models;
using SaudiPieShop.ViewModels;

namespace SaudiPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModle=new HomeViewModel(piesOfTheWeek);
            return View(homeViewModle);
        }
    }
}
