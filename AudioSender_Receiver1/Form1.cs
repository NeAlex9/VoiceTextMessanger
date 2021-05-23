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
    public partial class Form1 : Form
    {
        private bool connected;
        Socket client;
        WaveIn input;
        WaveOut output;
        BufferedWaveProvider bufferStream;
        Thread in_thread;
        Socket listeningSocket;
        Socket TextMessageSender;
        Socket TextMessageListener;

        string MyIP = "192.168.100.9";
        string IPToSend = "192.168.0.13";
        int PortToSendVoice = 5656;
        int PortToListenVoice = 4444;
        int PortToSendText = 7777;
        int PortToReceiveText = 6655;

        public Form1()
        {
            InitializeComponent();
            input = new WaveIn();
            input.WaveFormat = new WaveFormat(8000, 16, 1);
            input.DataAvailable += Voice_Input;
            output = new WaveOut();
            bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            output.Init(bufferStream);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            connected = true;
            listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            in_thread = new Thread(new ThreadStart(ListeningForVoice));
            in_thread.Start();

            TextMessageSender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            TextMessageListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            new Thread(ListeningForText).Start();
        }

        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            try
            {
                IPEndPoint remote_point = new IPEndPoint(IPAddress.Parse(IPToSend), PortToSendVoice);
                IPEndPoint remote_poin = new IPEndPoint(324, PortToSendVoice);
                client.SendTo(e.Buffer, remote_point);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     ////

        private void ListeningForVoice()
        {
            try
            {
                IPEndPoint localIP = new IPEndPoint(IPAddress.Any, PortToListenVoice);
                listeningSocket.Bind(localIP);
                output.Play();
                EndPoint remoteIp = new IPEndPoint(IPAddress.Any, PortToListenVoice);
                while (connected == true)
                {
                    byte[] data = new byte[65535];
                    int received = listeningSocket.ReceiveFrom(data, ref remoteIp);
                    bufferStream.AddSamples(data, 0, received);
                }
            }
            catch (SocketException ex) when (ex.ErrorCode == 10004)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }   ///

        private void buttonRecord_Click_1(object sender, EventArgs e) ///////
        {
            input.StartRecording();
        }

        private void SendTextMessage(object message)
        {
            string mess = (string)message;

            Console.WriteLine($"me: {mess}");
            byte[] data = Encoding.Unicode.GetBytes(mess);
            EndPoint remotePoint = new IPEndPoint(IPAddress.Parse(IPToSend), PortToSendText);
            TextMessageSender.SendTo(data, remotePoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SendTextMessage(InputText.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListeningForText()
        {
            try
            {
                IPEndPoint localIP = new IPEndPoint(IPAddress.Any, PortToReceiveText);
                TextMessageListener.Bind(localIP);
                while (connected == true)
                {
                    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, PortToReceiveText);

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = TextMessageListener.ReceiveFrom(data, ref remoteIp);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (TextMessageListener.Available > 0);
                    // получаем данные о подключении
                    IPEndPoint remoteFullIp = remoteIp as IPEndPoint;

                    this.BeginInvoke((Action)(() =>
                    {
                        TextPanel.Text += "me: " + builder.ToString() + "\n";
                    }));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            connected = false;
            listeningSocket.Close();
            listeningSocket.Dispose();

            client.Close();
            client.Dispose();

            TextMessageListener.Close();
            TextMessageListener.Dispose();

            TextMessageSender.Close();
            TextMessageSender.Dispose();
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
        } /////
    }
}

