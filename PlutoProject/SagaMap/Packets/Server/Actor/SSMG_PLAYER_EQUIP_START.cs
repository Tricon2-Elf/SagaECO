using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_PLAYER_EQUIP_START : Packet
    {
        public SSMG_PLAYER_EQUIP_START()
        {
            this.data = new byte[3];
            this.ID = 0x0263;
        }

        public uint Result
        {
            set { this.PutUInt(value, 2); }
        }
    }
}
