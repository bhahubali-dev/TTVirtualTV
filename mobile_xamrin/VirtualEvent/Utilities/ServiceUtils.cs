using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VirtualEvent
{
	public class ServiceUtils
	{
		readonly HttpClient _client;
		public ServiceUtils()
		{
			_client = new HttpClient();
			_client.MaxResponseContentBufferSize = 256000;

			//_client.Timeout = TimeSpan.FromSeconds(10);

		}

		public async Task<string> AllApiInterface(string methodName, int method, object data, ServiceType ServiceType, string Authkey)
		{
			string result = string.Empty;
			string url = GenerateEndPoint(methodName, ServiceType);

			string requestParameters = JsonConvert.SerializeObject(data);
			System.Diagnostics.Debug.WriteLine("------Printing Request------");
			System.Diagnostics.Debug.WriteLine("URL:-" + url);
			System.Diagnostics.Debug.WriteLine(requestParameters);
			try
			{
				var uri = new Uri(string.Format(url));
				HttpResponseMessage response;

				switch (method)
				{
					case (int)Method.POST:
						var content = new StringContent(requestParameters, Encoding.UTF8, "application/json");
						content.Headers.Add("Token", Authkey);
						response = await _client.PostAsync(uri, content);
						if (response != null)
						{
							result = await response.Content.ReadAsStringAsync();
						}
						break;
					case (int)Method.GET:
						response = await _client.GetAsync(uri);
						if (response != null)
						{
							result = await response.Content.ReadAsStringAsync();
						}
						break;
					default:
						break;
				}

			}
			catch (Exception ex)
			{
				var error = ex.Message;
			}
			System.Diagnostics.Debug.WriteLine("------Printing Response------");
			System.Diagnostics.Debug.WriteLine(result);
			return result;
		}


		public async Task<string> AuthkeyApiInterface(string methodName, int method, object data, ServiceType ServiceType)
		{
			string result = string.Empty;
			string url = GenerateEndPoint(methodName, ServiceType);

			string requestParameters = JsonConvert.SerializeObject(data);
			System.Diagnostics.Debug.WriteLine("------Printing Request------");
			System.Diagnostics.Debug.WriteLine("URL:-" + url);
			System.Diagnostics.Debug.WriteLine(requestParameters);
			try
			{
				var uri = new Uri(string.Format(url));
				HttpResponseMessage response;

				switch (method)
				{
					case (int)Method.POST:
						var content = new StringContent(requestParameters, Encoding.UTF8, "application/json");
						response = await _client.PostAsync(uri, content);
						if (response != null)
						{
							result = await response.Content.ReadAsStringAsync();
						}
						break;
					case (int)Method.GET:
						response = await _client.GetAsync(uri);
						if (response != null)
						{
							result = await response.Content.ReadAsStringAsync();
						}
						break;
					default:
						break;
				}

			}
			catch (Exception ex)
			{
				var error = ex.Message;
			}
			System.Diagnostics.Debug.WriteLine("------Printing Response------");
			System.Diagnostics.Debug.WriteLine(result);
			return result;
		}
		private string GenerateEndPoint(string methodName, ServiceType serviceType)
		{

			return ApiRouteConstant.BaseUrl + serviceType + "/" + methodName;
		}
	}
}
