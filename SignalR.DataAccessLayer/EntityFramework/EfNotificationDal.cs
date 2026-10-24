using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

        public List<Notification> GetNotificationByFalse()
        {
           using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
		{
			using var contex = new SignalRContext();
			return contex.Notifications.Where(x=>x.Status==false).Count();
		}

        public void NotificationStatusChangeToFalse(int id)
        {
            using var contex = new SignalRContext();
            var value = contex.Notifications.Find(id);
            value.Status = false;
            contex.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var contex = new SignalRContext();
            var value=contex.Notifications.Find(id);
            value.Status = true;
            contex.SaveChanges();
        }
    }
}
