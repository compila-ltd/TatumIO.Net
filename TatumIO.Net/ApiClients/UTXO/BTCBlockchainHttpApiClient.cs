using Compila.Net.Utils.Http;

namespace TatumIO.Net.ApiClients.UTXO
{
    internal class BTCBlockchainHttpApiClient : UTXOGenericBlockchainHttpApiClient
    {
        public BTCBlockchainHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey, "bitcoin") { }
    }
}
