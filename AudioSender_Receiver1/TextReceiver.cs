using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioSender_Receiver1
{
    class TextReceiver : NetworkReceiver
    {
        public delegate void ProcessReceived(string message);
        public ProcessReceived SendedMessageHandler { get; set; }

        public TextReceiver(int portToSend, int portToListen, string ipToSend, ProcessReceived sendDelegate)
        {
            PortToSend = portToSend;
            PortToListen = portToListen;
            IPToSend = ipToSend;
            SocketToSend = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            SocketToListen = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            SendedMessageHandler = sendDelegate;
            connected = true;
            new Thread(StartListening).Start();
        }

        public void Send(object message)
        {
            string mess = (string)message;

            Console.WriteLine($"me: {mess}");
            byte[] data = Encoding.Unicode.GetBytes(mess);
            EndPoint remotePoint = new IPEndPoint(IPAddress.Parse(IPToSend), PortToSend);
            SocketToSend.SendTo(data, remotePoint);
        }

        public void StartListening()
        {
            try
            {
                IPEndPoint localIP = new IPEndPoint(IPAddress.Any, PortToListen);
                SocketToListen.Bind(localIP);
                while (connected == true)
                {
                    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, PortToListen);
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; 
                    byte[] data = new byte[256];
                    do
                    {
                        bytes = SocketToListen.ReceiveFrom(data, ref remoteIp);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (SocketToListen.Available > 0);
                    IPEndPoint remoteFullIp = remoteIp as IPEndPoint;
                    SendedMessageHandler.Invoke(builder.ToString());
                }
            }
            catch (Exception ex)
            {
            }
        }

        public override void Free()
        {
            connected = false;
            SocketToListen.Close();
            SocketToListen.Dispose();

            SocketToSend.Close();
            SocketToSend.Dispose();
        }
    }
}
