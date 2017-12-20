using System;
using System.Collections.Generic;

namespace VirtualEvent
{
	public class EventResponse
	{
		public bool IsSuccess { get; set; }
		public string Status { get; set; }
		public string Message { get; set; }
		public List<EventList> Result { get; set; }
	}


	public class EventList
	{
		public int TotalCount { get; set; }
		public string Title { get; set; }
		public DateTime DateOfEvent { get; set; }
		public string TimeOfEvent { get; set; }
		public string Venue { get; set; }
		public string MediaUrl { get; set; }
		public string Description { get; set; }
		public DateTime EnrolmentDate { get; set; }
		public string LiveStreamUrl { get; set; }
		public bool IsEnrolled { get; set; }
		public string Presenter { get; set; }
		public string EventDateString { get; set; }
		public int EventId { get; set; }

	}



}
