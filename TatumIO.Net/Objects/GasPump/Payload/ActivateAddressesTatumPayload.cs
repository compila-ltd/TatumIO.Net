using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.GasPump.Payload
{
	/// <summary>
	/// Payload related to Address activation.
	/// </summary>
	public interface IGasPumpActivationPayload
	{
	}

	/// <summary>
	/// Payload related to Address activation by Tatum.
	/// </summary>
	public class ActivateAddressesTatumPayload : IGasPumpActivationPayload
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
		public bool FeesCovered { get; set; } = true;
	}

	/// <summary>
	/// Payload related to Address activation by KMS.
	/// </summary>
	public class ActivateAddressesKMSPayload : IGasPumpActivationPayload
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
		/// KMS identifier of the private key to sign transaction with.
		/// </summary>
		[JsonPropertyName("signatureId")]
		public string? SignatureId { get; set; }
	}
}
