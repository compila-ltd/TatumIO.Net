using Compila.Net.Utils.Http;

using RestSharp;

namespace TatumIO.Net.ApiClients
{
	internal abstract class BaseTatumHttpApiClient : BaseHttpApiClient
	{
		private readonly string? _apiKey;

		protected BaseTatumHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData)
		{
			_apiKey = apiKey ?? throw new System.ArgumentNullException(apiKey, nameof(apiKey));
		}

		protected override BaseRequest TransformHeaders(BaseRequest request)
		{
			var concreteRequest = (request as TatumRequest) ?? throw new System.Exception("Improve this");

			if (concreteRequest.RequireApiKey)
				request.RestRequest = request.RestRequest.AddHeader("x-api-key", _apiKey ?? string.Empty);

			return base.TransformHeaders(request);
		}
	}
}
