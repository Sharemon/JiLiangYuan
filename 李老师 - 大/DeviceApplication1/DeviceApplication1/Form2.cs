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
        private TimeSpan controlTime;
        Bitmap bmp = new Bitmap(800, 530);
        Pen myPen;
        Brush br = new SolidBrush(Color.Yellow);
        Graphics ghp;
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
            timer2.Interval = 900;
            timer2.Enabled = true;
            ghp = Graphics.FromImage(bmp);
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
            myPen = new Pen(Color.DarkGreen);
            ghp.Clear(Color.Black);

            //xy轴
            ghp.DrawLine(myPen, 105, 25, 105, 505);
            ghp.DrawLine(myPen, 105, 505, 765, 505);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = 0; i < 8; i++)
            {
                ghp.DrawLine(myPen, 105, 25 + i * 60, 765, 25 + i * 60);
            }
            for (int i = 1; i < 12; i++)
            {
                ghp.DrawLine(myPen, 105 + i * 60, 25, 105 + i * 60, 505);
            }
            //数据画图
            myPen = new Pen(Color.Red);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            float tempMid = (tempMax + tempMin) / 2;
            float Width = tempMax - tempMin;
            if (f1.temperature.Count > 1)
            {
                for (int i = 0; i < f1.temperature.Count- 1; i++)
                {
                    ghp.DrawLine(myPen, 105 + i , 265 - (int)((f1.temperature[i] - tempMid) / Width *480),
                                                            105 + (i + 1), 265 - (int)((f1.temperature[i+1] - tempMid) / Width * 480));
                }

                //myPen = new Pen(Color.LightGreen,2);
                //myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //ghp.DrawLine
                //   (myPen, 20, 205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count % 2] - tempMid) / Width * 360),
                //  20 + ((f1.temperature.Count -1) / 2 ), 205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count%2] - tempMid) / Width * 360));
                //ghp.DrawRectangle(myPen, 105 + ((f1.temperature.Count - 1) / 2), 205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count % 2] - tempMid) / Width * 360), 3, 3);
                ghp.DrawString(tempMax.ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 25-8);
                ghp.DrawString(tempMin.ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 505 - 8);
                ghp.DrawString((tempMax - Width / 8).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 85 - 8);
                ghp.DrawString((tempMax - Width / 4).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 145 - 8);
                ghp.DrawString((tempMax - Width / 8 * 3).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 205 - 8);
                ghp.DrawString((tempMin + Width / 2).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 265 - 8);
                ghp.DrawString((tempMin + Width / 8 * 3).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 325 - 8);
                ghp.DrawString((tempMin + Width / 4).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 385 - 8);
                ghp.DrawString((tempMin + Width / 8).ToString("0.0000"), new Font("宋体", 12, FontStyle.Regular), br, 30, 445 - 8);

                // X-Axis : Time
                DateTime dt = DateTime.Now;
                int hour = dt.Hour;
                int minut = (int)Math.Round(dt.Minute + (float)dt.Second/60.0- (f1.temperature.Count * 2 / 60.0) - 6);
                if (minut < 0)
                {
                    hour--;
                    if (hour < 0)
                    {
                        hour = hour + 24;
                    }
                    minut = minut + 60;
                }

                for (int i = 0; i < 4; i++)
                {
                    minut = minut + 6;
                    if (minut >= 60)
                    {
                        hour++;
                        if (hour >= 24)
                        {
                            hour = hour - 24;
                        }
                        minut = minut - 60;
                    }
                    ghp.DrawString(hour.ToString("00") + ":" + minut.ToString("00"), new Font("宋体", 12, FontStyle.Regular), br, 105 + i*3*60 - 15, 505 + 10);  
              
                }
                //ghp.DrawString
                //    (f1.temperature[f1.temperature.Count - 1].ToString("0.0000"),
                //    new Font("宋体", 12, FontStyle.Bold), br,
                //    100 + f1.temperature.Count - 2 + f1.temperature.Count % 2, 
                //    205 - (int)((f1.temperature[f1.temperature.Count - 2 + f1.temperature.Count % 2] - tempMid) / Width * 360));
            }
            pictureBox1.Image = bmp;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Calculate the Max and Min
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
            // 为了保证每格的最小分辨率为0.0001(大跟中小不一样),要处理一下
            tempMax = (float)Math.Round(tempMax, 4);
            tempMin = (float)Math.Round(tempMin, 4);
            if (tempMax - tempMin <= 0.0008)
            {
                float tempWidth = tempMax - tempMin;
                tempMax = (float)Math.Round(tempMax + (0.0008 - tempWidth) / 2, 4);
                tempMin = tempMax - 0.0008F;
            }

            // Show the fluction
            if (f1.temperature2.Count > f1.tempNum2-2)
            {
                Fluctuation.Text = f1.getFluactuation().ToString("0.0000") + "℃/10min";
            }
            else
            {
                Fluctuation.Text = "N/A";
            }

            // draw chart
            draw();
        }

        private void Form2_Closing(object sender, CancelEventArgs e)
        {
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            if (timer1 != null)
            {
                timer1.Dispose();
            } 
            if (timer2 != null)
            {
                timer2.Dispose();
            }
            if (ghp != null)
            {
                ghp.Dispose();
            }
            if (bmp != null)
            {
                bmp.Dispose();
            }
            if (myPen != null)
            {
                myPen.Dispose();
            }
            if (br != null)
            {
                br.Dispose();
            }
            GC.Collect();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            f1.temperature.RemoveRange(0,f1.temperature.Count-1);
            //timerCount = 1;
            timer1.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            controlTime = DateTime.Now - f1.startTime;
            CtrlTime.Text = controlTime.Hours + ":" + controlTime.Minutes + ":" + controlTime.Seconds;
        }

        private void CtrlTime_GotFocus(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Fluctuation_GotFocus(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}