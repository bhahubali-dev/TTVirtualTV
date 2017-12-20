using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VirtualEvent
{
	public class NotificationService : INotificationService
	{
		private ServiceUtils _objUtility;
		public NotificationService()
		{
			_objUtility = new ServiceUtils();
		}

		public async Task<NotificationResponse> GetEventList(NotificationRequest model, ServiceType ServiceType, string Authkey)
		{
			NotificationResponse response = new NotificationResponse();

			var result = await _objUtility.AllApiInterface(ApiRouteConstant.Notifications, (int)Method.POST, model, ServiceType, Authkey);
			if (result != null)
			{
				response = JsonConvert.DeserializeObject<NotificationResponse>(result);
			}
			return response;
		}
	}
}
