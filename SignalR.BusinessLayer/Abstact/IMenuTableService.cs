using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstact
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int TMenuTableCount();
    }
}
