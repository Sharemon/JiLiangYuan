#define WATCH_DOG

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
#if WATCH_DOG
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Enable();
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Disable();
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_SetTimeOut(char Sec);
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Feed();
#endif
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
        private bool saveTempFlag = true;
        public int tempNum = 30 * 22 + 1;      //暂存的数据长度，为了画图
        public int tempNum2 = 30 * 10;      //暂存的数据长度，为了求波动度
        private int dataNum = 0;
        private string fileName;
        private StreamWriter sw;
        private StreamReader sr;
        public DateTime startTime;
        private int timerCount = 1;
        private float Min;
        private float Max;
        private float fluctuation = float.NaN;
        public float TempSet;
        public float flucCrite = 0.5F;
        private Form f2;
        private Form f3;
        private Form f4;
        private bool linkState = false;

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
            FlashLight.BackColor = Color.Black;
            /*不再显示波动度信息
            pictureBox2.BackColor = Color.Red;
            pictureBox3.BackColor = Color.Red;
            pictureBox4.BackColor = Color.Red;
            pictureBox5.BackColor = Color.Red;
             */

            // read initial file
            string comPort = "2";
            string baudRate = "2400";
            string interval = "500";
            if (System.IO.File.Exists("\\SDMEM\\config.ini"))
            {
                sr = new StreamReader("\\SDMEM\\config.ini");
                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line.IndexOf(":") > -1)
                    {
                        string[] values = line.Split(':');
                        {
                            switch (values[0])
                            {
                                case "ComPort":
                                    comPort = values[1];
                                    break;
                                case "BaudRate":
                                    baudRate = values[1];
                                    break;
                                case "Interval":
                                    interval = values[1];
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } while (line != "[END]");
            }

            //串口初始化
            serialPort1.PortName = "COM" + comPort;
            serialPort1.BaudRate = int.Parse(baudRate);
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.ReadBufferSize = 64;
            serialPort1.WriteBufferSize = 64;
            serialPort1.ReadTimeout = 5000;

            //时钟初始化
            timer1.Interval = int.Parse(interval);  //每2*500ms读一次温度和功率
            timer1.Enabled = false;
            timer2.Interval = 3000;
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

#if WATCH_DOG
            API_WDT_SetTimeOut(Convert.ToChar(11));
#endif
            serialPort1.Open();
            //GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
#if WATCH_DOG
            API_WDT_Enable();
#endif
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

            //闪灯表示系统在运行
            if (FlashLight.BackColor == Color.Black)
            {
                FlashLight.BackColor = Color.Red;
            }
            else
            {
                FlashLight.BackColor = Color.Black;
            }

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

                //显示温度
                TempShow.Text = float.Parse(strTemp).ToString("0.000") + " ℃";

                //每两秒记录一次温度，所以只有当flag=true的时候才记录
                if (saveTempFlag)
                {
                    temperature.Add(float.Parse(strTemp));
                    //波动率准备
                    temperature2.Add(float.Parse(strTemp));
                }
                //翻转flag
                saveTempFlag = !saveTempFlag;

                // 处理数组为画图做准备
                if (temperature.Count > tempNum)         //限制数据个数
                {
                    temperature.RemoveAt(0);
                }

                //波动率准备
                if (temperature2.Count > tempNum2)         //限制数据个数
                {
                    temperature2.RemoveAt(0);
                }

                //求波动率
                string stringFluc;
                if (temperature2.Count > tempNum2 - 2) //30~1min
                {
                    Max = temperature2[0];
                    Min = temperature2[0];
                    for (int i = 0; i < temperature2.Count; i++)
                    {
                        if (temperature2[i] < Min)          //求2min的最小值
                        {
                            Min = temperature2[i];
                        }
                        if (temperature2[i] > Max)          //求2min的最大值
                        {
                            Max = temperature2[i];
                        }
                    }

                    fluctuation = Max - Min;
                    if (fluctuation < flucCrite)
                    {
                        /*不再显示波动度信息
                        pictureBox2.BackColor = Color.Green;
                        pictureBox3.BackColor = Color.Green;
                        pictureBox4.BackColor = Color.Green;
                        pictureBox5.BackColor = Color.Green;
                         */
                    }
                    else
                    {
                        /*不再显示波动度信息
                        pictureBox2.BackColor = Color.Red;
                        pictureBox3.BackColor = Color.Red;
                        pictureBox4.BackColor = Color.Red;
                        pictureBox5.BackColor = Color.Red;
                         */

                    }
                    stringFluc = fluctuation.ToString("0.000");

                }
                else
                {
                    fluctuation = float.NaN;
                    stringFluc = "N/A";
                    /*不再显示波动度信息
                    pictureBox2.BackColor = Color.Red;
                    pictureBox3.BackColor = Color.Red;
                    pictureBox4.BackColor = Color.Red;
                    pictureBox5.BackColor = Color.Red;
                     */
                }


                if (checkBox1.Checked)
                {
                    saveTxt(strTemp, stringFluc);
                }

                //清一下变量
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
#if WATCH_DOG
            API_WDT_Feed();
#endif
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
        private void saveTxt(string data, string fluc)
        {
            if (dataNum == 0)
            {
                fileName = DateTime.Now.ToString("yyyyMMddhhmmss");
                if (!Directory.Exists("\\SDMEM\\Tempdata"))
                    Directory.CreateDirectory("\\SDMEM\\Tempdata");
                sw = new StreamWriter("\\SDMEM\\Tempdata\\" + fileName + ".txt");
            }
            else
            {
                sw = File.AppendText("\\SDMEM\\Tempdata\\" + fileName + ".txt");
            }
            sw.Write(data + "    " + fluc + "    " + DateTime.Now.ToLongTimeString().ToString() + "\r\n");
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
            //我为啥要设那么多f2,f3,f4....
            f3 = new SetTempForm(this);
            f3.Show();
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
            do
            {
                //asume connection is OK
                connectFlag = true;
                //serialPort1.WriteLine("0123456789");
                serialPort1.WriteLine("@35RA:\r\n");
                Thread.Sleep(100);
                try
                {
                    str = serialPort1.ReadTo(":");
                }
                catch (Exception)
                {
                    //f4 = new Form4("通讯异常，请检查设备！");
                    connectFlag = false;
                    //f4.Show();
                    MessageBox.Show("通讯错误！");
                    //throw err;
                }
            } while (!connectFlag);

            if (connectFlag)
            {
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
                button1_Click(sender, e);
            }
            else
            {
                button1.Enabled = false;
            }

            //serialPort1.Close();
        }

        private void logbnt_Click(object sender, EventArgs e)
        {
            f3 = new LogForm();
            f3.Show();
        }

        private void bntLink_Click(object sender, EventArgs e)
        {

            if (!linkState)     // in unlink mode
            {
                // disable all other bunttons
                button4.Enabled = false;
                logbnt.Enabled = false;

                // open serial port
                serialPort2.PortName = "COM1";
                serialPort2.ReadTimeout = 2000;
                serialPort2.Open();

                linkState = true;
                bntLink.Text = "脱机模式";
            }
            else  // in link mode
            {
                // re-enable all buttons
                button4.Enabled = true;
                logbnt.Enabled = true;

                // close serial port
                serialPort2.Close();

                linkState = false;
                bntLink.Text = "联机模式";
            }

        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // read all data
            if (serialPort2.BytesToRead < 5)
                return;

            string readData = "";
            try
            { readData = serialPort2.ReadTo("@");}
            catch (Exception)
            { serialPort2.DiscardInBuffer(); return; }
            
            serialPort2.DiscardInBuffer();

            // System cmd
            if (readData == "ECHO!")
                serialPort2.Write("ECHO$@");
            else if (readData == "EXIT!")
            {
                serialPort2.Write("EXIT$@");
                bntLink_Click(sender, e);
            }
            // read / set parameters
            else if (readData[readData.Length - 1] == '?')     // read parameter
            {
                // decode the parameter and return parameter
                string cmd = readData.Substring(0, readData.Length - 1);

                string returnStr = "";
                switch (cmd)
                {
                    case "CTEMP":       // current temperature
                        this.Invoke(new EventHandler(delegate
                        {
                            returnStr = this.TempShow.Text.Substring(0, TempShow.Text.Length - 2);
                        }));
                        break;

                    case "CPOWER":      // current power
                        this.Invoke(new EventHandler(delegate
                        {
                            returnStr = this.PowerShow.Text.Substring(0, PowerShow.Text.Length - 2);
                        }));
                        break;

                    case "FLUCT":       // temperature fluctuation
                        if (float.IsNaN(fluctuation))
                            returnStr = "NAN";
                        else
                            returnStr = fluctuation.ToString("0.000");
                        break;

                    case "TMSET":       // temperature setting
                        returnStr = paraments[0].ToString("0.000");
                        break;

                    case "TMMOD":       // temperature modification
                        returnStr = paraments[1].ToString("0.000");
                        break;

                    case "FORWO":       // feedforword
                        returnStr = paraments[2].ToString("0.000");
                        break;

                    case "FUZZY":       // fuzzy
                        returnStr = paraments[3].ToString("0.000");
                        break;

                    case "PROP":       // proportion
                        returnStr = paraments[4].ToString("0.000");
                        break;

                    case "INTEG":       // integration
                        returnStr = paraments[5].ToString("0.000");
                        break;

                    case "PWRCO":       // power coeficcients
                        returnStr = paraments[6].ToString("0.000");
                        break;

                    default:
                        return;
                }

                serialPort2.Write(cmd + ":" + returnStr + "$@");
            }
            else if (readData[readData.Length - 1] == '!') // set parameters
            {
                // disable read timer to avoid conflict
                this.Invoke(new EventHandler(delegate
                {
                    timer1.Enabled = false;
                }));

                // get the cmd 
                string[] dataArr = readData.Substring(0, readData.Length - 1).Split(new char[] { ':' });
                if (dataArr.Length != 2)
                { this.Invoke(new EventHandler(delegate { timer1.Enabled = true; })); return; }

                string cmd = dataArr[0];
                float value = 0.0f;
                try
                { value = float.Parse(dataArr[1]); }
                catch (Exception)
                { this.Invoke(new EventHandler(delegate { timer1.Enabled = true; }));  return; }

                // decode the parameter and set parameter
                string returnStr = "";
                switch (cmd)
                {
                    case "TMSET":       // temperature setting
                        serialPort1.WriteLine("@35WA" + value.ToString("0.000") + ":\r");

                        // update the UI and variables
                        this.Invoke(new EventHandler(delegate
                        {
                            if (!isError())
                            {
                                paraments[0] = value;
                                TempSet = value;
                                TempSet2.Text = value.ToString("0.000");
                            }
                            else
                            {
                                TempSet2.Text = paraments[0].ToString("0.000");
                            }
                        }));

                        returnStr = paraments[0].ToString("0.000");
                        break;

                    case "TMMOD":       // temperature modification
                        serialPort1.WriteLine("@35WB" + value.ToString("0.000") + ":\r");

                        // update variables
                        if (!isError())
                            paraments[1] = value;

                        returnStr = paraments[1].ToString("0.000");
                        break;

                    case "FORWO":       // temperature modification
                        serialPort1.WriteLine("@35WC" + value.ToString("0.000") + ":\r");

                        // update variables
                        if (!isError())
                            paraments[2] = value;

                        returnStr = paraments[2].ToString("0.000");
                        break;

                    case "FUZZY":       // fuzzy
                        serialPort1.WriteLine("@35WD" + value.ToString("0.000") + ":\r");

                        // update variables
                        if (!isError())
                            paraments[3] = value;

                        returnStr = paraments[3].ToString("0.000");
                        break;

                    case "PROP":       // proportion
                        serialPort1.WriteLine("@35WE" + value.ToString("0.000") + ":\r");

                        // update variables
                        if (!isError())
                            paraments[4] = value;

                        returnStr = paraments[4].ToString("0.000");
                        break;

                    case "INTEG":       // integration
                        serialPort1.WriteLine("@35WF" + value.ToString("0.000") + ":\r");

                        // update variables
                        if (!isError())
                            paraments[5] = value;

                        returnStr = paraments[5].ToString("0.000");
                        break;

                    case "PWRCO":       // power coeffients
                        serialPort1.WriteLine("@35WG" + value.ToString("0.000") + ":\r");

                        // update variables
                        if (!isError())
                            paraments[6] = value;

                        returnStr = paraments[6].ToString("0.000");
                        break;

                    default:
                        this.Invoke(new EventHandler(delegate{ timer1.Enabled = true; }));
                        return;
                }

                // send echo back
                serialPort2.Write(cmd + ":" + returnStr + "$@");

                // re-enable read timer
                this.Invoke(new EventHandler(delegate
                {
                    timer1.Enabled = true;
                }));
            }
        }


        /*
        * 函数：isError
        * 功能：判断是否发送错误
        * 
        * 
        */
        private bool isError()
        {

            try
            {
                str = serialPort1.ReadTo(":");
            }
            catch (TimeoutException)
            {
                f4 = new Form4("通讯异常，请检查设备！");
                f4.Show();
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (Convert.ToInt32(str[i]) == 53)
                {
                    if (Convert.ToInt32(str[i + 1]) == 69)
                    {
                        switch (str[i + 2])
                        {
                            case 'A': f4 = new Form4("数据超出范围！"); f4.Show(); return true;
                            case 'B': f4 = new Form4("不存在的命令！"); f4.Show(); return true;
                            case 'C': f4 = new Form4("命令不完整！"); f4.Show(); return true;
                            case 'D': f4 = new Form4("校验和错误！"); f4.Show(); return true;
                            default: break;
                        }
                    }
                }
            }

            return false;
        }
    }
}