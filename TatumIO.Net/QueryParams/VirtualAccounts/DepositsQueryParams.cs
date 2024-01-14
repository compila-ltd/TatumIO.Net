using Compila.Net.Utils.Http.Requests;

namespace TatumIO.Net.QueryParams.VirtualAccounts
{
    public class DepositsQueryParams : RequestParametersBase
    {
        public DepositsQueryParams()
        {
            PageNumber = 0;
            PageSize = 50;
        }

        public new int PageNumber
        {
            get { return base.PageNumber; }
            set { base.PageNumber = value; }
        }
        public new int PageSize
        {
            get { return base.PageSize; }
            set { base.PageSize = value > 50 || value < 0 ? base.PageSize : value; }
        }

        private string sort = "asc";
        public string Sort
        {
            get { return sort; }
            set { sort = value == "desc" ? value : sort; }
        }

        private string? status = "";
        public string? Status
        {
            get { return status; }
            set { status = value == "InProgress" || value == "Done" ? value : status; }
        }

        private string? currency;
        public string? Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        private string? txID;
        public string? TxID
        {
            get { return txID; }
            set { txID = value; }
        }

        private string? to;
        public string? To
        {
            get { return to; }
            set { to = value; }
        }

        private string? accountId;
        public string? AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public override string ToString()
        {
            var queryInString = $"?page={base.PageNumber}&pageSize={PageSize}&sort={Sort}";

            if (!string.IsNullOrEmpty(Status))
                queryInString += $"&status={Status}";

            if (!string.IsNullOrEmpty(Currency))
                queryInString += $"&currency={Currency}";

            if (!string.IsNullOrEmpty(TxID))
                queryInString += $"&txId={TxID}";

            if (!string.IsNullOrEmpty(To))
                queryInString += $"&to={To}";

            if (!string.IsNullOrEmpty(AccountId))
                queryInString += $"&accountId={AccountId}";

            return queryInString;
        }
    }
}
