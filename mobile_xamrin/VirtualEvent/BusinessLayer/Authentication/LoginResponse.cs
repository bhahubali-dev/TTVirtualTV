using System;
namespace VirtualEvent
{
	public class LoginResponse
	{
		public bool IsSuccess { get; set; }
		public string Status { get; set; }
		public string Message { get; set; }
		public Result Result { get; set; }
	}
}
