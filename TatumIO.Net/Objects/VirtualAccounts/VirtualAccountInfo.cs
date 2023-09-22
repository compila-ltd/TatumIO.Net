using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.VirtualAccounts
{
	public class VirtualAccountInfo
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }
		[JsonPropertyName("balance")]
		public VirtualAccountBalance? Balance { get; set; }
		[JsonPropertyName("currency")]
		public string? Currency { get; set; }
		[JsonPropertyName("frozen")]
		public bool Frozen { get; set; }
		[JsonPropertyName("active")]
		public bool Active { get; set; }
		[JsonPropertyName("customerId")]
		public string? CustomerId { get; set; }
		[JsonPropertyName("accountNumber")]
		public string? AccountNumber { get; set; }
		[JsonPropertyName("accountCode")]
		public string? AccountCode { get; set; }
		[JsonPropertyName("accountingCurrency")]
		public string? AccountingCurrency { get; set; }
		[JsonPropertyName("xpub")]
		public string? Xpub { get; set; }

	}
}
