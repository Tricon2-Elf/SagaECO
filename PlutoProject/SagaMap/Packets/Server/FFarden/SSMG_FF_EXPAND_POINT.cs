using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_FF_EXPAND_POINT : Packet
    {
        /// <summary>
        /// 飞空城的扩展点数
        /// </summary>
        public SSMG_FF_EXPAND_POINT()
        {
            this.data = new byte[10];
            this.offset = 2;
            this.ID = 0x201E;
            this.PutUInt(0, 2);
        }

        public uint value
        {
            set { this.PutUInt(value, 6); }
        }
    }
}
