using RestSharp;

namespace TatumIO.Net.Requests
{
	internal class SubscriptionRequests
	{
		public static TatumRequest ListSubscriptions(int pageSize, int offset) => new TatumRequest(new RestRequest($"/?pageSize={pageSize}&offset={offset}", Method.Get)).WithApiKey();
	}
}
