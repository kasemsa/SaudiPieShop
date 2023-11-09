namespace SaudiPieShop.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly SaudiPieShopDbContext _saudiPieShopDbContext;

        public CategoryRepository(SaudiPieShopDbContext saudiPieShopDbContext)
        {
            _saudiPieShopDbContext = saudiPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _saudiPieShopDbContext.Categories.OrderBy(c=>c.CategoryName);
    }
}
