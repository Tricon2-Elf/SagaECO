using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_VSHOP_INFO_FOOTER : Packet
    {
        public SSMG_VSHOP_INFO_FOOTER()
        {
            this.data = new byte[2];
            this.offset = 2;
            this.ID = 0x0651;
        }
    }
}
