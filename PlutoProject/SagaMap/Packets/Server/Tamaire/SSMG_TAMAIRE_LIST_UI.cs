using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.ECOShop;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_TAMAIRE_LIST_UI : Packet
    {
        public SSMG_TAMAIRE_LIST_UI()
        {
            this.data = new byte[2];
            this.offset = 2;
            this.ID = 0x22B0;
        }
    }
}
