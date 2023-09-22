using Compila.Net.Utils.Http;

using RestSharp;

namespace TatumIO.Net
{
	internal class TatumRequest : BaseRequest
	{
		public bool RequireApiKey { get; set; } = false;
		public TatumRequest(RestRequest restRequest) : base(restRequest)
		{
		}

		public TatumRequest WithApiKey()
		{
			RequireApiKey = true;
			return this;
		}
	}
}
