using System.Collections.Generic;
using System.Threading.Tasks;

using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.GasPump;
using TatumIO.Net.Objects.GasPump.Payload;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{

    internal class GasPumpHttpApiClient : BaseTatumHttpApiClient
	{
		public GasPumpHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey)
		{

		}

		public async Task<RestResponse<List<string>>> PrecalculateAddresses(PrecalculateAddressesPayload payload) =>
			await ExecuteAsync<List<string>>(GasPumpRequests.PrecalculateAddresses(payload));

		public async Task<RestResponse<ActivateAddresses>> ActivateAddresses(IGasPumpActivationPayload payload) =>
			await ExecuteAsync<ActivateAddresses>(GasPumpRequests.ActivateAddresses(payload));

		public async Task<RestResponse<AddressIsActivated>> AddressIsActivated(string chain, string owner, long index) =>
			await ExecuteAsync<AddressIsActivated>(GasPumpRequests.AddressIsActivated(chain, owner, index));
	}
}
