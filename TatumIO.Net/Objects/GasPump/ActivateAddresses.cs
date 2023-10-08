using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump
{
	public class ActivateAddresses
	{
		[JsonPropertyName("txId")]
		public string? TxId { get; set; }
	}
}
