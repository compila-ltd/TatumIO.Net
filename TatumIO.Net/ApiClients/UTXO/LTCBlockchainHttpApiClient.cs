using Compila.Net.Utils.Http;

namespace TatumIO.Net.ApiClients.UTXO
{
    internal class LTCBlockchainHttpApiClient : UTXOGenericBlockchainHttpApiClient
    {
        public LTCBlockchainHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey, "litecoin") { }
    }
}
