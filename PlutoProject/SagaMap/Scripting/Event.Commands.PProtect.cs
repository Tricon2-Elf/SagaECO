using SagaDB.Actor;
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
