using TatumIO.Net.Operations;
using TatumIO.Net.Operations.UTXO;

namespace TatumIO.Net
{
    public class ClientSdk
    {
        public IVirtualAccountOperations VirtualAccount { get; }
        public IGasPumpOperations GasPump { get; }
        public ISubscriptionOperations Subscription { get; }
        public IUTXOBlockchainOperations LTCUTXO { get; }
        public IUTXOBlockchainOperations BTCUTXO { get; }
        public IUTXOBlockchainOperations DOGEUTXO { get; }
        public ITRONBlockchainOperations TRON { get; }
        public IBlockchainOperations Blockchain { get; }

        public ClientSdk(string apiKey)
        {
            VirtualAccount = new VirtualAccountOperations(apiKey);
            GasPump = new GasPumpOperations(apiKey);
            Subscription = new SubscriptionOperations(apiKey);
            LTCUTXO = new LTCBlockchainOperations(apiKey);
            BTCUTXO = new BTCBlockchainOperations(apiKey);
            DOGEUTXO = new DOGEBlockchainOperations(apiKey);
            TRON = new TRONBlockchainOperations(apiKey);
            Blockchain = new BlockchainOperations(apiKey);
        }
    }
}
