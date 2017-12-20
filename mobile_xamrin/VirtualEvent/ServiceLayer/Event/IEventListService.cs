using System;
using System.Threading.Tasks;

namespace VirtualEvent
{
	public interface IEventListService
	{
		Task<EventResponse> GetEventList(EventRequest model, ServiceType ServiceType, string Authkey);
		Task<EventResponse> GetEnrolledEventsList(EventRequest model, ServiceType ServiceType, string Authkey);
		Task<EventDetailResponse> GetEventDetail(EventDetailRequest model, ServiceType ServiceType, string Authkey);

	}
}
