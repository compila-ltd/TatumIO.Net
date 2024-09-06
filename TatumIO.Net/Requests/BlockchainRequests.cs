
using Compila.Net.Utils.Http;

using RestSharp;

using TatumIO.Net.Objects.GasPump.Payload;

namespace TatumIO.Net.Requests
{
    internal class BlockchainRequests
    {
        internal static TatumRequest TransferCustodialWalletTronKMS(TransferCustodialWalletTronKMSPayload payload)
        {
            var path = $"sc/custodial/transfer";

            return new TatumRequest(new RestRequest(path, Method.Post).AddJsonBody(payload)).WithApiKey();
        }
    }
}
