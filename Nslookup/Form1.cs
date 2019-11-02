using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Nslookup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Process proc = new Process();Thread th;
        ProcessStartInfo pinfo = new ProcessStartInfo();
        private void button1_Click(object sender, System.EventArgs e)
        {
            th = new Thread(begin);th.Start();
        }int syc = 1;
        private void begin()
        {
            label5.Text = richTextBox2.Lines.Length.ToString();
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                changeIP(richTextBox2.Lines[i].ToString());
                label6.Text = syc.ToString();
                syc++;
            }
        }
        void changeIP(string hostNameOrAddress)
        {
            try
            {
                richTextBox1.AppendText(Dns.GetHostEntry(hostNameOrAddress).HostName + " \r ");
            }
            catch(Exception ex)
            {
                richTextBox1.AppendText(ex.Message+ " \r ");

            }
          
        }
    }
}
