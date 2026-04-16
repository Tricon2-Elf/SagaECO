using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.Ring;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_TEST_EVOLVE_OPEN2 : Packet
    {
        public SSMG_TEST_EVOLVE_OPEN2()
        {
            this.data = new byte[3];
            this.offset = 2;
            this.ID = 0x0605;
            this.PutByte(1, 2);
        }
    }
}
