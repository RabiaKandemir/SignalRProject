using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        { 
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7103/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            var errorMessage = await responseMessage.Content.ReadAsStringAsync();

            ModelState.AddModelError(
                string.Empty,
                $"Rezervasyon oluşturulamadı. HTTP: {(int)responseMessage.StatusCode}. {errorMessage}");

            return View("Index", createBookingDto);
        }
    }
}
