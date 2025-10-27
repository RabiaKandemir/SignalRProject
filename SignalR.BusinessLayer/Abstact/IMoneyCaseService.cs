using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstact
{
    public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal TTotalMoneyCaseAmount();
    }
}
