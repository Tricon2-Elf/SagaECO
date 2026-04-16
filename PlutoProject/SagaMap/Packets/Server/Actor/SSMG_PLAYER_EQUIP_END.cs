using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.Item;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_PLAYER_EQUIP_END : Packet
    {
        public SSMG_PLAYER_EQUIP_END()
        {
            this.data = new byte[2];
            this.ID = 0x0267;
        }
    }
}
