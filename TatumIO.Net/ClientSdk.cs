namespace TatumIO.Net
{
	public class ClientSdk
	{
        public IVirtualAccountOperations VirtualAccount { get; }

        public ClientSdk(string apiKey)
		{
			VirtualAccount = new VirtualAccountOperations(apiKey);
		}
	}
}
