using System.Text.Json;

using RestSharp;
using TatumIO.Net.Objects.GasPump.Payload;

namespace TatumIO.Net.Requests
{
    internal static class GasPumpRequests
	{
		public static TatumRequest PrecalculateAddresses(PrecalculateAddressesPayload payload) =>
			new TatumRequest(new RestRequest($"/", Method.Post).AddBody(JsonSerializer.Serialize(payload))).WithApiKey();

		public static TatumRequest ActivateAddresses(ActivateAddressesPayload payload) =>
			new TatumRequest(new RestRequest($"/activate", Method.Post).AddBody(JsonSerializer.Serialize(payload))).WithApiKey();

		public static TatumRequest AddressIsActivated(string chain, string address, long index) =>
			new TatumRequest(new RestRequest($"/activated/{chain}/{address}/{index}", Method.Get)).WithApiKey();
	}
}
