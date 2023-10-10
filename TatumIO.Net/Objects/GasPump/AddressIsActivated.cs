using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump
{
	/// <summary>
	/// Information about address activation.
	/// </summary>
	public class AddressIsActivated
	{
		/// <summary>
		/// Whether address is activated or not.
		/// </summary>
		[JsonPropertyName("activated")]
		public bool Activated { get; set; }
	}
}
