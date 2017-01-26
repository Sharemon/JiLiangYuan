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
        public int tempNum = 30*22+1;      //�ݴ�����ݳ��ȣ�Ϊ�˻�ͼ
        public int tempNum2 = 30*10;      //�ݴ�����ݳ��ȣ�Ϊ���󲨶���
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
            FlashLight.BackColor = Color.Black;
            /*������ʾ��������Ϣ
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

            //���ڳ�ʼ��
            serialPort1.PortName = "COM" + comPort;
            serialPort1.BaudRate = int.Parse(baudRate);
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.ReadBufferSize = 64;
            serialPort1.WriteBufferSize = 64;
            serialPort1.ReadTimeout = 5000;

            //ʱ�ӳ�ʼ��
            timer1.Interval = int.Parse(interval);  //ÿ2*500ms��һ���¶Ⱥ͹���
            timer1.Enabled = false;
            timer2.Interval = 3000;
            timer2.Enabled = true;

            //��ȡfluc
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

            //���Ʊ�ʾϵͳ������
            if (FlashLight.BackColor == Color.Black)
            {
                FlashLight.BackColor = Color.Red;
            }
            else
            {
                FlashLight.BackColor = Color.Black;
            }

            //��ѯ�¶�ֵ
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

                //��ʾ�¶�
                TempShow.Text = float.Parse(strTemp).ToString("0.0000") + "��";
                
                //ÿ�����¼һ���¶ȣ�����ֻ�е�flag=true��ʱ��ż�¼
                if (saveTempFlag)
                {
                    temperature.Add(float.Parse(strTemp));
                    //������׼��
                    temperature2.Add(float.Parse(strTemp));
                }
                //��תflag
                saveTempFlag = !saveTempFlag;

                // ��������Ϊ��ͼ��׼��
                if (temperature.Count > tempNum)         //�������ݸ���
                {
                    temperature.RemoveAt(0);
                }
                
                //������׼��
                if (temperature2.Count > tempNum2)         //�������ݸ���
                {
                    temperature2.RemoveAt(0);
                }

                //�󲨶���
                string stringFluc;
                if (temperature2.Count > tempNum2-2) //60~1min
                {
                    Max = temperature2[0];
                    Min = temperature2[0];
                    for (int i = 0; i < temperature2.Count; i++)
                    {
                        if (temperature2[i] < Min)          //��15min����Сֵ
                        {
                            Min = temperature2[i];
                        }
                        if (temperature2[i] > Max)          //��15min�����ֵ
                        {
                            Max = temperature2[i];
                        }
                    }
                    fluctuation = Max - Min;
                    if (fluctuation < flucCrite)
                    {
                        /*������ʾ��������Ϣ
                        pictureBox2.BackColor = Color.Green;
                        pictureBox3.BackColor = Color.Green;
                        pictureBox4.BackColor = Color.Green;
                        pictureBox5.BackColor = Color.Green;
                         */
                    }
                    else
                    {
                        /*������ʾ��������Ϣ
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
                    stringFluc = "N/A";
                    /*������ʾ��������Ϣ
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

                //��һ�±���
                strTemp = "";
            }
            else
            {
                //�����趨ֵ
                TempSet2.Text = TempSet.ToString("0.0000") + "��";
                //��ѯ���ȹ���
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
         * ������saveTxt
         * ���ܣ��洢
         * ���룺�¶�����
         * �����
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
            //��ΪɶҪ����ô��f2,f3,f4....
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
                f4 = new Form4("������������");
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
                catch (Exception err)
                {
                    //f4 = new Form4("ͨѶ�쳣�������豸��");
                    connectFlag = false;
                    //f4.Show();
                    MessageBox.Show("ͨѶ����");
                    //throw err;
                }
            }while(!connectFlag);

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
                TempSet2.Text = TempSet.ToString("0.0000") + "��";
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
    }
}