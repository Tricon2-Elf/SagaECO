using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.FGarden;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_FG_EQUIPT : Packet
    {
        public SSMG_FG_EQUIPT()
        {
            this.data = new byte[11];
            this.offset = 2;
            this.ID = 0x1BF9;
        }

        public uint ItemID
        {
            set { this.PutUInt(value, 2); }
        }

        public FGardenSlot Place
        {
            set { this.PutUInt((uint)value, 6); }
        }

        public byte Color
        {
            set { this.PutByte(value, 10); }
        }
    }
}
