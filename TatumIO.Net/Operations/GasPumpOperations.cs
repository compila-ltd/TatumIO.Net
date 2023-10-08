using System.Collections.Generic;
using System.Threading.Tasks;

using Compila.Net.Utils.ServiceResponses;

using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.GasPump;
using TatumIO.Net.Objects.GasPump.Payload;

namespace TatumIO.Net.Operations
{
	public interface IGasPumpOperations
	{
		Task<ServiceBaseResponse> PrecalculateAddresses(PrecalculateAddressesPayload payload);
		Task<ServiceBaseResponse> ActivateAddresses(ActivateAddressesPayload payload);
		Task<ServiceBaseResponse> AddressIsActivated(string chain, string owner, long index);
	}

	internal class GasPumpOperations : IGasPumpOperations
	{
		private readonly GasPumpHttpApiClient GasPumpEnpoint;

		public GasPumpOperations(string apiKey)
		{
			GasPumpEnpoint = new GasPumpHttpApiClient(TatumIOV3Endpoints.GasPumpUrl, apiKey);
		}

		public async Task<ServiceBaseResponse> PrecalculateAddresses(PrecalculateAddressesPayload payload)
		{
			var response = await GasPumpEnpoint.PrecalculateAddresses(payload);

			if (response.IsSuccessful)
				return new ServiceOkResponse<List<string>>(response.Data ?? throw new System.Exception(response.ErrorMessage));

			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}

		public async Task<ServiceBaseResponse> ActivateAddresses(ActivateAddressesPayload payload)
		{
			var response = await GasPumpEnpoint.ActivateAddresses(payload);

			if (response.IsSuccessful)
				return new ServiceOkResponse<ActivateAddresses>(response.Data ?? throw new System.Exception(response.ErrorMessage));

			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}

		public async Task<ServiceBaseResponse> AddressIsActivated(string chain, string owner, long index)
		{
			var response = await GasPumpEnpoint.AddressIsActivated(chain, owner, index);

			if (response.IsSuccessful)
				return new ServiceOkResponse<AddressIsActivated>(response.Data ?? throw new System.Exception(response.ErrorMessage));
			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}
	}
}
