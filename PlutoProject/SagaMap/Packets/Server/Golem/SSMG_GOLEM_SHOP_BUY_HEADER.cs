using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.Item;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_GOLEM_SHOP_BUY_HEADER : Packet
    {
        public SSMG_GOLEM_SHOP_BUY_HEADER()
        {
            this.data = new byte[6];
            this.offset = 2;
            this.ID = 0x1824;
        }

        public uint ActorID
        {
            set { this.PutUInt(value, 2); }
        }
    }
}
