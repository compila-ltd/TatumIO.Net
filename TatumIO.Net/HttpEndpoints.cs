using Compila.Net.Utils.Http;

namespace TatumIO.Net
{
	internal class TatumEndpointService : IEndpointData
	{
		private string _url = "https://api.tatum.io";
		public int _apiVersion = 3;

		public string BaseUrl
		{
			get
			{
				return $"{_url}/v{_apiVersion}";
			}
			set
			{
				_url = value;
			}
		}

		public TatumEndpointService(string? baseUrl, int? version)
		{
			_url = baseUrl ?? _url;
			_apiVersion = version ?? _apiVersion;
		}
	}

	public class TatumIOV3Endpoints
	{
		public static IEndpointData ServiceUrl => new TatumEndpointService(null, null);
		public static IEndpointData VirtualAccountsLedgerUrl => new EndpointSite($"{ServiceUrl.BaseUrl}/ledger/account");
        public static IEndpointData LedgerUrl => new EndpointSite($"{ServiceUrl.BaseUrl}/ledger");
        public static IEndpointData VirtualAccountsOffchainUrl => new EndpointSite($"{ServiceUrl.BaseUrl}/offchain/account");
		public static IEndpointData GasPumpUrl => new EndpointSite($"{ServiceUrl.BaseUrl}/gas-pump");
		public static IEndpointData SubscriptionsUrl => new EndpointSite($"{ServiceUrl.BaseUrl}/subscription");
	}

	public class TatumIOV4Endpoints
	{
		public static IEndpointData ServiceUrl => new TatumEndpointService("https://api.tatum.io", 4);
	}
}
