using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AudioSender_Receiver1
{
    public abstract class NetworkReceiver
    {
        public string IPToSend { get; protected set; }
        public int PortToSend { get; protected set; }
        public int PortToListen { get; protected set; }
        public Socket SocketToListen { get; protected set; }
        public Socket SocketToSend { get; protected set; }

        protected bool connected;

        abstract public void Free();
    }
}
