using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.UTXOs
{
    public class UTXOTransactionAddressKMS
    {
        [JsonPropertyName("txId")]
        public string? TransactionHash { get; set; }
        [JsonPropertyName("signatureId")]
        public string? SignatureId { get; set; }
    }
}
