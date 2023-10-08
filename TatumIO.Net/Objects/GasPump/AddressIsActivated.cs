using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump
{
	public class AddressIsActivated
	{
		[JsonPropertyName("activated")]
		public bool Activated { get; set; }
	}
}
