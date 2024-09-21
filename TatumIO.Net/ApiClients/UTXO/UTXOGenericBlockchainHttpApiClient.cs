using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.UTXOs;
using TatumIO.Net.Requests.UTXO;

namespace TatumIO.Net.ApiClients.UTXO
{
    internal abstract class UTXOGenericBlockchainHttpApiClient : BaseTatumHttpApiClient
    {
        protected string BlockchainCode { get; private set; }
        public UTXOGenericBlockchainHttpApiClient(IEndpointData endpointData, string apiKey, string blockchainCode) : base(endpointData, apiKey)
        {
            BlockchainCode = blockchainCode;
        }

        #region Transfers

        internal async Task<RestResponse<UTXOTransactionAddressKMS>> SendUTXOTransactionAddressKMS(UTXOTransactionAddressKMSPayload payload) =>
            await ExecuteAsync<UTXOTransactionAddressKMS>(UTXOGenericBlockchainRequests.SendUTXOTransactionAddressKMS(payload, BlockchainCode));

        #endregion
        #region Addresses

        internal async Task<RestResponse<UTXOAddressBalance>> GetAddressBalance(string address) =>
            await ExecuteAsync<UTXOAddressBalance>(UTXOGenericBlockchainRequests.GetWalletAddressBalance(address, BlockchainCode));

        #endregion
    }
}
