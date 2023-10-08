using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump.Payload
{
    public class ActivateAddressesPayload
    {
        [JsonPropertyName("chain")]
        public string? Chain { get; set; }
        [JsonPropertyName("owner")]
        public string? Owner { get; set; }
        [JsonPropertyName("from")]
        public int From { get; set; }
        [JsonPropertyName("to")]
        public int To { get; set; }
        [JsonPropertyName("feesCovered")]
        public bool FeesCovered { get; set; }
    }
}
