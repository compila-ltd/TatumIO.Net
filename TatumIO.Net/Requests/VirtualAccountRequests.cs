using RestSharp;

using TatumIO.Net.QueryParams.VirtualAccounts;

namespace TatumIO.Net.Requests
{
    internal static class VirtualAccountRequests
    {
        public static TatumRequest GetAccountInfo(string accountId) => new TatumRequest(new RestRequest($"/{accountId}", Method.Get)).WithApiKey();

        public static TatumRequest CreateDepositAddress(string accountId, long? index)
        {
            var requestPath = $"/{accountId}/address";
            if (index.HasValue)
                requestPath += $"?index={index.Value}";
            return new TatumRequest(new RestRequest(requestPath, Method.Post)).WithApiKey();
        }

        public static TatumRequest AssignNewAddress(string accountId, string address) => new TatumRequest(new RestRequest($"/{accountId}/address/{address}", Method.Post)).WithApiKey();

        public static TatumRequest AddressIsAssigned(string address, string currency) => new TatumRequest(new RestRequest($"/address/{address}/{currency}", Method.Get)).WithApiKey();

        public static TatumRequest ListDepositsByProduct(DepositsQueryParams depositsQueryParams)
        {
            var requestPath = $"deposits";
            if (depositsQueryParams != null)
                requestPath += $"{depositsQueryParams}";

            return new TatumRequest(new RestRequest(requestPath, Method.Get)).WithApiKey();
        }

        public static TatumRequest GetDepositsCountByProduct(DepositsQueryParams depositsQueryParams)
        {
            var requestPath = $"deposits/count";
            if (depositsQueryParams != null)
                requestPath += $"{depositsQueryParams}";

            return new TatumRequest(new RestRequest(requestPath, Method.Get)).WithApiKey();
        }

        internal static TatumRequest GetAccountAddressesList(string accountId)
        {
            var requestPath = $"/{accountId}/address";
            return new TatumRequest(new RestRequest(requestPath, Method.Get)).WithApiKey();
        }

        /*internal static BaseRequest CreateMultipleDepositAddresses(string accountId, long? index, int count)
        {
            var requestPath = $"/address/batch";
        }*/
    }
}
