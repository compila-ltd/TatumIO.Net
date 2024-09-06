using TatumIO.Net.Operations;

namespace TatumIO.Net
{
    public class ClientSdk
    {
        public IVirtualAccountOperations VirtualAccount { get; }
        public IGasPumpOperations GasPump { get; }
        public ISubscriptionOperations Subscription { get; }
        public IUTXOBlockchainOperations UTXO { get; }
        public ITRONBlockchainOperations TRON { get; }
        public IBlockchainOperations Blockchain { get; }

        public ClientSdk(string apiKey)
        {
            VirtualAccount = new VirtualAccountOperations(apiKey);
            GasPump = new GasPumpOperations(apiKey);
            Subscription = new SubscriptionOperations(apiKey);
            UTXO = new UTXOBlockchainOperations(apiKey);
            TRON = new TRONBlockchainOperations(apiKey);
            Blockchain = new BlockchainOperations(apiKey);
        }
    }
}
