using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstact
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);
    }
}
