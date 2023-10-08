using System;
using System.Threading.Tasks;

using Compila.Net.Utils.ServiceResponses;

using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.VirtualAccounts;

namespace TatumIO.Net.Operations
{
	public interface IVirtualAccountOperations
	{
		Task<ServiceBaseResponse> GetAccountInfo(string accountId);
		Task<ServiceBaseResponse> CreateDepositAddress(string accountId, long? index);
		Task<ServiceBaseResponse> AssignNewAddress(string accountId, string address);
		Task<ServiceBaseResponse> AddressIsAssigned(string address, string currency);
	}

	internal class VirtualAccountOperations : IVirtualAccountOperations
	{
		private readonly VirtualAccountHttpApiClient LedgerEndpoint;
		private readonly VirtualAccountHttpApiClient OffchainEndpoint;

		public VirtualAccountOperations(string apiKey)
		{
			LedgerEndpoint = new VirtualAccountHttpApiClient(TatumIOV3Endpoints.VirtualAccountsLedgerUrl, apiKey);
			OffchainEndpoint = new VirtualAccountHttpApiClient(TatumIOV3Endpoints.VirtualAccountsOffchainUrl, apiKey);
		}

		#region Account
		public async Task<ServiceBaseResponse> GetAccountInfo(string accountId)
		{
			var response = await LedgerEndpoint.GetAccountInfo(accountId);
			if (response.IsSuccessful)
				return new ServiceOkResponse<VirtualAccountInfo>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}

		#endregion
		#region Blockchain Address

		public async Task<ServiceBaseResponse> CreateDepositAddress(string accountId, long? index)
		{
			var response = await OffchainEndpoint.CreateDepositAddress(accountId, index);
			if (response.IsSuccessful)
				return new ServiceOkResponse<VirtualAccountAddress>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}

		public async Task<ServiceBaseResponse> AssignNewAddress(string accountId, string address)
		{
			var response = await OffchainEndpoint.AssignNewAddress(accountId, address);
			if (response.IsSuccessful)
				return new ServiceOkResponse<VirtualAccountAddress>(response.Data ?? throw new Exception(response.ErrorMessage));
			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}

		public async Task<ServiceBaseResponse> AddressIsAssigned(string address, string currency)
		{
			var response = await OffchainEndpoint.AddressIsAssigned(address, currency);

			if (response.IsSuccessful)
				return new ServiceOkResponse<VirtualAccountInfo>(response.Data ?? throw new Exception(response.ErrorMessage));

			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}

		#endregion
	}
}
