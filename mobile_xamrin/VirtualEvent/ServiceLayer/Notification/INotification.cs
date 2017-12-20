using System;
using System.Threading.Tasks;

namespace VirtualEvent
{
	public interface INotificationService
	{
		Task<NotificationResponse> GetEventList(NotificationRequest model, ServiceType ServiceType, string Authkey);
	}
}
