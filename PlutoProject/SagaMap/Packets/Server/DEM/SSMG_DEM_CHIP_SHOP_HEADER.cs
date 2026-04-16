using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.Actor;
using SagaDB.DEMIC;
using SagaDB.FGarden;
using SagaLib;

namespace SagaMap.Packets.Server
{
    public class SSMG_DEM_CHIP_SHOP_HEADER : Packet
    {
        public SSMG_DEM_CHIP_SHOP_HEADER()
        {
            this.data = new byte[6];
            this.offset = 2;
            this.ID = 0x0639;
        }

        public uint CategoryID
        {
            set { this.PutUInt(value, 2); }
        }
    }
}
