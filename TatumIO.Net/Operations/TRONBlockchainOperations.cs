using TatumIO.Net.ApiClients;
using TatumIO.Net.Objects.TRON;

namespace TatumIO.Net.Operations
{
    public interface ITRONBlockchainOperations
    {
        Task<TatumBaseResponse> GetAccountByAddress(string walletAddress);
    }

    internal class TRONBlockchainOperations : ITRONBlockchainOperations
    {
        private readonly TRONBlockchainHttpClient TRONBlockchainEnpoint;

        public TRONBlockchainOperations(string apiKey)
        {
            TRONBlockchainEnpoint = new TRONBlockchainHttpClient(TatumIOV3Endpoints.TRONBlockchainUrl, apiKey);
        }

        public async Task<TatumBaseResponse> GetAccountByAddress(string walletAddress)
        {
            var response = await TRONBlockchainEnpoint.GetAccountByAddress(walletAddress);

            if (response.IsSuccessful)
                return new TatumOkResponse<TronAccount>(response.Data ?? throw new Exception(response.ErrorMessage));

            return new TatumErrorResponse(response.ErrorMessage ?? "Error");
        }
    }
}
