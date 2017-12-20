using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VirtualEvent
{
	public class EventListService : IEventListService
	{
		private ServiceUtils _objUtility;
		public EventListService()
		{
			_objUtility = new ServiceUtils();
		}

		public async Task<EventResponse> GetEnrolledEventsList(EventRequest model, ServiceType ServiceType, string Authkey)
		{
			EventResponse response = new EventResponse();

			var result = await _objUtility.AllApiInterface(ApiRouteConstant.PurchasedEvents, (int)Method.POST, model, ServiceType, Authkey);
			if (result != null)
			{
				response = JsonConvert.DeserializeObject<EventResponse>(result);
			}
			return response;
		}

		public async Task<EventDetailResponse> GetEventDetail(EventDetailRequest model, ServiceType ServiceType, string Authkey)
		{
			EventDetailResponse response = new EventDetailResponse();

			var result = await _objUtility.AllApiInterface(ApiRouteConstant.EventDetail, (int)Method.POST, model, ServiceType, Authkey);
			if (result != null)
			{
				response = JsonConvert.DeserializeObject<EventDetailResponse>(result);
			}
			return response;
		}

		public async Task<EventResponse> GetEventList(EventRequest model, ServiceType ServiceType, string Authkey)
		{
			EventResponse response = new EventResponse();

			var result = await _objUtility.AllApiInterface(ApiRouteConstant.Events, (int)Method.POST, model, ServiceType, Authkey);
			if (result != null)
			{
				response = JsonConvert.DeserializeObject<EventResponse>(result);
			}
			return response;
		}
	}
}
