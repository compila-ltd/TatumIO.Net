using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.VirtualAccounts
{
	public class VirtualAccountDeposit
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }
        [JsonPropertyName("timestamp")]
        public long? Timestamp { get; set; }
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("xpub")]
        public string? Xpub { get; set; }
        [JsonPropertyName("derivationKey")]
        public long? DerivationKey { get; set; }
        [JsonPropertyName("blockHeight")]
        public long? BlockHeight { get; set; }
        [JsonPropertyName("blockHash")]
        public string? BlockHash { get; set; }
        [JsonPropertyName("from")]
        public string? From { get; set; }
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }
        [JsonPropertyName("txId")]
        public string? TxId { get; set; }
        [JsonPropertyName("spent")]
        public bool Spent { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("reference")]
        public string? Reference { get; set; }
        [JsonPropertyName("accountId")]
        public string? AccountId { get; set; }
    }

    public class VirtualAccountDepositsList : List<VirtualAccountDeposit>
    {

    }

    public class VirtualAccountDepositsCount
    {
        [JsonPropertyName("total")]
        public long Total { get; set; }
    }
}
