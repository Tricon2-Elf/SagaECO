using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_DEM_PARTS : Packet
    {
        public SSMG_DEM_PARTS()
        {
            this.data = new byte[2];
            this.offset = 2;
            this.ID = 0x1E82;
        }
    }
}
