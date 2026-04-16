using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.Item;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_GOLEM_SHOP_BUY_SET : Packet
    {
        public SSMG_GOLEM_SHOP_BUY_SET()
        {
            this.data = new byte[3];
            this.offset = 2;
            this.ID = 0x181E;
        }
    }
}
