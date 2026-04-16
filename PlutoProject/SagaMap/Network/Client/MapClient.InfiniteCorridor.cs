using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SagaDB;
using SagaDB.Actor;
using SagaDB.FGarden;
using SagaDB.Item;
using SagaLib;
using SagaMap;
using SagaMap.Manager;

namespace SagaMap.Network.Client
{
    public partial class MapClient
    {
        public void SendWarpPoints() { }

        public void ProcessWarp(Packets.Client.CSMG_INFINITECORRIDOR_WARP p) { }

        public void ProcessTrap(Packets.Client.CSMG_INFINITECORRIDOR_TRAP p) { }
    }
}
