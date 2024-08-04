using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.UTXOs;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{
    internal class UTXOBlockchainHttpApiClient : BaseTatumHttpApiClient
    {
        public UTXOBlockchainHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey) { }

        #region Transfers

        internal async Task<RestResponse<UTXOTransactionAddressKMS>> SendUTXOTransactionAddressKMS(UTXOTransactionAddressKMSPayload payload, string blockchainCode) =>
            await ExecuteAsync<UTXOTransactionAddressKMS>(UTXOBlockchainRequests.SendUTXOTransactionAddressKMS(payload, blockchainCode));

        #endregion
    }
}
