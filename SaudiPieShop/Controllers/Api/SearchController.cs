using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudiPieShop.Models;

namespace SaudiPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public IPieRepository _pieRepository { get; }

        public SearchController(IPieRepository pieRepository)
        {
            this._pieRepository = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_pieRepository.AllPies);
        }

        
        [HttpGet]
        public IActionResult GetById(int id)
        {
            if (!_pieRepository.AllPies.Any(p => p.PieId == id))
            {
                return NotFound();
            } 
            else
            {
                return Ok(_pieRepository.AllPies.Where(p=>p.PieId==id)); 
            }
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchQuery))
            { 
                pies=_pieRepository.SearchPies(searchQuery);
            }
            return new JsonResult(pies);
        
        }
    }
}
