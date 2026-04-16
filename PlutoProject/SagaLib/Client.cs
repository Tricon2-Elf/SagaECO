using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SagaLib
{
    public class Client
    {
        public NetIO netIO;
        public uint SessionID;

        public Client() { }

        public Client(Socket mSock, Dictionary<ushort, Packet> mCommandTable)
        {
            this.netIO = new NetIO(mSock, mCommandTable, this);
        }

        public virtual void OnConnect() { }

        public virtual void OnDisconnect() { }
    }
}
