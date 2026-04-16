using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_RING_INVITE_ANSWER_RESULT : Packet
    {
        public enum RESULTS
        {
            OK = 2,
            CANNOT_FIND_TARGET = -2,
            ALREADY_IN_RING = -11,
            MEMBER_EXCEED = -12,
        }

        public SSMG_RING_INVITE_ANSWER_RESULT()
        {
            this.data = new byte[6];
            this.offset = 2;
            this.ID = 0x1AB3;
        }

        public RESULTS Result
        {
            set { this.PutInt((int)value, 2); }
        }
    }
}
