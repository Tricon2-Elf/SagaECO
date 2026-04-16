using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;
using SagaDB.Item;
using SagaDB.Map;
using SagaDB.Quests;
using SagaDB.Skill;
using SagaLib;
using SagaMap;
using SagaMap.Manager;
using SagaMap.Network.Client;
using SagaMap.Packets.Server;

namespace SagaMap.Scripting
{
    public abstract partial class Event
    {
        protected void OpenPprotectListOpen(ActorPC pc)
        {
            MapClient client = GetMapClient(pc);

            SSMG_PPROTECT_INITI p = new SSMG_PPROTECT_INITI();

            client.netIO.SendPacket(p);
        }
    }
}
