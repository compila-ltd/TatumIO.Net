using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump.Payload
{
	/// <summary>
	/// Payload for Addresses precalculation.
	/// </summary>
	public class PrecalculateAddressesPayload
	{
		/// <summary>
		/// Chain or network.
		/// </summary>
		[JsonPropertyName("chain")]
		public string? Chain { get; set; }
		/// <summary>
		/// Owner address to precalculate.
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
	}
}
