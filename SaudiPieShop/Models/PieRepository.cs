using Microsoft.EntityFrameworkCore;

namespace SaudiPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly SaudiPieShopDbContext _saudiPieShopDbContext;

        public PieRepository(SaudiPieShopDbContext saudiPieShopDbContext)
        {
            _saudiPieShopDbContext = saudiPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _saudiPieShopDbContext.Pies.Include(c => c.Category);
            }

        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get 
            {
                return _saudiPieShopDbContext.Pies.Include(c => c.Category).Where(p=>p.IsPieOfTheWeek);
            }
        
        }

        public Pie? GetPieById(int pieId)
        {
            return _saudiPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _saudiPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));

        }
    }
}
