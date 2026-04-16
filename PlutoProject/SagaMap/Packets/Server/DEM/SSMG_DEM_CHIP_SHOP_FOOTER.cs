using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_DEM_CHIP_SHOP_FOOTER : Packet
    {
        public SSMG_DEM_CHIP_SHOP_FOOTER()
        {
            this.data = new byte[6];
            this.offset = 2;
            this.ID = 0x063B;
        }
    }
}
