using TatumIO.Net.ApiClients.UTXO;
using TatumIO.Net.Objects.UTXOs;

namespace TatumIO.Net.Operations.UTXO
{
    internal class BTCBlockchainOperations : IUTXOBlockchainOperations
    {
        private readonly UTXOGenericBlockchainHttpApiClient _client;

        public BTCBlockchainOperations(string apiKey)
        {
            _client = new BTCBlockchainHttpApiClient(TatumIOV3Endpoints.UTXOBlockchainUrl, apiKey);
        }

        public async Task<TatumBaseResponse> GetAddressBalance(string address)
        {
            var response = await _client.GetAddressBalance(address);

            if (response.IsSuccessful)
                return new TatumOkResponse<UTXOAddressBalance>(response.Data ?? throw new Exception(response.ErrorMessage));

            return new TatumErrorResponse(response.ErrorMessage ?? "Error");
        }

        public async Task<TatumBaseResponse> SendUTXOTransactionWalletKMS(UTXOTransactionAddressKMSPayload payload)
        {
            var response = await _client.SendUTXOTransactionAddressKMS(payload);

            if (response.IsSuccessful)
                return new TatumOkResponse<UTXOTransactionAddressKMS>(response.Data ?? throw new Exception(response.ErrorMessage));

            return new TatumErrorResponse(response.ErrorMessage ?? "Error");
        }
    }
}
