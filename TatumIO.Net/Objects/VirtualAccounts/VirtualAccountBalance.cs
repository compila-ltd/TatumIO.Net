using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.VirtualAccounts
{
	public class VirtualAccountBalance
	{
		[JsonPropertyName("accountBalance")]
		public decimal Balance { get; set; }
		[JsonPropertyName("availableBalance")]
		public decimal AvailableBalance { get; set; }

		public override string ToString()
		{
			return $"{Balance}";
		}
	}
}
