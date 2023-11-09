namespace SaudiPieShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
