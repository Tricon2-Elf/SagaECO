using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_PARTY_INVITE_RESULT : Packet
    {
        public SSMG_PARTY_INVITE_RESULT()
        {
            this.data = new byte[6];
            this.offset = 2;
            this.ID = 0x19CC;
        }

        public int InviteResult
        {
            set { this.PutInt(value, 2); }
        }
    }
}
