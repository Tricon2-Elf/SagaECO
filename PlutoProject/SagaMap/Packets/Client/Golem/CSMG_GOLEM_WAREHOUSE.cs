using SagaLib;
using SagaMap.Network.Client;

namespace SagaMap.Packets.Client
{
    public class CSMG_GOLEM_WAREHOUSE : Packet
    {
        public CSMG_GOLEM_WAREHOUSE()
        {
            this.offset = 2;
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_GOLEM_WAREHOUSE();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((MapClient)(client)).OnGolemWarehouse(this);
        }
    }
}
