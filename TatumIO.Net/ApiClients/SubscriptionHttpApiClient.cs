using System.Threading.Tasks;

using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.Subscriptions;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{
	internal class SubscriptionHttpApiClient : BaseTatumHttpApiClient
	{
		public SubscriptionHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey)
		{
		}

		public async Task<RestResponse<SubscriptionsList>> ListSubscriptions(int pageSize, int offset) =>
			await ExecuteAsync<SubscriptionsList>(SubscriptionRequests.ListSubscriptions(pageSize, offset));
	}
}
