using System;
using System.Threading.Tasks;

using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.VirtualAccounts;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{
	internal class VirtualAccountHttpApiClient : BaseTatumHttpApiClient
	{
		public VirtualAccountHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey) { }

		public async Task<RestResponse<VirtualAccountInfo>> GetAccountInfo(string accountId) =>
			await ExecuteAsync<VirtualAccountInfo>(VirtualAccountRequests.GetAccountInfoRequest(accountId));

		public async Task<RestResponse<VirtualAccountAddress>> CreateDepositAddress(string accountId, long? index) =>
			await ExecuteAsync<VirtualAccountAddress>(VirtualAccountRequests.CreateDepositAddress(accountId, index));

		public async Task<RestResponse<VirtualAccountAddress>> AssignNewAddress(string accountId, string address) =>
			await ExecuteAsync<VirtualAccountAddress>(VirtualAccountRequests.AssignNewAddress(accountId, address));

		public async Task<RestResponse<VirtualAccountInfo>> AddressIsAssigned(string address, string currency) =>
			await ExecuteAsync<VirtualAccountInfo>(VirtualAccountRequests.AddressIsAssigned(address, currency));
	}
}
