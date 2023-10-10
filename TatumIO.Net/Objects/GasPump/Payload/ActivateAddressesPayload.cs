using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump.Payload
{
    /// <summary>
    /// Payload for aAddresses activation.
    /// </summary>
    public class ActivateAddressesPayload
    {
        /// <summary>
        /// Chain or network.
        /// </summary>
        [JsonPropertyName("chain")]
        public string? Chain { get; set; }
        /// <summary>
        /// Owner address to activate from.
        /// </summary>
        [JsonPropertyName("owner")]
        public string? Owner { get; set; }
        /// <summary>
        /// Starting index.
        /// </summary>
        [JsonPropertyName("from")]
        public int From { get; set; }
        /// <summary>
        /// Final index.
        /// </summary>
        [JsonPropertyName("to")]
        public int To { get; set; }
        /// <summary>
        /// Whether fees are covered or not by Tatum.
        /// </summary>
        [JsonPropertyName("feesCovered")]
        public bool FeesCovered { get; set; }
    }
}
