using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Item;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_ITEM_WARE_FOOTER : Packet
    {
        public SSMG_ITEM_WARE_FOOTER()
        {
            this.data = new byte[2];
            this.offset = 2;
            this.ID = 0x09F9;
        }
    }
}
