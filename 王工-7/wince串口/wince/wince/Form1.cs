using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace wince
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sp.PortName = "COM2";
            sp.BaudRate = 2400;
            sp.StopBits = System.IO.Ports.StopBits.One;
            sp.Parity = System.IO.Ports.Parity.None;
            sp.ReadTimeout = 5000;
            sp.WriteBufferSize = 64;
            sp.ReadBufferSize = 64;
            button1.Text = "open";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                button1.Text = "open";
            }
            else
            {
                sp.Open();
                button1.Text = "close";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSend("@35V1:");
            System.Threading.Thread.Sleep(500);
            try
            {
                string str = sp.ReadTo(":");
                textBox1.Text = str;
                str = "";
            }
            catch (TimeoutException)
            {
                MessageBox.Show("chaoshi!!!!");
            }
            sp.DiscardInBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSend("@35I564.000:");
            System.Threading.Thread.Sleep(500);
            try
            {
                string str = sp.ReadTo(":");
                textBox1.Text = str;
                str = "";
            }
            catch (TimeoutException)
            {
                MessageBox.Show("chaoshi!!!!");
            }
            sp.DiscardInBuffer();
        }

        private byte[] bt;
        private int bcc;
        public void txtSend(string str)
        {
            bt = Encoding.ASCII.GetBytes(str);
            bcc = 0;
            byte[] bt2 = new byte[bt.Length + 2];
            for (int i = 0; i < bt.Length; i++)
            {
                bcc = bcc + bt[i];
                bt2[i] = bt[i];
            }
            bcc = bcc % 128;
            bt2[bt2.Length - 1] = (byte)10;
            bt2[bt2.Length - 2] = (byte)bcc;
            sp.Write(bt2, 0, bt2.Length);
            string txt = "";
            for (int i = 0; i < bt2.Length; i++)
            {
                txt = txt + bt2[i].ToString();
            }
            textBox2.Text = txt;
            txt = "";
            for (int i = 0; i < bt2.Length; i++)
            {
                txt = txt + Convert.ToInt32(bt2[i]).ToString();
            }
            textBox3.Text = txt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtSend("@35P564.000:");
            System.Threading.Thread.Sleep(500);
            try
            {
                string str = sp.ReadTo(":");
                textBox1.Text = str;
                str = "";
            }
            catch (TimeoutException)
            {
                MessageBox.Show("chaoshi!!!!");
            }
            sp.DiscardInBuffer();
        }
    }
}