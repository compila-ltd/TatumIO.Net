﻿using System.Threading.Tasks;

using Compila.Net.Utils.ServiceResponses;

using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.Subscriptions;

namespace TatumIO.Net.Operations
{
	public interface ISubscriptionOperations
	{
		Task<ServiceBaseResponse> ListSubscriptions(int pageSize = 50, int offset = 0);
	}

	internal class SubscriptionOperations : ISubscriptionOperations
	{
		private readonly SubscriptionHttpApiClient SubscriptionEndpoint;

        public SubscriptionOperations(string apiKey)
        {
			SubscriptionEndpoint = new SubscriptionHttpApiClient(TatumIOV3Endpoints.SubscriptionsUrl, apiKey);
        }

        public async Task<ServiceBaseResponse> ListSubscriptions(int pageSize = 50, int offset = 0)
		{
			var response = await SubscriptionEndpoint.ListSubscriptions(pageSize, offset);

			if (response.IsSuccessful)
				return new ServiceOkResponse<SubscriptionsList>(response.Data ?? throw new System.Exception(response.ErrorMessage));

			return new ServiceErrorResponse(response.ErrorMessage ?? "Error", (int)response.StatusCode);
		}
	}
}
