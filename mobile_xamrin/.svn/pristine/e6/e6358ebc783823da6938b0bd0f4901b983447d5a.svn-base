using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VirtualEvent.BusinessLayer.Authentication;

namespace VirtualEvent
{
    public class LoginService : ILoginService
    {
        private ServiceUtils _objUtility;

        public LoginService()
        {
            _objUtility = new ServiceUtils();
        }



        public async Task<AuthkeyResponse> GetAuthkey(AuthkeyRequest model, ServiceType ServiceType)
        {
            AuthkeyResponse response = new AuthkeyResponse();

            var result = await _objUtility.AuthkeyApiInterface(ApiRouteConstant.GenerateToken, (int)Method.POST, model, ServiceType);
            if (result != null)
            {
                response = JsonConvert.DeserializeObject<AuthkeyResponse>(result);
            }
            return response;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest model, ServiceType ServiceType, string Authkey)
        {
            LoginResponse response = new LoginResponse();

            var result = await _objUtility.AllApiInterface(ApiRouteConstant.UserLogin, (int)Method.POST, model, ServiceType, Authkey);
            if (result != null)
            {
                response = JsonConvert.DeserializeObject<LoginResponse>(result);
            }
            return response;
        }



        public async Task<LogoutResponse> LogoutUser(ServiceType ServiceType, string Authkey)
        {
            LogoutResponse response = new LogoutResponse();
            var result = await _objUtility.AllApiInterface(ApiRouteConstant.Logout, (int)Method.POST, null, ServiceType, Authkey);
            if (result != null)
            {
                response = JsonConvert.DeserializeObject<LogoutResponse>(result);
            }
            return response;
        }

        public async Task<LoginResponse> SocialLoginUser(UserSocialLoginRequest model, ServiceType ServiceType, string Authkey)
        {
            LoginResponse response = new LoginResponse();

            var result = await _objUtility.AllApiInterface(ApiRouteConstant.SocialUserLogin, (int)Method.POST, model, ServiceType, Authkey);
            if (result != null)
            {
                response = JsonConvert.DeserializeObject<LoginResponse>(result);
            }
            return response;
        }


    }
}
