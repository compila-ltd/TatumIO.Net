using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump
{
    public class ActivateAddresses : SignatureTransactionId
    {
        [JsonPropertyName("txId")]
        public string? TxId { get; set; }
    }

    public class SignatureTransactionId
    {
        [JsonPropertyName("signatureId")]
        public string? SignatureId { get; set; }
    }
}
