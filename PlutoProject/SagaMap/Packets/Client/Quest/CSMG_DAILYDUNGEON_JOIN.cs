using SagaLib;
using SagaMap.Network.Client;

namespace SagaMap.Packets.Client
{
    public class CSMG_DAILYDUNGEON_JOIN : Packet
    {
        public CSMG_DAILYDUNGEON_JOIN()
        {
            this.offset = 2;
        }

        public byte QID
        {
            get { return GetByte(2); }
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_DAILYDUNGEON_JOIN();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((MapClient)(client)).OnDailyDungeonJoin(this);
        }
    }
}
