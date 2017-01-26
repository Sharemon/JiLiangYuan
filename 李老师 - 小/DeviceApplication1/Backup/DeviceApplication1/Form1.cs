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
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Enable();
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Disable();
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_SetTimeOut(char Sec);
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Feed();
        //[DllImport("coredll.dll")]
        //static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        //const int SW_MINIMIZED = 6;
        //private Bitmap red = new Bitmap("\\SDMEM\\red.bmp");
        //private Bitmap green = new Bitmap("\\SDMEM\\green.bmp");
        public float[] paraments = new float[7];
        public bool firstStart = true;
        public List<float> temperature = new List<float>();
        public List<float> temperature2 = new List<float>();
        private List<float> power = new List<float>();
        private string str;
        private string strTemp;
        public const int tempNum = 661;      //暂存的数据长度
        public const int tempNum2 = 450;      //暂存的数据长度
        private int dataNum = 0;
        private string fileName;
        private StreamWriter sw;
        private StreamReader sr;
        public DateTime startTime;
        private int timerCount = 1;
        private float Min;
        private float Max;
        private float fluctuation;
        public float TempSet;
        public float flucCrite = 0.5F;
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

        public float getFluacCrite()
        {
            return flucCrite;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox1.BringToFront();
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.Red;
            pictureBox4.BackColor = Color.Red;
            pictureBox5.BackColor = Color.Red;
            //串口初始化
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 2400;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.ReadBufferSize = 64;
            serialPort1.WriteBufferSize = 64;
            serialPort1.ReadTimeout = 5000;

            //时钟初始化
            timer1.Interval = 1000;
            timer1.Enabled = false;
            timer2.Interval = 5000;
            timer2.Enabled = true;

            //读取fluc
            if (System.IO.File.Exists("\\SDMEM\\fluc.txt"))
            {
                sr = new StreamReader("\\SDMEM\\fluc.txt");
                string flucread = sr.ReadLine();
                flucCrite = float.Parse(flucread);
                sr.Close();
            }
            else
            {
                flucCrite = 0.5F;
            }
            API_WDT_SetTimeOut(Convert.ToChar(11));
            serialPort1.Open();
            //GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            API_WDT_Enable();
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
            //serialPort1.Open();
            serialPort1.DiscardInBuffer();

            //查询温度值
            if (timerCount == 1)
            {
                serialPort1.WriteLine("@35RH:\r\n");
                Thread.Sleep(500);
                str = serialPort1.ReadTo(":");
                for (int k = 5; k < str.Length; k++)
                {
                    if (Convert.ToInt32(str[k]) < 65)
                    {
                        strTemp = strTemp + str[k];
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
                    if (fluctuation < flucCrite)
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
                      
                    }
                    stringFluc = fluctuation.ToString("0.000");
                }
                else
                {
                    stringFluc = "N/A";
                    pictureBox2.BackColor = Color.Red;
                    pictureBox3.BackColor = Color.Red;
                    pictureBox4.BackColor = Color.Red;
                    pictureBox5.BackColor = Color.Red;
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
            else
            {
                //更新设定值
                TempSet2.Text = TempSet.ToString("0.000") + "℃";
                //查询加热功率
                serialPort1.WriteLine("@35RI:\r\n");
                Thread.Sleep(500);
                str = serialPort1.ReadTo(":");
                for (int k = str.Length - 1; k > 1; k--)
                {
                    if (Convert.ToInt32(str[k]) == 73)
                        break;
                    if (Convert.ToInt32(str[k]) < 65)
                    {
                        strTemp = str[k] + strTemp;
                    }
                }
                int power = int.Parse(strTemp);
                //power = power * 100 / 4095;
                PowerShow.Text = power.ToString("0") + " %";
                strTemp = "";
            }
            
            timerCount++;
            if (timerCount == 3)
            {
                timerCount = 1;
            }
            API_WDT_Feed();
            //serialPort1.Close();
            //serialPort1.Dispose();
            //GC.Collect();
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
            //GC.Collect();
        }

        private void TempShow_GotFocus(object sender, EventArgs e)
        {
            button3.Focus();
        }

        private void PowerShow_GotFocus(object sender, EventArgs e)
        {
            button3.Focus();
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
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bool connectFlag = true;
            pictureBox1.Visible = false;
            pictureBox1.Dispose();
            timer2.Enabled = false;
            //serialPort1.Open();
            serialPort1.WriteLine("@35RA:\r\n");
            Thread.Sleep(10);
            try
            {
                str = serialPort1.ReadTo(":");
            }
            catch(TimeoutException)
            {
                f4 = new Form4("通讯异常，请检查设备！");
                connectFlag = false;
                f4.Show();
            }
            for (int k = 5; k < str.Length; k++)
            {
                if (Convert.ToInt32(str[k]) < 65)
                {
                    strTemp = strTemp + str[k];
                }
            }
            TempSet = float.Parse(strTemp);
            TempSet2.Text = TempSet.ToString("0.000") + "℃";
            strTemp = "";
            serialPort1.ReadTimeout = Timeout.Infinite;
            if (connectFlag)
            {
                button1_Click(sender, e);
            }
            //serialPort1.Close();
        }
    }
}