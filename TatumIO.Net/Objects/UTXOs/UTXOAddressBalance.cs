using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.UTXOs
{
    public class UTXOAddressBalance
    {
        [JsonPropertyName("incoming")]
        public string? Incoming { get; set; }
        [JsonPropertyName("outgoing")]
        public string? Outgoing { get; set; }
        [JsonPropertyName("incomingPending")]
        public string? IncomingPending { get; set; }
        [JsonPropertyName("outgoingPending")]
        public string? OutgoingPending { get; set; }
    }
}
