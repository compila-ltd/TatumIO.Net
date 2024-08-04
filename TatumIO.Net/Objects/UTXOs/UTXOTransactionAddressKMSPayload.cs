using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.UTXOs
{
    public class UTXOTransactionAddressKMSPayload
    {
        [JsonPropertyName("fromAddress")]
        public List<UTXOTransactionAddressKMSFromAddress>? FromAddresses { get; set; }
        [JsonPropertyName("to")]
        public List<UTXOTransactionAddressKMSToAddress>? ToAddresses { get; set; }
        [JsonPropertyName("fee")]
        public string? Fee { get; set; }
        [JsonPropertyName("changeAddress")]
        public string? ChangeAddress { get; set; }
    }

    public class UTXOTransactionAddressKMSFromAddress
    {
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("signatureId")]
        public string? SignatureId { get; set; }
        [JsonPropertyName("index")]
        public long Index { get; set; }
    }

    public class UTXOTransactionAddressKMSToAddress
    {
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
