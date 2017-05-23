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
            float[] parameters = new float[7];


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
                    System.Threading.Thread.Sleep(100);
                    sp.DiscardInBuffer();       //以防“/r/n”堵在readBuffer里面，有数但是读不到“:”从而死机。
                    TxtReceive.Text = str;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == '@')  //找到@作为标志位
                        {
                            switch (str[i + 3])
                            {
                                case 'R':
                                    switch (str[i + 4])
                                    {
                                        case 'H':
                                            Random rn = new Random();
                                            double tempera = 25 + int.Parse(this.textBox1.Text) * rn.NextDouble() / 1000;
                                            sp.WriteLine("@35RH" + tempera.ToString("0.0000") + ":");
                                            TxtSend.Text = "@35RH" + tempera.ToString("0.0000") + ":";
                                            break;
                                        case 'I':
                                            Random rn2 = new Random();
                                            double power = 50 + 20 * (rn2.NextDouble() - 0.5);
                                            sp.WriteLine("@35RI" + power.ToString("0") + ":");
                                            break;
                                        case 'A':
                                            sp.WriteLine("@35RA" + parameters[0].ToString("0.000") + ":");
                                            break;
                                        case 'B':
                                            sp.WriteLine("@35RB" + parameters[1].ToString("0.000") + ":");
                                            break;
                                        case 'C':
                                            sp.WriteLine("@35RC" + parameters[2].ToString("0.000") + ":");
                                            break;
                                        case 'D':
                                            sp.WriteLine("@35RD" + parameters[3].ToString("0.000") + ":");
                                            break;
                                        case 'E':
                                            sp.WriteLine("@35RE" + parameters[4].ToString("0.000") + ":");
                                            break;
                                        case 'F':
                                            sp.WriteLine("@35RF" + parameters[5].ToString("0.000") + ":");
                                            break;
                                        case 'G':
                                            sp.WriteLine("@35RG" + parameters[6].ToString("0.000") + ":");
                                            break;
                                        default: MessageBox.Show(str); break;
                                    }
                                    break;
                                case 'W':
                                    float value = float.Parse(str.Remove(0, 5));
                                    parameters[str[i + 4] - 'A'] = value;
                                    sp.WriteLine(str.Substring(0, 5) + ":");
                                    TxtSend.Text = parameters[str[i + 4] - 'A'].ToString("0.000");
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
