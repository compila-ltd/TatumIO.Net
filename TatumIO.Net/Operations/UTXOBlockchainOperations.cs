using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.UTXOs;

namespace TatumIO.Net.Operations
{
    public interface IUTXOBlockchainOperations
    {
        Task<TatumBaseResponse> SendUTXOTransactionWalletKMS(UTXOTransactionAddressKMSPayload payload, string blockchainCode = "");
    }

    internal class UTXOBlockchainOperations : IUTXOBlockchainOperations
    {
        private readonly UTXOBlockchainHttpApiClient _client;

        public UTXOBlockchainOperations(string apiKey)
        {
            _client = new UTXOBlockchainHttpApiClient(TatumIOV3Endpoints.UTXOBlockchainUrl, apiKey);
        }

        public async Task<TatumBaseResponse> SendUTXOTransactionWalletKMS(UTXOTransactionAddressKMSPayload payload, string blockchainCode = "")
        {
            var response = await _client.SendUTXOTransactionAddressKMS(payload, blockchainCode);

            if (response.IsSuccessful)
                return new TatumOkResponse<UTXOTransactionAddressKMS>(response.Data ?? throw new Exception(response.ErrorMessage));

            return new TatumErrorResponse(response.ErrorMessage ?? "Error");
        }
    }
}
