using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioSender_Receiver1
{
    class FileReceiver : NetworkReceiver
    {
        public delegate void ProcessReceived(string message);
        public ProcessReceived SendedMessageHandler { get; set; }

        public FileReceiver(int portToSend, int portToListen, string ipToSend, ProcessReceived sendDelegate)
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

        public void SendFileName(string fileName)
        {
            try
            {
                SocketToSend.Connect(new IPEndPoint(IPAddress.Any, PortToSend));
                SocketToSend.SendFile(fileName);
                SocketToSend.Shutdown(SocketShutdown.Send);
            }
            catch (Exception ex) { }
        }

        public void SendFile(string path)
        {
            try
            {
                SocketToSend.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), PortToSend));
                SocketToSend.SendFile(path);
                SocketToSend.Shutdown(SocketShutdown.Send);
            }
            catch (Exception ex) { }
        }

        public void StartListening()
        {
            try
            {
                SocketToListen.Bind(new IPEndPoint(IPAddress.Parse(IPToSend), PortToSend));
                SocketToListen.Listen(2);
                while (connected)
                {
                    Socket handler = SocketToListen.Accept();

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (bytes > 0);

                    string fileName = builder.ToString();
                    handler.Shutdown(SocketShutdown.Receive);
                    StartListeningForFile(fileName);

                }
            }
            catch (Exception ex) { }
        }

        public void StartListeningForFile(string fileName)
        {
            /*SocketToListen.Connect(new IPEndPoint(IPAddress.Any, PortToListen));*/
            Socket handler = SocketToListen.Accept();
            using (var stream = File.OpenWrite(@"ex.mp3"))
            {
                byte[] buff = new byte[2048];
                int read;
                do
                {
                    read = handler.Receive(buff);
                    stream.Write(buff, 0, read);
                } while (read > 0);

                handler.Shutdown(SocketShutdown.Receive);
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
