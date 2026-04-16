using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;
using SagaLib;

namespace SagaValidation.Packets.Server
{
    public class SSMG_SERVER_LST_END : Packet
    {
        public SSMG_SERVER_LST_END()
        {
            this.data = new byte[2];
            this.offset = 2;
            this.ID = 0x34;
        }
    }
}
