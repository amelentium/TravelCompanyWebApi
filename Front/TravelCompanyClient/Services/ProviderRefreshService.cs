using System;

namespace TravelCompanyClient.Services
{
	public class ProviderRefreshService
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.DynamicInvoke();
        }
    }
}
