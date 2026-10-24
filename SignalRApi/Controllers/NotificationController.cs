using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstact;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{

			return Ok(_notificationService.TGetListAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetNotificationByFalse")]
        public IActionResult GetNotificationByFalse()
        {
            return Ok(_notificationService.TGetNotificationByFalse());
        }
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification=new Notification()
			{
				Description = createNotificationDto.Description,
				Status = false,
				Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
				Icon = createNotificationDto.Icon,
				Type = createNotificationDto.Type,
			};
			_notificationService.TAdd(notification);
			return Ok("Ekleme işlemi başarıyla yapıldı.");
		}
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
				NotificationID = updateNotificationDto.NotificationID,
                Description = updateNotificationDto.Description,
                Status = updateNotificationDto.Status,
                Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString()),
                Icon = updateNotificationDto.Icon,
                Type = updateNotificationDto.Type,
            };
            _notificationService.TUpdate(notification);
            return Ok("Bildirim kısmı başarılı bir şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Güncelleme yapıldı");
		}

		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Güncelleme yapıldı");
		}
	}
}
