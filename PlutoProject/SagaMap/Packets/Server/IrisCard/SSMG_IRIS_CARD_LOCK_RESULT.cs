using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_IRIS_CARD_LOCK_RESULT : Packet
    {
        public SSMG_IRIS_CARD_LOCK_RESULT()
        {
            this.data = new byte[6];
            this.offset = 2;
            this.ID = 0x1DCA;
        }
    }
}
