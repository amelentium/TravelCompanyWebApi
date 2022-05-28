using Microsoft.AspNetCore.Http;

namespace TravelCompany.Application.Service
{
	public class RequestProviderService : IRequestProviderService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public RequestProviderService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string Provider => _httpContextAccessor
			.HttpContext
			.Request
			.Query
			.FirstOrDefault(x => x.Key.ToLower() == "provider")
			.Value
			.ToString()
			.ToLower();
	}
}
