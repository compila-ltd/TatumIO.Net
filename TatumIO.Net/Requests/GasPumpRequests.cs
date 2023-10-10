using System;
using System.Text.Json;

using RestSharp;

using TatumIO.Net.Objects.GasPump.Payload;

namespace TatumIO.Net.Requests
{
	internal static class GasPumpRequests
	{
		public static TatumRequest PrecalculateAddresses(PrecalculateAddressesPayload payload) =>
			new TatumRequest(new RestRequest($"/", Method.Post).AddBody(JsonSerializer.Serialize(payload))).WithApiKey();

		public static TatumRequest ActivateAddresses(IGasPumpActivationPayload payload)
		{
			var request = new RestRequest($"/activate", Method.Post);

			var body = payload switch
			{
				var payloadToSerlialize when payload is ActivateAddressesTatumPayload => JsonSerializer.Serialize((ActivateAddressesTatumPayload)payloadToSerlialize),
				var payloadToSerlialize when payload is ActivateAddressesKMSPayload => JsonSerializer.Serialize((ActivateAddressesKMSPayload)payloadToSerlialize),
				_ => throw new NotImplementedException()
			};

			return new TatumRequest(request.AddBody(body)).WithApiKey();
		}

		public static TatumRequest AddressIsActivated(string chain, string address, long index) =>
			new TatumRequest(new RestRequest($"/activated/{chain}/{address}/{index}", Method.Get)).WithApiKey();
	}
}
