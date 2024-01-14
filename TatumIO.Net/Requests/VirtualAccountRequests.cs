using RestSharp;

namespace TatumIO.Net.Requests
{
	internal static class VirtualAccountRequests
	{
		public static TatumRequest GetAccountInfo(string accountId) => new TatumRequest(new RestRequest($"/{accountId}", Method.Get)).WithApiKey();

		public static TatumRequest CreateDepositAddress(string accountId, long? index)
		{
			var requestPath = $"/{accountId}/address";
			if (index.HasValue)
				requestPath += $"?index={index.Value}";
			return new TatumRequest(new RestRequest(requestPath, Method.Post)).WithApiKey();
		}

		public static TatumRequest AssignNewAddress(string accountId, string address) => new TatumRequest(new RestRequest($"/{accountId}/address/{address}", Method.Post)).WithApiKey();

		public static TatumRequest AddressIsAssigned(string address, string currency) => new TatumRequest(new RestRequest($"/address/{address}/{currency}", Method.Get)).WithApiKey();
	}
}
