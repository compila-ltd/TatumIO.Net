using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.VirtualAccounts;
using TatumIO.Net.QueryParams.VirtualAccounts;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{
	internal class VirtualAccountHttpApiClient : BaseTatumHttpApiClient
    {
        public VirtualAccountHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey) { }

        #region Virtual Accounts

        public async Task<RestResponse<VirtualAccountInfo>> GetAccountInfo(string accountId) =>
            await ExecuteAsync<VirtualAccountInfo>(VirtualAccountRequests.GetAccountInfo(accountId));

        #endregion
        #region Blockchain Addresses

        public async Task<RestResponse<VirtualAccountAddress>> CreateDepositAddress(string accountId, long? index) =>
            await ExecuteAsync<VirtualAccountAddress>(VirtualAccountRequests.CreateDepositAddress(accountId, index));

        public async Task<RestResponse<VirtualAccountAddress>> AssignNewAddress(string accountId, string address) =>
            await ExecuteAsync<VirtualAccountAddress>(VirtualAccountRequests.AssignNewAddress(accountId, address));

        public async Task<RestResponse<VirtualAccountInfo>> AddressIsAssigned(string address, string currency) =>
            await ExecuteAsync<VirtualAccountInfo>(VirtualAccountRequests.AddressIsAssigned(address, currency));

        #endregion
        #region Deposits

        public async Task<RestResponse<VirtualAccountDepositsList>> ListDepositsByProduct(DepositsQueryParams depositsQueryParams) =>
            await ExecuteAsync<VirtualAccountDepositsList>(VirtualAccountRequests.ListDepositsByProduct(depositsQueryParams));

        public async Task<RestResponse<VirtualAccountDepositsCount>> GetDepositsCountByProduct(DepositsQueryParams depositsQueryParams) =>
            await ExecuteAsync<VirtualAccountDepositsCount>(VirtualAccountRequests.GetDepositsCountByProduct(depositsQueryParams));

        #endregion
    }
}
