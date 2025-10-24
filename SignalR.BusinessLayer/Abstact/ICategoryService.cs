using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstact
{
    public interface ICategoryService : IGenericService<Category>
    {
         int TCategoryCount();
        int TActiveCategoryCount();
        int TPassiveCategoryCount();
    }
   
}
