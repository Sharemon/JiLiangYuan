using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 串口测试程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sp.BaudRate = 2400;
            sp.StopBits = System.IO.Ports.StopBits.One;
            sp.Parity = System.IO.Ports.Parity.None;
            sp.DataBits = 8;
            sp.ReadBufferSize = 64;
            sp.WriteBufferSize = 64;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            sp.PortName = "COM" + COM.Text;
            sp.Open();
            while (true)
            {
                if (sp.BytesToRead > 5)
                {
                    int count = sp.BytesToRead;
                    TxtCount.Text = count.ToString();
                    string str = sp.ReadTo(":");
                    sp.DiscardInBuffer();       //以防“/r/n”堵在readBuffer里面，有数但是读不到“:”从而死机。
                    TxtReceive.Text = str;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == '@')  //找到@作为标志位
                        {
                                switch (str[i + 3])
                                {
                                    case 'R':
                                        switch(str[i+4])
                                        {
                                            case 'H':
                                                Random rn = new Random();
                                                double tempera = 25+int.Parse(this.textBox1.Text)*rn.NextDouble()/1000;
                                                sp.WriteLine("@35RH"+tempera.ToString("0.0000")+":");
                                                TxtSend.Text = "@35RH" + tempera.ToString("0.0000") + ":";
                                                break;
                                            case 'I':
                                                 sp.WriteLine("@35RI98:");
                                                break;
                                            case 'A':
                                                sp.WriteLine("@35RA9.098:");
                                                break;
                                            case 'B':
                                                sp.WriteLine("@35RB9.098:");
                                                break;
                                            case 'C':
                                                sp.WriteLine("@35RC9.098:");
                                                break;
                                            case 'D':
                                                sp.WriteLine("@35RD9.098:");
                                                break;
                                            case 'E':
                                                sp.WriteLine("@35RE9.098:");
                                                break;
                                            case 'F':
                                                sp.WriteLine("@35RF9.098:");
                                                break;
                                            case 'G':
                                                sp.WriteLine("@35RG9.098:");
                                                break;
                                            default: MessageBox.Show(str); break;
                                        }
                                        break;
                                        case 'W':
                                            //sp.WriteLine(str.Substring(0,5) + ":");
                                            sp.WriteLine("@35WA:");
                                            TxtSend.Text = str.Substring(0, 5) + ":";
                                            this.Text = str;
                                            break;
                                    default: MessageBox.Show(str); break;
                                }
                        }
                    }
                }
                Application.DoEvents();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Close();
        }
    }
}
