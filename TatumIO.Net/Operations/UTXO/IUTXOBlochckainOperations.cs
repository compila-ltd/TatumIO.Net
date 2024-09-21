using TatumIO.Net.Objects.UTXOs;

namespace TatumIO.Net.Operations.UTXO
{
    public interface IUTXOBlockchainOperations
    {
        Task<TatumBaseResponse> SendUTXOTransactionWalletKMS(UTXOTransactionAddressKMSPayload payload);
        Task<TatumBaseResponse> GetAddressBalance(string address);
    }
}
