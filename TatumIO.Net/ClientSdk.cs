using TatumIO.Net.Operations;

namespace TatumIO.Net
{
	public class ClientSdk
	{
		public IVirtualAccountOperations VirtualAccount { get; }
		public IGasPumpOperations GasPump { get; }

		public ClientSdk(string apiKey)
		{
			VirtualAccount = new VirtualAccountOperations(apiKey);
			GasPump = new GasPumpOperations(apiKey);
		}
	}
}
