using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.GasPump;
using TatumIO.Net.Objects.GasPump.Payload;
using TatumIO.Net.Requests;

namespace TatumIO.Net.ApiClients
{
    internal class BlockchainHttpApiClient : BaseTatumHttpApiClient
    {
        public BlockchainHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey)
        {
        }

        #region Transactions

        public async Task<RestResponse<SignatureTransactionId>> TransferCustodialWalletTronKMS(TransferCustodialWalletTronKMSPayload payload) =>
            await ExecuteAsync<SignatureTransactionId>(BlockchainRequests.TransferCustodialWalletTronKMS(payload));

        #endregion
    }
}
