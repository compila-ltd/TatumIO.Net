using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.GasPump;
using TatumIO.Net.Objects.GasPump.Payload;

namespace TatumIO.Net.Operations
{
    public interface IBlockchainOperations
    {
        Task<TatumBaseResponse> TransferCustodialWalletTronKMS(TransferCustodialWalletTronKMSPayload payload);
    }

    internal class BlockchainOperations : IBlockchainOperations
    {
        private readonly BlockchainHttpApiClient _blockchainHttpApiClient;

        public BlockchainOperations(string apiKey)
        {
            _blockchainHttpApiClient = new BlockchainHttpApiClient(TatumIOV3Endpoints.BlockchainUrl, apiKey);
        }

        public async Task<TatumBaseResponse> TransferCustodialWalletTronKMS(TransferCustodialWalletTronKMSPayload payload)
        {
            var response = await _blockchainHttpApiClient.TransferCustodialWalletTronKMS(payload);

            if (response.IsSuccessful)
                return new TatumOkResponse<SignatureTransactionId>(response.Data ?? throw new Exception(response.ErrorMessage));

            return new TatumErrorResponse(response.ErrorMessage ?? "Error");
        }
    }
}
