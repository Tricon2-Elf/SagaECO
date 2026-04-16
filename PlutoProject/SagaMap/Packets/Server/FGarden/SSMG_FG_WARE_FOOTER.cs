using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.FGarden;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_FG_WARE_FOOTER : Packet
    {
        public SSMG_FG_WARE_FOOTER()
        {
            this.data = new byte[10];
            this.offset = 2;
            this.ID = 0x1c27;
        }
    }
}
