using System;
using System.Collections.Generic;
using System.Text;
using SagaDB.ECOShop;
using SagaDB.Tamaire;
using SagaLib;
using SagaMap.Manager;

namespace SagaMap.Packets.Server
{
    public class SSMG_TAMAIRE_RENTAL_TERMINATE : Packet
    {
        public SSMG_TAMAIRE_RENTAL_TERMINATE()
        {
            this.data = new byte[3];
            this.offset = 2;
            this.ID = 0x22B5;
        }

        public byte Reason
        {
            set
            {
                this.PutByte(value, 2); //00 = expired, 01 = terminated
            }
        }
    }
}
