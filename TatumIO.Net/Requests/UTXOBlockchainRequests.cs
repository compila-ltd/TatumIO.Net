using RestSharp;

using TatumIO.Net.Objects.UTXOs;

namespace TatumIO.Net.Requests
{
    internal class UTXOBlockchainRequests
    {
        public static TatumRequest SendUTXOTransactionAddressKMS(UTXOTransactionAddressKMSPayload payload, string blockchainCode)
        {
            var blockchain = blockchainCode switch
            {
                "BTC" => "bitcoin",
                "LTC" => "litecoin",
                "BCH" => "bitcoin-cash",
                "DOGE" => "dogecoin",
                _ => "bitcoin"
            };

            return new TatumRequest(new RestRequest($"/{blockchain}/transaction", Method.Post).AddJsonBody(payload)).WithApiKey();
        }
    }
}
