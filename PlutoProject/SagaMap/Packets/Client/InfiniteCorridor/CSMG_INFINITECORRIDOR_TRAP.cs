using SagaLib;

namespace SagaMap.Packets.Client
{
    public class CSMG_INFINITECORRIDOR_TRAP : Packet
    {
        public CSMG_INFINITECORRIDOR_TRAP()
        {
            this.offset = 2;
        }

        public override SagaLib.Packet New()
        {
            return (SagaLib.Packet)new SagaMap.Packets.Client.CSMG_INFINITECORRIDOR_TRAP();
        }

        public override void Parse(SagaLib.Client client) { }
    }
}
