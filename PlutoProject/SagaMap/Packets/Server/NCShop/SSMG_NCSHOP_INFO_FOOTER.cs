using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.ECOShop;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_NCSHOP_INFO_FOOTER : Packet
    {
        public SSMG_NCSHOP_INFO_FOOTER()
        {
            this.data = new byte[2];
            this.offset = 2;
            this.ID = 0x0631;
        }
    }
}
