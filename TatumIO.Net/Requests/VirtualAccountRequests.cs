using RestSharp;

using TatumIO.Net.Http;

namespace TatumIO.Net.Requests
{
	internal static class VirtualAccountRequests
	{
		public static TatumRequest GetAccountInfoRequest(string accountId) => new TatumRequest(new RestRequest($"/{accountId}", Method.Get)).WithApiKey();

		public static TatumRequest CreateDepositAddress(string accountId, int? index)
		{
			var requestPath = $"/{accountId}/address";
			
			//if index is not null, add it as a query parameter
			if (index.HasValue)
				requestPath += $"?index={index.Value}";

			return new TatumRequest(new RestRequest(requestPath, Method.Post)).WithApiKey();
		}
	}
}
