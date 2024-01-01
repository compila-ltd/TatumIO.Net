using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.VirtualAccounts
{
	public class VirtualAccountAddress
	{
		[JsonPropertyName("address")]
		public string? Address { get; set; }
		[JsonPropertyName("currency")]
		public string? Currency { get; set; }
		[JsonPropertyName("destinationTag")]
		public long DestinationTag { get; set; }
		[JsonPropertyName("xpub")]
		public string? Xpub { get; set; }
		[JsonPropertyName("memo")]
		public string? Memo { get; set; }
		[JsonPropertyName("derivationKey")]
		public long? DerivationKey { get; set; }
		[JsonPropertyName("message")]
		public string? Message { get; set; }
	}
}
