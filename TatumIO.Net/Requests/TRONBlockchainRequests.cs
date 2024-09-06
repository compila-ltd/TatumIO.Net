using RestSharp;

namespace TatumIO.Net.Requests
{
    internal class TRONBlockchainRequests
    {
        public static TatumRequest GetAccountByAddress(string walletAddress)
        {
            var requestPath = $"account/{walletAddress}";
            return new TatumRequest(new RestRequest(requestPath, Method.Get)).WithApiKey();
        }
    }
}
