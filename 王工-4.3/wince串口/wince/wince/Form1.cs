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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
            else
            {
                sp.Open();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] s = new byte[8] {64,51,53,86,51,58,107,10};
            sp.Write(s,0,8);
            System.Threading.Thread.Sleep(200);
            string str = sp.ReadTo(":");
            textBox1.Text = str;
            str = "";
            sp.DiscardInBuffer();
        }
    }
}