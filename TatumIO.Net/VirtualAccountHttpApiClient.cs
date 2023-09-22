using System;
using System.Threading.Tasks;

using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.VirtualAccounts;
using TatumIO.Net.Requests;

namespace TatumIO.Net
{
	internal interface IVirtualAccountHttpApiClient
	{
		Task<RestResponse<VirtualAccountInfo>> GetAccountInfo(string accountId);
		Task<RestResponse<VirtualAccountAddress>> CreateDepositAddress(string accountId, int? index);
	}
	internal class VirtualAccountHttpApiClient : BaseHttpApiClient, IVirtualAccountHttpApiClient
	{
		private readonly string? _apiKey;

		public VirtualAccountHttpApiClient(IEndpointData endpointData) : base(endpointData)
		{
		}

		public VirtualAccountHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData)
		{
			_apiKey = apiKey ?? throw new ArgumentNullException(apiKey, nameof(apiKey));
		}

		protected override BaseRequest TransformHeaders(BaseRequest request)
		{
			var concreteRequest = (request as TatumRequest) ?? throw new Exception("Improve this");

			if (concreteRequest.RequireApiKey)
				request.RestRequest = request.RestRequest.AddHeader("x-api-key", _apiKey ?? string.Empty);

			return base.TransformHeaders(request);
		}

		public async Task<RestResponse<VirtualAccountInfo>> GetAccountInfo(string accountId)
		{
			return await ExecuteAsync<VirtualAccountInfo>(VirtualAccountRequests.GetAccountInfoRequest(accountId));
		}

		public async Task<RestResponse<VirtualAccountAddress>> CreateDepositAddress(string accountId, int? index)
		{
			return await ExecuteAsync<VirtualAccountAddress>(VirtualAccountRequests.CreateDepositAddress(accountId, index));
		}
	}
}
