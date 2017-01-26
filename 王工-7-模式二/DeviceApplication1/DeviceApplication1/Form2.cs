using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeviceApplication1
{
    public partial class Form2 : Form
    {
        MainForm f1;
        private float tempMax;
        private float tempMin;
        //private TimeSpan controlTime;
        //private int timerCount = 1;

        public Form2(MainForm myf1)
        {
            InitializeComponent();
            this.f1 = myf1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            timer1.Interval = 2000;
            timer1.Enabled = true;
        }
        /*
         * 函数：draw
         * 功能：画图
         * 输入：温度数据
         * 输出：
         * 
         */
        private void draw()
        {
            Bitmap bmp = new Bitmap(800, 410);
            Pen myPen = new Pen(Color.DarkGreen);
            Brush br = new SolidBrush(Color.Yellow);
            Graphics ghp = Graphics.FromImage(bmp);
            ghp.Clear(Color.Black);

            //xy轴
            ghp.DrawLine(myPen, 105, 25, 105, 385);
            ghp.DrawLine(myPen, 105, 385, 765, 385);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = 0; i < 6; i++)
            {
                ghp.DrawLine(myPen, 105, 25 + i * 60, 765, 25 + i * 60);
            }
            for (int i = 1; i < 12; i++)
            {
                ghp.DrawLine(myPen, 105 + i * 60, 25, 105 + i * 60, 385);
            }
            //数据画图
            myPen = new Pen(Color.Red);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            float tempMid = (tempMax + tempMin) / 2;
            float Width = tempMax - tempMin;
            if (f1.temperature.Count > 1)
            {
                for (int i = 0; i < f1.temperature.Count - 1; i++)
                {
                    ghp.DrawLine(myPen, 105 + i, 205 - (int)((f1.temperature[i] - tempMid) / Width * 360),
                                                            105 + (i + 1), 205 - (int)((f1.temperature[i + 1] - tempMid) / Width * 360));
                }

                myPen = new Pen(Color.LightGreen, 2);
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //ghp.DrawLine
                //   (myPen, 20, 205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count % 2] - tempMid) / Width * 360),
                //  20 + ((f1.temperature.Count -1) / 2 ), 205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count%2] - tempMid) / Width * 360));
                //ghp.DrawRectangle(myPen, 105 + ((f1.temperature.Count - 1) / 2), 205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count % 2] - tempMid) / Width * 360), 3, 3);
                ghp.DrawString(tempMax.ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 25 - 8);
                ghp.DrawString(tempMin.ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 385 - 8);
                ghp.DrawString((tempMax - Width / 6).ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 85 - 8);
                ghp.DrawString((tempMax - Width / 3).ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 145 - 8);
                ghp.DrawString((tempMax - Width / 2).ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 205 - 8);
                ghp.DrawString((tempMin + Width / 3).ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 265 - 8);
                ghp.DrawString((tempMin + Width / 6).ToString("0.000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 325 - 8);

                //ghp.DrawString
                //    (f1.temperature[f1.temperature.Count - 1].ToString("0.0000"),
                //    new Font("宋体", 12, FontStyle.Bold), br,
                //    100 + f1.temperature.Count - 2 + f1.temperature.Count % 2, 
                //    205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count % 2] - tempMid) / Width * 360));
            }
            pictureBox1.Image = bmp;

            myPen.Dispose();
            ghp.Dispose();
            br.Dispose();
            GC.Collect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tempMax = f1.temperature[0];
            tempMin = f1.temperature[0];
            for (int i = 0; i < f1.temperature.Count; i = i + 1)
            {
                if (f1.temperature[i] < tempMin)          //求一屏数据的最小值
                {
                    tempMin = f1.temperature[i];
                }
                if (f1.temperature[i] > tempMax)          //求一屏数据的最大值
                {
                    tempMax = f1.temperature[i];
                }
            }

            if (f1.temperature2.Count > 222)
            {
                Fluctuation.Text = f1.getFluactuation().ToString("0.000") + "℃";
            }
            else
            {
                Fluctuation.Text = "N/A";
            }
            draw();
        }

        private void Form2_Closing(object sender, CancelEventArgs e)
        {
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            f1.temperature.RemoveRange(0,f1.temperature.Count-1);
            //timerCount = 1;
            timer1.Enabled = true;
        }

        private void CtrlTime_GotFocus(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Fluctuation_GotFocus(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}