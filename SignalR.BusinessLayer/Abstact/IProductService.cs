using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstact
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
         int TProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductAvgPriceByHamburger();
    }
   
}
