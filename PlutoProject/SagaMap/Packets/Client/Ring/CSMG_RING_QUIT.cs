using SagaLib;
using SagaMap.Network.Client;

namespace SagaMap.Packets.Client
{
    public class CSMG_RING_QUIT : Packet
    {
        public CSMG_RING_QUIT()
        {
            this.offset = 2;
        }

        public uint CharID
        {
            get { return this.GetUInt(2); }
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_RING_QUIT();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((MapClient)(client)).OnRingQuit(this);
        }
    }
}
