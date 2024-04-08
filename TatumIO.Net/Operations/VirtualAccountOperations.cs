using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.VirtualAccounts;
using TatumIO.Net.QueryParams.VirtualAccounts;

namespace TatumIO.Net.Operations
{
	public interface IVirtualAccountOperations
	{
		/// <summary>
		/// Gets Tatum Virtual Account information
		/// </summary>
		/// <param name="accountId">Tatum virtual account id</param>
		/// <returns>TatumOkResponse with VirtualAccountInfo object</returns>
		/// <returns>TatumErrorResponse with error info</returns>
		Task<TatumBaseResponse> GetAccountInfo(string accountId);
		/// <summary>
		/// Create deposit address from account
		/// </summary>
		/// <param name="accountId">Tatum virtual account id</param>
		/// <param name="index">Index to generate address</param>
		/// <returns>TatumOkResponse with VirtualAccountAddress object</returns>
		/// <returns>TatumErrorResponse with error info</returns>
		Task<TatumBaseResponse> CreateDepositAddress(string accountId, long? index);
		/// <summary>
		/// Assigns new address to virtual account
		/// </summary>
		/// <param name="accountId">Tatum virtual account id</param>
		/// <param name="address">Wallet address to assign</param>
		/// <returns>TatumOkResponse with VirtualAccountAddress object</returns>
		/// <returns>TatumErrorResponse with error info</returns>
		Task<TatumBaseResponse> AssignNewAddress(string accountId, string address);
		/// <summary>
		/// Checks if wallet address is assigned to a virtual account
		/// </summary>
		/// <param name="address">Wallet address to check</param>
		/// <param name="currency">Currency to check</param>
		/// <returns>TatumOkResponse with VirtualAccountInfo</returns>
		/// <returns>TatumErrorResponse with error info</returns>
		Task<TatumBaseResponse> AddressIsAssigned(string address, string currency);

		Task<TatumBaseResponse> GetDepositsForProduct(DepositsQueryParams depositsQueryParams);
		Task<TatumBaseResponse> GetDepositsCountForProduct(DepositsQueryParams depositsQueryParams);
	}

	internal class VirtualAccountOperations : IVirtualAccountOperations
	{
		private readonly VirtualAccountHttpApiClient LedgerEndpoint;
		private readonly VirtualAccountHttpApiClient VirtualAccountLedgerEndpoint;
		private readonly VirtualAccountHttpApiClient OffchainEndpoint;

		public VirtualAccountOperations(string apiKey)
		{
			LedgerEndpoint = new VirtualAccountHttpApiClient(TatumIOV3Endpoints.LedgerUrl, apiKey);
			VirtualAccountLedgerEndpoint = new VirtualAccountHttpApiClient(TatumIOV3Endpoints.VirtualAccountsLedgerUrl, apiKey);
			OffchainEndpoint = new VirtualAccountHttpApiClient(TatumIOV3Endpoints.VirtualAccountsOffchainUrl, apiKey);
		}

		#region Account
		public async Task<TatumBaseResponse> GetAccountInfo(string accountId)
		{
			var response = await VirtualAccountLedgerEndpoint.GetAccountInfo(accountId);
			if (response.IsSuccessful)
				return new TatumOkResponse<VirtualAccountInfo>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		#endregion
		#region Blockchain Address

		public async Task<TatumBaseResponse> CreateDepositAddress(string accountId, long? index)
		{
			var response = await OffchainEndpoint.CreateDepositAddress(accountId, index);
			if (response.IsSuccessful)
				return new TatumOkResponse<VirtualAccountAddress>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		public async Task<TatumBaseResponse> AssignNewAddress(string accountId, string address)
		{
			var response = await OffchainEndpoint.AssignNewAddress(accountId, address);
			if (response.IsSuccessful)
				return new TatumOkResponse<VirtualAccountAddress>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		public async Task<TatumBaseResponse> AddressIsAssigned(string address, string currency)
		{
			var response = await OffchainEndpoint.AddressIsAssigned(address, currency);

			if (response.IsSuccessful)
				return new TatumOkResponse<VirtualAccountInfo>(response.Data ?? throw new Exception(response.ErrorMessage));

			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		#endregion
		#region Deposits

		public async Task<TatumBaseResponse> GetDepositsForProduct(DepositsQueryParams depositsQueryParams)
		{
			var response = await LedgerEndpoint.ListDepositsByProduct(depositsQueryParams);
			if (response.IsSuccessful)
				return new TatumOkResponse<VirtualAccountDepositsList>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		public async Task<TatumBaseResponse> GetDepositsCountForProduct(DepositsQueryParams depositsQueryParams)
		{
			var response = await LedgerEndpoint.GetDepositsCountByProduct(depositsQueryParams);
			if (response.IsSuccessful)
				return new TatumOkResponse<VirtualAccountDepositsCount>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new TatumErrorResponse(response.ErrorMessage ?? "Error");
		}

		#endregion
	}
}
