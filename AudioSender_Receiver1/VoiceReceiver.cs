using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioSender_Receiver1
{
    class VoiceReceiver
    {
        public string IPToSend { get; private set; }
        public int PortToSend { get; private set; }
        public int PortToListen { get; private set; }
        public WaveIn input { get; private set; }
        public WaveOut output { get; private set; }
        public BufferedWaveProvider bufferStream { get; private set; }
        public Socket SocketToListen { get; private set; }
        public Socket SocketToSend { get; private set; }

        private bool connected;
        
        public VoiceReceiver(int portToSend, int portToListen, string ipToSend)
        {
            PortToSend = portToSend;
            PortToListen = portToListen;
            IPToSend = ipToSend;

            input = new WaveIn();
            input.WaveFormat = new WaveFormat(8000, 16, 1);
            input.DataAvailable += Voice_Input;
            output = new WaveOut();
            bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            output.Init(bufferStream);
            SocketToSend = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            SocketToListen = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            new Thread(new ThreadStart(ListeningForVoice)).Start();
            connected = true;
            input.StartRecording();
        }

        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            try
            {
                IPEndPoint remote_point = new IPEndPoint(IPAddress.Parse(IPToSend), PortToSend);
                IPEndPoint remote_poin = new IPEndPoint(324, PortToSend);
                SocketToSend.SendTo(e.Buffer, remote_point);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ListeningForVoice()
        {
            try
            {
                IPEndPoint localIP = new IPEndPoint(IPAddress.Any, PortToListen);
                SocketToListen.Bind(localIP);
                output.Play();
                EndPoint remoteIp = new IPEndPoint(IPAddress.Any, PortToListen);
                while (connected == true)
                {
                    byte[] data = new byte[65535];
                    int received = SocketToListen.ReceiveFrom(data, ref remoteIp);
                    bufferStream.AddSamples(data, 0, received);
                }
            }
            catch (SocketException ex) when (ex.ErrorCode == 10004)
            {
                return;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Free()
        {
            connected = false;
            SocketToListen.Close();
            SocketToListen.Dispose();

            SocketToSend.Close();
            SocketToSend.Dispose();

            if (output != null)
            {
                output.Stop();
                output.Dispose();
                output = null;
            }
            if (input != null)
            {
                input.Dispose();
                input = null;
            }
            bufferStream = null;
        }
    }
}
