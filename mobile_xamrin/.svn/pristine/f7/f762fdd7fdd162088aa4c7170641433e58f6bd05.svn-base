using System;
using System.Threading.Tasks;
using VirtualEvent.BusinessLayer.Authentication;

namespace VirtualEvent
{
	public interface ILoginService
	{
		Task<AuthkeyResponse> GetAuthkey(AuthkeyRequest model,ServiceType ServiceType);
		Task<LoginResponse> LoginUser(LoginRequest model,ServiceType ServiceType,string Authkey);
        Task<LoginResponse> SocialLoginUser(UserSocialLoginRequest model, ServiceType ServiceType, string Authkey);
        Task<LogoutResponse>LogoutUser(ServiceType ServiceType,string Authkey);
	}
}
