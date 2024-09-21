using Compila.Net.Utils.Http;

namespace TatumIO.Net.ApiClients.UTXO
{
    internal class DOGEBlockchainHttpApiClient : UTXOGenericBlockchainHttpApiClient
    {
        public DOGEBlockchainHttpApiClient(IEndpointData endpointData, string apiKey) : base(endpointData, apiKey, "dogecoin")
        {
        }
    }
}
