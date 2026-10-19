using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstact;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
               ProductID=createBasketDto.ProductID,
               Price= context.Products.Where(x=>x.ProductID==createBasketDto.ProductID).Select(y=>y.Price).FirstOrDefault(),
               Count=1,
               TotalPrice=0,
               MenuTableID=4,
            });
            return Ok("Sepete başarılı bir şekilde eklendi.");
        }
        [HttpGet]   
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values=_basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID=z.BasketID,
                Count=z.Count,
                 MenuTableID=z.MenuTableID,
                 Price=z.Price,
                 ProductID=z.ProductID,
                 TotalPrice=z.TotalPrice,
                 ProductName=z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki seçilen ürün başarılı bir şekilde silindi.");

        }
    }
}
