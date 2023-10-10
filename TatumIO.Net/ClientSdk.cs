using TatumIO.Net.Operations;

namespace TatumIO.Net
{
	public class ClientSdk
	{
		public IVirtualAccountOperations VirtualAccount { get; }
		public IGasPumpOperations GasPump { get; }
		public ISubscriptionOperations Subscription { get; }

		public ClientSdk(string apiKey)
		{
			VirtualAccount = new VirtualAccountOperations(apiKey);
			GasPump = new GasPumpOperations(apiKey);
			Subscription = new SubscriptionOperations(apiKey);
		}
	}
}
