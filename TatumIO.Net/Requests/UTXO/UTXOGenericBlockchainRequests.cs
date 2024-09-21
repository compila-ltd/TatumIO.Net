using RestSharp;

using TatumIO.Net.Objects.UTXOs;

namespace TatumIO.Net.Requests.UTXO
{
    internal class UTXOGenericBlockchainRequests
    {
        public static TatumRequest SendUTXOTransactionAddressKMS(UTXOTransactionAddressKMSPayload payload, string blockchainCode) =>
             new TatumRequest(new RestRequest($"/{blockchainCode}/transaction", Method.Post).AddJsonBody(payload)).WithApiKey();

        public static TatumRequest GetWalletAddressBalance(string address, string blockchainCode) =>
            new TatumRequest(new RestRequest($"/{blockchainCode}/address/balance/{address}", Method.Get)).WithApiKey();
    }
}
