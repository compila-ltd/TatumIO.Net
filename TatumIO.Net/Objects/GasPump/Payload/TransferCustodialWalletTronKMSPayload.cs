using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump.Payload
{
    public class TransferCustodialWalletTronKMSPayload
    {
        [JsonPropertyName("chain")]
        public string? Chain { get; set; }
        [JsonPropertyName("custodialAddress")]
        public string? CustodialAddress { get; set; }
        [JsonPropertyName("from")]
        public string? From { get; set; }
        [JsonPropertyName("recipient")]
        public string? Recipient { get; set; }
        [JsonPropertyName("contractType")]
        public int ContractType { get; set; }
        [JsonPropertyName("tokenAddress")]
        public string? TokenAddress { get; set; }
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }
        [JsonPropertyName("signatureId")]
        public string? SignatureId { get; set; }
        [JsonPropertyName("feeLimit")]
        public decimal FeeLimit { get; set; }
    }
}
