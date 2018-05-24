using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace DeviceApplication1
{
    public partial class Form3 : Form
    {
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Enable();
        [DllImport("HDI_API.dll")]
        public static extern void API_WDT_Disable();
        MainForm f1;
        string str, strTemp;
        bool errorFlag;
        bool timerFlag = false;
        //bool readFlag = false;
        private TextBox tx;
        private Form f4;
        private int dataNum2 = 0;
        private string fileName;
        private StreamWriter sw;
        private StreamWriter sw2;

        public Form3(MainForm myf1)
        {
            InitializeComponent();
            this.f1 = myf1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            API_WDT_Disable();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(50, 0);
            if (f1.timer1.Enabled)
            {
                f1.timer1.Enabled = false;
                timerFlag = true;
            }
            else
            {
                timerFlag = false;
            }
            if (f1.firstStart)
            {
                f1.paraments = readPara();
                f1.firstStart = false;
            }
            TempSet.Text = f1.paraments[0].ToString("0.000");
            TempMod.Text = f1.paraments[1].ToString("0.000");
            ForwardMod.Text = f1.paraments[2].ToString("0.000");
            Fuzzy.Text = f1.paraments[3].ToString("0");
            Ratio.Text = f1.paraments[4].ToString("0");
            Integration.Text = f1.paraments[5].ToString("0");
            Power.Text = f1.paraments[6].ToString("0");
            FlucSet.Text = f1.getFluacCrite().ToString("0.000");
        }

        /*
         * 函数：readPara
         * 功能：读取参数
         * 输入：
         * 输出：参数数组
         * 
         */
        private float[] readPara()
        {
            float[] para = new float[7];
            //f1.serialPort1.Open();
            try
            {
                for (int i = 65; i <= 71; i++)
                {
                    f1.serialPort1.WriteLine("@35R" + (char)i + ":\r\n");
                    Thread.Sleep(10);
                    str = f1.serialPort1.ReadTo(":");          //读出来的字符前面有以前返回值剩下的“?\r\n”，想去掉的话可以找到开头的@的位置，然后用substring截断字符串。
                    for (int k = 5; k < str.Length; k++)
                    {
                        if (Convert.ToInt32(str[k]) < 65)
                        {
                            strTemp = strTemp + str[k];
                        }
                    }
                    para[i - 65] = float.Parse(strTemp);
                    strTemp = "";
                }
            }
            catch (TimeoutException)
            {
                f4 = new Form4("通讯异常，请检查设备！");
                f4.Show();
            }
            //f1.serialPort1.Close();
            return para;
        }

        private void button1_click(object sender, EventArgs e)
        {
            //if (readFlag)
            //{
            if (dataNum2 == 0)
            {
                fileName = DateTime.Now.ToString("yyyyMMddhhmmss");
                if (!Directory.Exists("\\SDMEM\\Operating"))
                    Directory.CreateDirectory("\\SDMEM\\Operating");
                sw = new StreamWriter("\\SDMEM\\Operating\\" + fileName + ".txt");
            }
            else
            {
                sw = File.AppendText("\\SDMEM\\Operating\\" + fileName + ".txt");
            }
            sw.Write( "\r\n" + "\r\n");

            sw.Write
                (DateTime.Now.ToString("u")+ "\r\n"
                + "Set:               " + f1.paraments[0].ToString("0.000") + "\r\n"
                + "Modify:       " + f1.paraments[1].ToString("0.000") + "\r\n"
                + "Forward:     " + f1.paraments[2].ToString("0.000") + "\r\n"
                + "Fuzzy:          " + f1.paraments[3].ToString("0") + "\r\n"
                + "Ratio:           " + f1.paraments[4].ToString("0") + "\r\n"
                + "Integration: " + f1.paraments[5].ToString("0") + "\r\n"
                + "Power:         " + f1.paraments[6].ToString("0") + "\r\n"
                + "Fluction:       " + f1.getFluacCrite().ToString("0.000") + "\r\n"
                , Encoding.Default);

            button1.Enabled = false;

            //参数更新
            errorFlag = false;
            //f1.serialPort1.Open();

            if ((TempSet.Text.Trim() != string.Empty) && (float.Parse(TempSet.Text) != f1.paraments[0]))
            {
                f1.serialPort1.WriteLine("@35WA" + float.Parse(TempSet.Text).ToString("0.000") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[0] = float.Parse(TempSet.Text);
                    f1.TempSet = f1.paraments[0];
                }
                else
                {
                    TempSet.Text = f1.paraments[0].ToString("0.000");
                }
                Thread.Sleep(100);
            }

            if (TempMod.Text.Trim() != string.Empty && float.Parse(TempMod.Text) != f1.paraments[1])
            {
                f1.serialPort1.WriteLine("@35WB" + float.Parse(TempMod.Text).ToString("0.000") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[1] = float.Parse(TempMod.Text);
                }
                else
                {
                    TempMod.Text = f1.paraments[1].ToString("0.000");
                }
                Thread.Sleep(100);
            }

            if ((ForwardMod.Text.Trim() != string.Empty) && (float.Parse(ForwardMod.Text) != f1.paraments[2]))
            {
                f1.serialPort1.WriteLine("@35WC" + float.Parse(ForwardMod.Text).ToString("0.000") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[2] = float.Parse(ForwardMod.Text);
                }
                else
                {
                    ForwardMod.Text = f1.paraments[2].ToString("0.000");
                }
                Thread.Sleep(100);
            }

            if ((Fuzzy.Text.Trim() != string.Empty) && (float.Parse(Fuzzy.Text) != f1.paraments[3]) && (Fuzzy.Text.Trim() != string.Empty))
            {
                f1.serialPort1.WriteLine("@35WD" + float.Parse(Fuzzy.Text).ToString("0") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[3] = float.Parse(Fuzzy.Text);
                }
                else
                {
                    Fuzzy.Text = f1.paraments[3].ToString("0");
                }
                Thread.Sleep(100);
            }

            if ((Ratio.Text.Trim() != string.Empty) && (float.Parse(Ratio.Text) != f1.paraments[4]))
            {
                f1.serialPort1.WriteLine("@35WE" + float.Parse(Ratio.Text).ToString("0") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[4] = float.Parse(Ratio.Text);
                }
                else
                {
                    Ratio.Text = f1.paraments[4].ToString("0");
                }
                Thread.Sleep(100);
            }

            if ((Integration.Text.Trim() != string.Empty) && (float.Parse(Integration.Text) != f1.paraments[5]))
            {
                f1.serialPort1.WriteLine("@35WF" + float.Parse(Integration.Text).ToString("0") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[5] = float.Parse(Integration.Text);
                }
                else
                {
                    Integration.Text = f1.paraments[5].ToString("0");
                }
                Thread.Sleep(100);
            }

            if ((Power.Text.Trim() != string.Empty) && (float.Parse(Power.Text) != f1.paraments[6]))
            {
                f1.serialPort1.WriteLine("@35WG" + float.Parse(Power.Text).ToString("0") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[6] = float.Parse(Power.Text);
                }
                else
                {
                    Power.Text = f1.paraments[6].ToString("0");
                }
                Thread.Sleep(100);
            }

            if ((FlucSet.Text.Trim() != string.Empty) && (float.Parse(FlucSet.Text) != f1.getFluacCrite()))
            {
                f1.flucCrite = float.Parse(FlucSet.Text);
                sw2 = new StreamWriter("\\SDMEM\\fluc.txt");
                sw2.Write(f1.getFluacCrite().ToString("0.000"),Encoding.Default);
                sw2.Close();
            }

            //f1.serialPort1.Close();
            //f1.serialPort1.Dispose();
            f4 = new Form4("参数已更新！");
            f4.Show();
            //    readFlag = false;
            //}
            //else
            //{
            //  MessageBox.Show("请先读取参数！");
            //}
            sw.Write
                ("Paraments Changed to:  " + "\r\n"
                + "Set:               " + f1.paraments[0].ToString("0.000") + "\r\n"
                + "Modify:       " + f1.paraments[1].ToString("0.000") + "\r\n"
                + "Forward:     " + f1.paraments[2].ToString("0.000") + "\r\n"
                + "Fuzzy:          " + f1.paraments[3].ToString("0") + "\r\n"
                + "Ratio:           " + f1.paraments[4].ToString("0") + "\r\n"
                + "Integration: " + f1.paraments[5].ToString("0") + "\r\n"
                + "Power:         " + f1.paraments[6].ToString("0") + "\r\n"
                + "Fluction:       " + f1.getFluacCrite().ToString("0.000") + "\r\n"
                , Encoding.Default);
            dataNum2++;
            if (dataNum2 == 201)
            {
                dataNum2 = 0;
            }
            sw.Close();
            button1.Enabled = true;
            //GC.Collect();
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
                str = f1.serialPort1.ReadTo(":");
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

        private void one_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "1";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "2";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "3";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "4";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "5";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "6";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void seven_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "7";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void eight_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "8";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = tx.Text + "9";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void zero_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                if (tx.Text.Length != 1 || int.Parse(tx.Text) != 0)
                {
                    tx.Text = tx.Text + "0";
                }
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                bool dotFlag = true;
                for (int i = 0; i < tx.Text.Length; i++)
                {
                    if (Convert.ToInt32(tx.Text[i]) == 46)
                    {
                        dotFlag = false;
                        break;
                    }
                }
                if (dotFlag)
                {
                    tx.Text = tx.Text + ".";
                }
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                if (tx.Text.Length > 0)
                {
                    tx.Text = tx.Text.Substring(0, tx.Text.Length - 1);
                }
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void TempSet_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = TempSet;
            tx.BackColor = Color.White;
        }

        private void TempMod_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = TempMod;
            tx.BackColor = Color.White;
        }

        private void ForwardMod_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = ForwardMod;
            tx.BackColor = Color.White;
        }

        private void Fuzzy_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = Fuzzy;
            tx.BackColor = Color.White;
        }

        private void Ratio_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = Ratio;
            tx.BackColor = Color.White;
        }

        private void Integration_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = Integration;
            tx.BackColor = Color.White;
        }

        private void Power_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = Power;
            tx.BackColor = Color.White;
        }

        private void Form3_Closing(object sender, CancelEventArgs e)
        {
            API_WDT_Enable();
        }

        private void TempSet_LostFocus(object sender, EventArgs e)
        {
            TempSet.BackColor = Color.Gainsboro;
        }

        private void TempMod_LostFocus(object sender, EventArgs e)
        {
            TempMod.BackColor = Color.Gainsboro;
        }

        private void ForwardMod_LostFocus(object sender, EventArgs e)
        {
            ForwardMod.BackColor = Color.Gainsboro;
        }

        private void Fuzzy_LostFocus(object sender, EventArgs e)
        {
            Fuzzy.BackColor = Color.Gainsboro;
        }

        private void Ratio_LostFocus(object sender, EventArgs e)
        {
            Ratio.BackColor = Color.Gainsboro;
        }

        private void Integration_LostFocus(object sender, EventArgs e)
        {
            Integration.BackColor = Color.Gainsboro;
        }

        private void Power_LostFocus(object sender, EventArgs e)
        {
            Power.BackColor = Color.Gainsboro;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = "";
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (timerFlag)
            {
                f1.timer1.Enabled = true;
                timerFlag = false;
            }
            f1.button4.Enabled = true;
            this.Close();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                if (tx.Text == "")
                {
                    tx.Text = "-";
                }
                else if (tx.Text.Length == 1 && Convert.ToInt32(tx.Text[0]) == 45)
                {
                    tx.Text = "";
                }
                else
                {
                    float temp = 0.0F - float.Parse(tx.Text);
                    tx.Text = temp.ToString();
                }
            }
            else
            {
                f4 = new Form4("请先选定调整项！");
                f4.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.paraments = readPara();
            TempSet.Text = f1.paraments[0].ToString("0.000");
            TempMod.Text = f1.paraments[1].ToString("0.000");
            ForwardMod.Text = f1.paraments[2].ToString("0.000");
            Fuzzy.Text = f1.paraments[3].ToString("0");
            Ratio.Text = f1.paraments[4].ToString("0");
            Integration.Text = f1.paraments[5].ToString("0");
            Power.Text = f1.paraments[6].ToString("0");
            FlucSet.Text = f1.getFluacCrite().ToString("0.000");
        }

        private void FlucSet_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = FlucSet;
            tx.BackColor = Color.White;
        }

        private void FlucSet_LostFocus(object sender, EventArgs e)
        {
            FlucSet.BackColor = Color.Gainsboro;
        }
    }
}