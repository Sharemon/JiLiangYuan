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
        //bool timerFlag = false;
        private int errorFlag = 0;
        //bool readFlag = false;
        private TextBox tx;
        private Form f4;
        private int dataNum2 = 0;
        private string fileName;
        private StreamWriter sw;

        public Form3(MainForm myf1)
        {
            InitializeComponent();
            this.f1 = myf1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            API_WDT_Disable();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(80, 0);
            this.TopMost = true;
            //while (f1.sp.IsOpen)
            {
                //Application.DoEvents();
            }
            if (f1.timer1.Enabled)
            {
                f1.timer1.Enabled = false;
                f1.timer1Flag = true;
            }
            else
            {
                f1.timer1Flag = false;
            }
                txt2.Text = "";
                txt3.Text = f1.paraments[2].ToString("0.000"); 
                txt4.Text = f1.paraments[4].ToString("0.000");
                txt5.Text = f1.paraments[5].ToString("0.000");
                txt6.Text = f1.paraments[6].ToString("0.000");        
        }

        private void button1_click(object sender, EventArgs e)
        {
            //f1.sp.Open();
            if (f1.sp.BytesToRead > 0)
            {
                f1.sp.DiscardInBuffer();
            }
            //f1.sp.Close();
            button1.Enabled = false;
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
            sw.Write("\r\n" + "\r\n");

            sw.Write
                (DateTime.Now.ToString("u") + "\r\n"
                + "SV:      " + f1.paraments[2].ToString("0.000") + "\r\n"
                //+ "THR:     " + f1.AdvancedPara[0].ToString("0") + "\r\n"
                + "O:       " + "" + "\r\n"
                + "P:       " + f1.paraments[4].ToString("0.000") + "\r\n"
                + "I:       " + f1.paraments[5].ToString("0.000") + "\r\n"
                + "D:       " + f1.paraments[6].ToString("0.000") + "\r\n"
                , Encoding.Default);

            //参数更新
            //f1.sp.Open();
            if (txt3.Text.Trim() != string.Empty && float.Parse(txt3.Text) != f1.paraments[2])
            {
                f1.txtSend("@35S" + float.Parse(txt3.Text).ToString("0.000") + ":");
                Thread.Sleep(1000);
                if (f1.sp.BytesToRead > 0)
                {
                    f1.paraments[2] = float.Parse(txt3.Text);
                    f1.sp.DiscardInBuffer();
                }
                else
                {
                    errorFlag = 1;
                    txt3.Text = f1.paraments[2].ToString("0.000");
                }
                Thread.Sleep(100);
            }
            
            if (txt2.Text.Trim() != string.Empty)
            {
                f1.txtSend("@35O" + float.Parse(txt2.Text).ToString("0.000") + ":");
                Thread.Sleep(500);
                if (f1.sp.BytesToRead > 0)
                {
                    f1.paraments[1] = float.Parse(txt2.Text);
                    f1.sp.DiscardInBuffer();
                }
                else
                {
                    errorFlag = 3;
                    txt2.Text = "";
                }
                Thread.Sleep(100);
            }

            if (txt4.Text.Trim() != string.Empty && float.Parse(txt4.Text) != f1.paraments[4])
            {
                f1.txtSend("@35P" + float.Parse(txt4.Text).ToString("0.000") + ":");
                Thread.Sleep(500);
                if (f1.sp.BytesToRead > 0)
                {
                    f1.paraments[4] = float.Parse(txt4.Text);
                    f1.sp.DiscardInBuffer();
                }
                else
                {
                    errorFlag = 4;
                    txt4.Text = f1.paraments[4].ToString("0.000");
                }
                Thread.Sleep(100);
            }

            if (txt5.Text.Trim() != string.Empty && float.Parse(txt5.Text) != f1.paraments[5])
            {
                f1.txtSend("@35I" + float.Parse(txt5.Text).ToString("0.000") + ":");
                Thread.Sleep(1000);
                if (f1.sp.BytesToRead > 0)
                {
                    f1.paraments[5] = float.Parse(txt5.Text);
                    f1.sp.DiscardInBuffer();
                }
                else
                {
                    errorFlag = 5;
                    txt5.Text = f1.paraments[5].ToString("0.000");
                }
                Thread.Sleep(100);
            }

            if (txt6.Text.Trim() != string.Empty && float.Parse(txt6.Text) != f1.paraments[6])
            {
                f1.txtSend("@35D" + float.Parse(txt6.Text).ToString("0.000") + ":");
                Thread.Sleep(500);
                if (f1.sp.BytesToRead > 0)
                {
                    f1.paraments[6] = float.Parse(txt6.Text);
                    f1.sp.DiscardInBuffer();
                }
                else
                {
                    errorFlag = 6;
                    txt6.Text = f1.paraments[6].ToString("0.000");
                }
                Thread.Sleep(100);
            }

            //f1.sp.Close();
            switch (errorFlag)
            {
                case 0:
                    f4 = new Form4("参数已更新！");
                    f4.Show();
                    break;
                case 1:
                    f4 = new Form4("设定值设定不成功！");
                    f4.Show();
                    break;
                case 2:
                    f4 = new Form4("三项点瓶状态设定不成功！");
                    f4.Show();
                    break;
                case 3:
                    f4 = new Form4("修正值设定不成功！");
                    f4.Show();
                    break;
                case 4:
                    f4 = new Form4("PID参数P设定不成功！");
                    f4.Show();
                    break;
                case 5:
                    f4 = new Form4("PID参数I设定不成功！");
                    f4.Show();
                    break;
                case 6:
                    f4 = new Form4("PID参数D设定不成功！");
                    f4.Show();
                    break;
                case 7:
                    f4 = new Form4("最大功率设定不成功！");
                    f4.Show();
                    break;
                case 8:
                    f4 = new Form4("遥控/本地设定不成功！");
                    f4.Show();
                    break;
                default: break;
            }
            errorFlag = 0;

            sw.Write
                ("Paraments Changed to:  " + "\r\n"
                + "SV:     " + f1.paraments[2].ToString("0.000") + "\r\n"
                //+ "THR:    " + f1.AdvancedPara[0].ToString("0") + "\r\n"
                + "O:      " + f1.paraments[1].ToString("0.000") + "\r\n"
                + "P:      " + f1.paraments[4].ToString("0.000") + "\r\n"
                + "I:      " + f1.paraments[5].ToString("0.000") + "\r\n"
                + "D:      " + f1.paraments[6].ToString("0.000") + "\r\n"
                , Encoding.Default);
            dataNum2++;
            if (dataNum2 == 201)
            {
                dataNum2 = 0;
            }
            sw.Close();

            button1.Enabled = true;
            GC.Collect();
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
                if ((tx.Text == "-" || tx.Text.Length != 1 || int.Parse(tx.Text) != 0) && tx.Text != "-0")
                {
                    string str = tx.Text;
                    str += "0";
                    tx.Text = str;
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

        private void txt2_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt2;
            tx.BackColor = Color.White;
        }

        private void txt3_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt3;
            tx.BackColor = Color.White;
        }

        private void txt4_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt4;
            tx.BackColor = Color.White;
        }

        private void txt5_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt5;
            tx.BackColor = Color.White;
        }

        private void txt6_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt6;
            tx.BackColor = Color.White;
        }

        private void Form3_Closing(object sender, CancelEventArgs e)
        {
            if (f1.timer1Flag)
            {
                f1.timer1.Enabled = true;
                f1.timer1Flag = false;
            }
            API_WDT_Enable();
            GC.Collect();
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
    }
}