using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TatumIO.Net.Objects.Subscriptions
{
	public class SubscriptionsList : List<Subscription>
	{

	}

	public class Subscription
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }
		[JsonPropertyName("type")]
		public string? Type { get; set; }
		[JsonPropertyName("attr")]
		public SubscriptionAttr? Attr { get; set; }

		public class SubscriptionAttr
		{
			[JsonPropertyName("id")]
			public string? AccountId { get; set; }
			[JsonPropertyName("url")]
			public string? Url { get; set; }
		}
	}
}
