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
		/// <summary>
		/// Precalculate addresses from Owner Address.
		/// </summary>
		/// <param name="payload">
		/// Related Owner address payload to precalculate from.
		/// </param>
		/// <returns>
		/// Response containing List of precalculated addresses.
		/// </returns>
		Task<ServiceBaseResponse> PrecalculateAddresses(PrecalculateAddressesPayload payload);
		/// <summary>
		/// Activate addresses in blockchain.
		/// </summary>
		/// <param name="payload">
		/// Related Owner address payload to activate from.
		/// </param>
		/// <returns>
		/// Response containing TxId or Signature Id related to activation transaction.
		/// </returns>
		Task<ServiceBaseResponse> ActivateAddresses(IGasPumpActivationPayload payload);
		/// <summary>
		/// Check whether an address is activated or not.
		/// </summary>
		/// <param name="chain">Chain or network.</param>
		/// <param name="owner">Owner address.</param>
		/// <param name="index">Precalculated address index.</param>
		/// <returns>Response containing activation verification.</returns>
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

		public async Task<ServiceBaseResponse> ActivateAddresses(IGasPumpActivationPayload payload)
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
