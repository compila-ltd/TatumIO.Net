using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.TRON;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{
    internal class TRONBlockchainHttpClient : BaseTatumHttpApiClient
    {
        public TRONBlockchainHttpClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey) { }

        #region Balances

        public async Task<RestResponse<TronAccount>> GetAccountByAddress(string walletAddress)
        {
            var request = TRONBlockchainRequests.GetAccountByAddress(walletAddress);
            return await ExecuteAsync<TronAccount>(request);
        }

        #endregion
    }
}
