using SagaLib;
using SagaMap.Network.Client;

namespace SagaMap.Packets.Client
{
    public class CSMG_PING : Packet
    {
        public CSMG_PING()
        {
            this.size = 2;
            this.offset = 2;
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_PING();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((MapClient)(client)).OnPing(this);
        }
    }
}
