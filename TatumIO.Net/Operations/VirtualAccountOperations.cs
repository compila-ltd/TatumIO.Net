using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.VirtualAccounts;
using TatumIO.Net.QueryParams.VirtualAccounts;

namespace TatumIO.Net.Operations
{
	public interface IVirtualAccountOperations
	{
		Task<TatumBaseResponse> GetAccountInfo(string accountId);
		Task<TatumBaseResponse> CreateDepositAddress(string accountId, long? index);
		Task<TatumBaseResponse> AssignNewAddress(string accountId, string address);
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
