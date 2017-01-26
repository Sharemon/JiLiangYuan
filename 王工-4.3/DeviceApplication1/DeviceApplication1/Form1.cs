using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DeviceApplication1
{
    public partial class MainForm : Form
    {
        //[DllImport("coredll.dll")]
        //static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        //const int SW_MINIMIZED = 6;
        //private Bitmap red = new Bitmap("\\SDMEM\\red.bmp");
        //private Bitmap green = new Bitmap("\\SDMEM\\green.bmp");
        public float[] paraments = new float[10];
        public float[] AdvancedPara = new float[10];
        public bool firstStart = true;
        public List<float> temperature = new List<float>();
        public List<float> temperature2 = new List<float>();
        private List<float> power = new List<float>();
        private string str;
        private string strTemp;
        public const int tempNum = 400;      //暂存的数据长度
        public const int tempNum2 = 450;      //暂存的数据长度
        private int dataNum = 0;
        private string fileName;
        public bool timer1Flag = false;
        private StreamWriter sw;
        public DateTime startTime;
        private int timerCount = 1;
        private float Min;
        private float Max;
        private float fluctuation;
        //public float flucCrite = 0.5F;
        private Form f2;
        private Form f3;
        private Form f4;

        public MainForm()
        {
            InitializeComponent();
        }

        public float getFluactuation()
        {
            return fluctuation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox1.BringToFront();
            //pictureBox2.BackColor = Color.Red;
            //pictureBox3.BackColor = Color.Red;
            //pictureBox4.BackColor = Color.Red;
            //pictureBox5.BackColor = Color.Red;
            //串口初始化
            sp.PortName = "COM2";
            sp.BaudRate = 2400;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.ReadBufferSize = 64;
            sp.WriteBufferSize = 16;
            sp.ReadTimeout = 2000;

            //时钟初始化
            timer1.Interval = 1000;
            timer1.Enabled = false;
            timer2.Interval = 5000;
            timer2.Enabled = true;
            timer3.Interval = 1000;
            timer3.Enabled = true;

            paraments[9] = 2;

            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            startTime = DateTime.Now;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sp.Open();

            //查询温度值
            if (timerCount == 1)
            {
                txtSend("@35V0:");
                Thread.Sleep(500);
                str = sp.ReadTo(":");
                sp.DiscardInBuffer();
                for (int k = 0; k < str.Length; k++)
                {
                    if (str[k] == '@')
                    {
                        strTemp = str.Substring(k + 4);
                        break;
                    }
                }
                temperature.Add(float.Parse(strTemp));
                temperature2.Add(float.Parse(strTemp));

                if (temperature2.Count > tempNum2)         //限制数据个数
                {
                    temperature2.RemoveAt(0);
                }

                //求波动率
                string stringFluc;
                if (temperature2.Count > 448) //90~3min，450~15min
                {
                    Max = temperature2[0];
                    Min = temperature2[0];
                    for (int i = 0; i < temperature2.Count; i++)
                    {
                        if (temperature2[i] < Min)          //求15min的最小值
                        {
                            Min = temperature2[i];
                        }
                        if (temperature2[i] > Max)          //求15min的最大值
                        {
                            Max = temperature2[i];
                        }
                    }
                    fluctuation = Max - Min;
                    /*if (fluctuation < flucCrite)
                    {
                        pictureBox2.BackColor = Color.Green;
                        pictureBox3.BackColor = Color.Green;
                        pictureBox4.BackColor = Color.Green;
                        pictureBox5.BackColor = Color.Green;
                    }
                    else
                    {
                        pictureBox2.BackColor = Color.Red;
                        pictureBox3.BackColor = Color.Red;
                        pictureBox4.BackColor = Color.Red;
                        pictureBox5.BackColor = Color.Red;
                      
                    }*/
                    stringFluc = fluctuation.ToString("0.000");
                }
                else
                {
                    stringFluc = "N/A";
                    //pictureBox2.BackColor = Color.Red;
                    //pictureBox3.BackColor = Color.Red;
                    //pictureBox4.BackColor = Color.Red;
                    //pictureBox5.BackColor = Color.Red;
                }
                if (checkBox1.Checked)
                {
                    saveTxt(strTemp, stringFluc);
                }
                // 处理数组为画图做准备
                if (temperature.Count > tempNum)         //限制数据个数
                {
                    temperature.RemoveAt(0);
                }

                TempShow.Text = temperature[temperature.Count - 1].ToString("0.000") + " ℃";
                strTemp = "";
            }
            else if(timerCount == 2)
            {
                //更新设定值
                TempSet2.Text =paraments[1].ToString("0.000") + "℃";
                //查询加热功率
                txtSend("@35V3:");
                Thread.Sleep(500);
                str = sp.ReadTo(":");
                for (int k = 0; k < str.Length; k++)
                {
                    if (str[k] == '@')
                    {
                        strTemp = str.Substring(k + 4);
                        break;
                    }
                }
                float power = float.Parse(strTemp);
                //power = power * 100 / 4095;
                PowerShow.Text = power.ToString("0.0") + " %";
                //power.Add(float.Parse(strTemp));
                //PowerShow.Text = power[temperature.Count - 1].ToString("0") + "%";
                strTemp = "";
            }
            else if (timerCount == 3)
            {
                //更新冻制状态
                txtSend("@35V31:");
                Thread.Sleep(500);
                str = sp.ReadTo(":");
                for (int k = 0; k < str.Length; k++)
                {
                    if (str[k] == '@')
                    {
                        strTemp = str.Substring(k + 4);
                        break;
                    }
                }
                AdvancedPara[0] = float.Parse(strTemp);
                if (AdvancedPara[0] == 0)
                {
                    pictureBox2.BackColor = Color.Lime;
                }
                else if (AdvancedPara[0] == 1)
                {
                    pictureBox2.BackColor = Color.DarkSlateBlue;
                }
                else if (AdvancedPara[0] == 2)
                {
                    pictureBox2.BackColor = Color.Magenta;
                }
                strTemp = "";
            }
            
            timerCount++;
            if (timerCount == 4)
            {
                timerCount = 1;
            }
             
            sp.Close();
            //serialPort1.Dispose();
            GC.Collect();
        }
        /*
         * 函数：saveTxt
         * 功能：存储
         * 输入：温度数据
         * 输出：
         * 
         */
        private void saveTxt(string data,string fluc)
        {
            if (dataNum == 0)
            {
                fileName = DateTime.Now.ToString("yyyyMMddhhmmss");
                if(!Directory.Exists("\\SDMEM\\Tempdata"))
                    Directory.CreateDirectory("\\SDMEM\\Tempdata");
                sw = new StreamWriter("\\SDMEM\\Tempdata\\" + fileName + ".txt");
            }
            else
            {
                sw = File.AppendText("\\SDMEM\\Tempdata\\" + fileName + ".txt");
            }
            sw.Write(data + "    " + fluc + "    " +DateTime.Now.ToLongTimeString().ToString() + "\r\n");
            dataNum++;
            if (dataNum == 43200)
            {
                dataNum = 0;
            }
            sw.Close();
            GC.Collect();
        }

        private void TempShow_GotFocus(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void PowerShow_GotFocus(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                f2 = new Form2(this);
                f2.Show();
            }
            else
            {
                f4 = new Form4("请先启动程序！");
                f4.Show();
                timer1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f3 = new Form3(this);
            if (timer1.Enabled)
            {
                timer1Flag = true;
            }
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Dispose();
        }

        byte[] bt;
        int bcc;
        //string strstr;
        
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
            //strstr = str + Encoding.ASCII.GetString(new byte[] { (byte)bcc }, 0, 1);
            //sp.WriteLine(strstr);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            sp.Open();
            for (int i = 0; i < 10; i++)
            {
                if(i != 8)
                {
                    txtSend("@35V" + i.ToString() + ":");
                    Thread.Sleep(1000);
                    try
                    {
                        str = sp.ReadTo(":");
                        sp.DiscardInBuffer();
                        for (int k = 0; k < str.Length; k++)
                        {
                            if (str[k] == '@')
                            {
                                strTemp = str.Substring(k + 4);
                                break;
                            }
                        }
                        paraments[i] = float.Parse(strTemp);
                    }
                    catch (TimeoutException)
                    {
                        MessageBox.Show("通讯中断！");
                        break;
                    }
                    strTemp = "";
                    //Thread.Sleep(1000);
                }
            }
            strTemp = "";
            TempSet2.Text = paraments[1].ToString("0.000") + "℃";
            TempShow.Text = paraments[0].ToString("0.000") + "℃";
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
                txtSend("@35V31:");
                Thread.Sleep(1500);
                try
                {
                    str = sp.ReadTo(":");
                    sp.DiscardInBuffer();
                    for (int k = 0; k < str.Length; k++)
                    {
                        if (str[k] == '@')
                        {
                            strTemp = str.Substring(k + 4);
                        }
                    }
                    AdvancedPara[0] = float.Parse(strTemp);
                    if (AdvancedPara[0] == 0)
                    {
                        pictureBox2.BackColor = Color.Lime;
                    }
                    else if (AdvancedPara[0] == 1)
                    {
                        pictureBox2.BackColor = Color.DarkSlateBlue;
                    }
                    else if (AdvancedPara[0] == 2)
                    {
                        pictureBox2.BackColor = Color.Magenta;
                    }
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("通讯中断！");
                }
                strTemp = "";
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
             
            //txtSend("@35L2:");
            sp.Close();
        }
    }
}