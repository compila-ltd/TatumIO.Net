using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.TRON
{
    public class TronAccount
    {
        [JsonPropertyName("address")]
        public string? Address { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonPropertyName("trc20")]
        public List<Trc20TokenBalance>? Trc20 { get; set; }
    }

    public class Trc20TokenBalance : Dictionary<string, decimal>
    {

    }
}
