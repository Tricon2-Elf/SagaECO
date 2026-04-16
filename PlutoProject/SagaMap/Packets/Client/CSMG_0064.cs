using SagaLib;

namespace SagaMap.Packets.Client
{
    public class CSMG_0064 : Packet
    {
        public CSMG_0064()
        {
            this.offset = 2;
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_0064();
        }

        public override void Parse(SagaLib.Client client)
        {
            ;
        }
    }
}
