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
    public partial class SetTempForm : Form
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
        //private TextBox TempSet;
        private Form f4;
        private int dataNum2 = 0;
        private string fileName;
        private StreamWriter sw;
        private bool firstFlag = true;  //如果第一次用键盘，就清除textbox

        public SetTempForm(MainForm myf1)
        {
            InitializeComponent();
            this.f1 = myf1;
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
            //sw.Write("\r\n" + "\r\n");

            sw.Write
                (DateTime.Now.ToString("u") + "\r\n"
                + "\t温度设定值:               " + f1.paraments[0].ToString("0.0000") + "\r\n"
                , Encoding.Default);

            button1.Enabled = false;

            //参数更新
            errorFlag = false;
            //f1.serialPort1.Open();

            if ((TempSet.Text.Trim() != string.Empty) && (float.Parse(TempSet.Text) != f1.paraments[0]))
            {
                f1.serialPort1.WriteLine("@35WA" + float.Parse(TempSet.Text).ToString("0.0000") + ":\r");
                errorFlag = isError();
                if (!errorFlag)
                {
                    f1.paraments[0] = float.Parse(TempSet.Text);
                    f1.TempSet = f1.paraments[0];
                }
                else
                {
                    TempSet.Text = f1.paraments[0].ToString("0.0000");
                }
                Thread.Sleep(100);
            }

            //f1.serialPort1.Close();
            //f1.serialPort1.Dispose();
            //    readFlag = false;
            //}
            //else
            //{
            //  MessageBox.Show("请先读取参数！");
            //}
            sw.Write
                ("参数修改为->  " + "\r\n"
                + "\t温度设定值:               " + f1.paraments[0].ToString("0.0000") + "\r\n"
                , Encoding.Default);

            sw.Write("\r\n" + "\r\n");

            dataNum2++;
            if (dataNum2 == 21)
            {
                dataNum2 = 0;
            }
            sw.Close();
            button1.Enabled = true;
            //GC.Collect();

            //提示参数调整成功后直接退出
            f4 = new Form4("温度已设定成功！");
            f4.ShowDialog();
            this.Close();
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


        /// <summary>
        /// 判断是否第一次按键盘。如果是，就清除textbox
        /// </summary>
        private void IsFirstClick()
        {
            if (firstFlag)
            {
                TempSet.Text = "";
                firstFlag = false;
            }
        }


        private void one_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "1";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "2";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "3";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "4";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "5";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "6";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void seven_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "7";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void eight_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "8";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = TempSet.Text + "9";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void zero_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                if (TempSet.Text.Length != 1 || int.Parse(TempSet.Text) != 0)
                {
                    TempSet.Text = TempSet.Text + "0";
                }
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void dot_Click(object sender, EventArgs e)
        {
            IsFirstClick();
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                bool dotFlag = true;
                for (int i = 0; i < TempSet.Text.Length; i++)
                {
                    if (Convert.ToInt32(TempSet.Text[i]) == 46)
                    {
                        dotFlag = false;
                        break;
                    }
                }
                if (dotFlag)
                {
                    TempSet.Text = TempSet.Text + ".";
                }
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                if (TempSet.Text.Length > 0)
                {
                    TempSet.Text = TempSet.Text.Substring(0, TempSet.Text.Length - 1);
                }
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void TempSet_GotFocus(object sender, EventArgs e)
        {
            ;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                TempSet.Text = "";
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (TempSet != null)
            {
                TempSet.BackColor = Color.White;
                if (TempSet.Text == "")
                {
                    TempSet.Text = "-";
                }
                else if (TempSet.Text.Length == 1 && Convert.ToInt32(TempSet.Text[0]) == 45)
                {
                    TempSet.Text = "";
                }
                else
                {
                    float temp = 0.0F - float.Parse(TempSet.Text);
                    TempSet.Text = temp.ToString();
                }
            }
            else
            {
                f4 = new Form4("请先点击温度文本框！");
                f4.Show();
            }
        }

        /*
         * 函数：readPara
         * 功能：读取参数
         * 输入：
         * 输出：参数数组
         * 
         */
        private float readPara()
        {
            float[] para = new float[7];
            //f1.serialPort1.Open();
            try
            {
                for (int i = 65; i <= 65; i++)
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
            return para[0];
        }

        private void SetTempForm_Load(object sender, EventArgs e)
        {
            TempSet.Focus();
            API_WDT_Disable();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(200, 0);
            if (f1.timer1.Enabled)
            {
                f1.timer1.Enabled = false;
                timerFlag = true;
            }
            else
            {
                timerFlag = false;
            }
            f1.paraments[0] = readPara();
            TempSet.Text = f1.paraments[0].ToString("0.0000");
        }

        private void SetTempForm_Closing(object sender, CancelEventArgs e)
        {
            if (timerFlag)
            {
                f1.timer1.Enabled = true;
                timerFlag = false;
            }
            API_WDT_Enable();
        }

        private void Plus10_Click(object sender, EventArgs e)
        {
            TempSet.Text = (float.Parse(TempSet.Text) + 10).ToString("0.0000");
        }

        private void Plus5_Click(object sender, EventArgs e)
        {
            TempSet.Text = (float.Parse(TempSet.Text) + 5).ToString("0.0000");
        }

        private void Minus5_Click(object sender, EventArgs e)
        {
            TempSet.Text = (float.Parse(TempSet.Text) - 5).ToString("0.0000");
        }

        private void Minus10_Click(object sender, EventArgs e)
        {
            TempSet.Text = (float.Parse(TempSet.Text) - 10).ToString("0.0000");
        }

    }
}