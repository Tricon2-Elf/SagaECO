using SagaLib;
using SagaMap.Network.Client;

namespace SagaMap.Packets.Client
{
    public class CSMG_PARTNER_CUBE_DELETE : Packet
    {
        public CSMG_PARTNER_CUBE_DELETE()
        {
            this.offset = 2;
        }

        public ushort CubeID
        {
            get { return GetUShort(6); }
        }

        public override Packet New()
        {
            return new CSMG_PARTNER_CUBE_DELETE();
        }

        public override void Parse(SagaLib.Client client)
        {
            ((MapClient)(client)).OnPartnerCubeDelete(this);
        }
    }
}
