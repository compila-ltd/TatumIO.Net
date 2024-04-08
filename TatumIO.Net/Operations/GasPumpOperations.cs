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
		Task<TatumBaseResponse> PrecalculateAddresses(PrecalculateAddressesPayload payload);
		/// <summary>
		/// Activate addresses in blockchain.
		/// </summary>
		/// <param name="payload">
		/// Related Owner address payload to activate from.
		/// </param>
		/// <returns>
		/// Response containing TxId or Signature Id related to activation transaction.
		/// </returns>
		Task<TatumBaseResponse> ActivateAddresses(IGasPumpActivationPayload payload);
		/// <summary>
		/// Check whether an address is activated or not.
		/// </summary>
		/// <param name="chain">Chain or network.</param>
		/// <param name="owner">Owner address.</param>
		/// <param name="index">Precalculated address index.</param>
		/// <returns>Response containing activation verification.</returns>
		Task<TatumBaseResponse> AddressIsActivated(string chain, string owner, long index);
	}

	internal class GasPumpOperations : IGasPumpOperations
	{
		private readonly GasPumpHttpApiClient GasPumpEnpoint;

		public GasPumpOperations(string apiKey)
		{
			GasPumpEnpoint = new GasPumpHttpApiClient(TatumIOV3Endpoints.GasPumpUrl, apiKey);
		}

		public async Task<TatumBaseResponse> PrecalculateAddresses(PrecalculateAddressesPayload payload)
		{
			var response = await GasPumpEnpoint.PrecalculateAddresses(payload);

			if (response.IsSuccessful)
				return new TatumOkResponse<List<string>>(response.Data ?? throw new Exception(response.ErrorMessage));

			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		public async Task<TatumBaseResponse> ActivateAddresses(IGasPumpActivationPayload payload)
		{
			var response = await GasPumpEnpoint.ActivateAddresses(payload);

			if (response.IsSuccessful)
				return new TatumOkResponse<ActivateAddresses>(response.Data ?? throw new Exception(response.ErrorMessage));

			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		public async Task<TatumBaseResponse> AddressIsActivated(string chain, string owner, long index)
		{
			var response = await GasPumpEnpoint.AddressIsActivated(chain, owner, index);

			if (response.IsSuccessful)
				return new TatumOkResponse<AddressIsActivated>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}
	}
}
