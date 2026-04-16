using SagaLib;
using SagaMap.Network.Client;

namespace SagaMap.Packets.Client
{
    public class CSMG_DAILYDUNGEON_OPEN : Packet
    {
        public CSMG_DAILYDUNGEON_OPEN()
        {
            this.offset = 2;
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_DAILYDUNGEON_OPEN();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((MapClient)(client)).OnDailyDungeonOpen();
        }
    }
}
