using System;
namespace VirtualEvent
{
	public class Constant
	{
		public const string IsOnline = "IsOnline";
	}
	public enum EnumDeviceType
	{
		IOS = 2,
		Android = 1,
	}
	public enum Method
	{
		GET,
		POST,
		PUT,
		PETCH,
		DELE
	}

	public enum ServiceType
	{
		EventService,
		SessionService,
		UserService,
		NotificationService
	}

	public enum QuestionStatus
	{
		Approved = 1,
		Pending = 2,
		Rejected = 3,
		Deleted = 4
	}

    public enum LoginTypes
    {
        NativeWeb = 1,
        NativeApp = 2,
        Google = 3,
        Facebook = 4
    }
}
