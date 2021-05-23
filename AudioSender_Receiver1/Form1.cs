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

        string MyIP = "192.168.0.13";
        string IPToSend = "192.168.0.15";
        int PortToSendVoice = 4444;
        int PortToListenVoice = 5656;
        int PortToSendText = 7777;
        int PortToReceiveText = 5556;
        int PortToSendForVoiceConnect = 5566;
        int PortToReceiveForVoiceConnect = 5555;
        bool VoiceConnected;

        VoiceReceiver VoiceProcesser;
        TextReceiver TextProcesser;
        TextReceiver VoiceConnectionSubmiter;

        public delegate void ProcessReceived(string message);

        private void HadlerRequestForVoiceConnect(string mes)
        {
            if (mes == "Take a call?")
            {
                DialogResult result = MessageBox.Show(
                mes,
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    VoiceConnectionSubmiter.Send("Submit");
                    this.BeginInvoke((Action)(() =>
                    {
                        VoiceConnected = true;
                        buttonStartCall.Enabled = false;
                        buttonFinishCall.Enabled = true;
                        VoiceProcesser = new VoiceReceiver(PortToSendVoice, PortToListenVoice, IPToSend);
                    }));
                }
                else
                {
                    VoiceConnectionSubmiter.Send("Reject");
                }
            }
            else if (mes == "Submit")
            {
                MessageBox.Show("Connection established");
                this.BeginInvoke((Action)(() =>
                {
                    VoiceConnected = true;
                    buttonStartCall.Enabled = false;
                    buttonFinishCall.Enabled = true;
                    VoiceProcesser = new VoiceReceiver(PortToSendVoice, PortToListenVoice, IPToSend);
                }));
            }
            else
            {
                MessageBox.Show("Call rejected");
            }

        }

        private void HandlerMessage(string message)
        {
            this.BeginInvoke((Action)(() =>
            {
                TextPanel.Text += message + Environment.NewLine;
            }));

        }

        public Form1()
        {
            InitializeComponent();
            VoiceConnected = false;
            TextProcesser = new TextReceiver(PortToSendText, PortToReceiveText, IPToSend, HandlerMessage);
            VoiceConnectionSubmiter = new TextReceiver(PortToSendForVoiceConnect, PortToReceiveForVoiceConnect, IPToSend, HadlerRequestForVoiceConnect);
        }

        private void buttonRecord_Click_1(object sender, EventArgs e)
        {
            VoiceConnectionSubmiter.Send("Take a call?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TextPanel.Text += "me: " + InputText.Text + Environment.NewLine;
                string user = userName.Text;
                if (userName.Text == "")
                {
                    user = "Anonimus";
                }
                TextProcesser.Send((object)($"{user}: {InputText.Text}"));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (VoiceConnected)
                {
                    if (VoiceConnectionSubmiter != null)
                    {
                        VoiceConnectionSubmiter.Free();
                    }
                    if (VoiceProcesser != null)
                    {
                        VoiceProcesser.Free();
                    }
                    if (TextProcesser != null)
                    {
                        TextProcesser.Free();
                    }
                }
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoiceConnected = false; ;
            VoiceProcesser.Free();
            buttonFinishCall.Enabled = false;
            buttonStartCall.Enabled = true;
        }
    }
}

