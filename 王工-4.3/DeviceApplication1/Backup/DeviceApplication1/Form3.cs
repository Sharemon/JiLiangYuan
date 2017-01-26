using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace DeviceApplication1
{
    public partial class Form3 : Form
    {
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
            this.FormBorderStyle = FormBorderStyle.None;
            comboBox1.Items.Add("ģʽһ");
            comboBox1.Items.Add("ģʽ��");
            //comboBox1.Items.Add("ģʽ��");

            if (f1.paraments[9] == 2)
            {
                label1.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                txt1.Visible = false;
                txt4.Visible = false;
                txt5.Visible = false;
                txt6.Visible = false;
                txt7.Visible = false;
                txt8.Visible = false;
                label2.Text = "�䶳/����";
                label3.Text = "�� �� ֵ";
                txt2.Text = f1.AdvancedPara[0].ToString("0");
                txt3.Text = f1.paraments[2].ToString("0.000");
                comboBox1.Text = "ģʽһ";
            }
            else if (f1.paraments[9] == 1)
            {
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                txt1.Visible = false;
                txt2.Visible = true;
                txt3.Visible = true;
                txt4.Visible = true;
                txt5.Visible = true;
                txt6.Visible = true;
                txt7.Visible = false;
                txt8.Visible = false;
                label1.Text = "�����ƿ״̬";
                label2.Text = "�� �� ֵ";
                label3.Text = "�� �� ֵ";
                label4.Text = "PID����P";
                label5.Text = "PID����I";
                label6.Text = "PID����D";
                label7.Text = "�����";
                txt1.Text =  f1.AdvancedPara[0].ToString("0");
                txt2.Text = f1.paraments[2].ToString("0.000");
                txt3.Text = f1.paraments[1].ToString("0.000"); 
                txt4.Text = f1.paraments[4].ToString("0.000");
                txt5.Text = f1.paraments[5].ToString("0.000");
                txt6.Text = f1.paraments[6].ToString("0.000");
                txt7.Text = f1.paraments[7].ToString("0");
                comboBox1.Text = "ģʽ��";
            }
            else if (f1.paraments[9] == 0)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                txt1.Visible = true;
                txt2.Visible = true;
                txt3.Visible = true;
                txt4.Visible = true;
                txt5.Visible = true;
                txt6.Visible = true;
                txt7.Visible = true;
                txt8.Visible = true;
                label1.Text = "�����¶�";
                label2.Text = "��������¶�";
                label3.Text = "�������";
                label4.Text = "�����Ͷ�";
                label5.Text = "�����߶�";
                label6.Text = "�����ж�";
                label7.Text = "��  ��";
                label8.Text = "��  ��";
                txt1.Text = f1.AdvancedPara[1].ToString("0.000");
                txt2.Text = f1.AdvancedPara[2].ToString("0.000");
                txt3.Text = f1.AdvancedPara[3].ToString("0");
                txt4.Text = f1.AdvancedPara[4].ToString("0.000");
                txt5.Text = f1.AdvancedPara[5].ToString("0.000");
                txt6.Text = f1.AdvancedPara[6].ToString("0.000");
                txt7.Text = f1.AdvancedPara[7].ToString("0.000");
                txt8.Text = f1.AdvancedPara[8].ToString("0.000");
                comboBox1.Text = "ģʽ��";
            }

            //���������ʱ��

            while (f1.sp.IsOpen)
            {
                Application.DoEvents();
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
        }

        private void button1_click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            switch (Convert.ToInt32(f1.paraments[9]))
            {
                case 2:
                    {
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
                            + "F/P:    " + f1.AdvancedPara[9].ToString("0.000") + "\r\n"
                            + "O:      " + f1.paraments[2].ToString("0.000") + "\r\n"
                            , Encoding.Default);

                        //��������
                        f1.sp.Open();

                        if (txt2.Text.Trim() != string.Empty && float.Parse(txt2.Text) != f1.AdvancedPara[0])
                        {
                            if (float.Parse(txt2.Text) == 1 || float.Parse(txt2.Text) == 0)
                            {
                                f1.txtSend("@35T" + float.Parse(txt2.Text).ToString("0") + ":");
                                Thread.Sleep(1000);
                                if (f1.sp.BytesToRead > 0)
                                {
                                    f1.AdvancedPara[0] = float.Parse(txt2.Text);
                                    f1.sp.DiscardInBuffer();
                                }
                                else
                                {
                                    errorFlag = 1;
                                    txt2.Text = f1.AdvancedPara[0].ToString("0");
                                }
                                Thread.Sleep(100);
                            }
                            else
                            {
                                errorFlag = 1;
                                txt1.Text = f1.AdvancedPara[0].ToString("0");
                            }
                        }

                        if (txt3.Text.Trim() != string.Empty && float.Parse(txt3.Text) != f1.paraments[2])
                        {
                            f1.txtSend("@35O" + float.Parse(txt3.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if(f1.sp.BytesToRead > 0)
                            {
                                f1.paraments[2] = float.Parse(txt3.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 2;
                                txt3.Text = f1.paraments[2].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        f1.sp.Close();
                        switch (errorFlag)
                        {
                            case 0:
                                f4 = new Form4("�����Ѹ��£�");
                                f4.Show();
                                break;
                            case 1:
                                f4 = new Form4("�䶳/�����趨���ɹ���");
                                f4.Show();
                                break;
                            case 2:
                                f4 = new Form4("����ֵ�趨���ɹ���");
                                f4.Show();
                                break;
                            default: break;
                        }
                        errorFlag = 0;

                        sw.Write
                            ("Paraments Changed to:  " + "\r\n"
                            + "F/P:    " + f1.AdvancedPara[9].ToString("0.000") + "\r\n"
                            + "O:      " + f1.paraments[2].ToString("0.000") + "\r\n"
                            , Encoding.Default);
                        dataNum2++;
                        if (dataNum2 == 201)
                        {
                            dataNum2 = 0;
                        }
                        sw.Close();
                    }
                    break;
                case 1:
                    {
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
                            + "SV:      " + f1.paraments[1].ToString("0.000") + "\r\n"
                            //+ "THR:     " + f1.AdvancedPara[0].ToString("0") + "\r\n"
                            + "O:       " + f1.paraments[2].ToString("0.000") + "\r\n"
                            + "P:       " + f1.paraments[4].ToString("0.000") + "\r\n"
                            + "I:       " + f1.paraments[5].ToString("0.000") + "\r\n"
                            + "D:       " + f1.paraments[6].ToString("0.000") + "\r\n"
                            + "M:       " + f1.paraments[7].ToString("0") + "\r\n"
                            + "R:       " + f1.paraments[8].ToString("0") + "\r\n"
                            , Encoding.Default);

                        //��������
                        f1.sp.Open();
                        if (txt3.Text.Trim() != string.Empty && float.Parse(txt3.Text) != f1.paraments[1])
                        {
                            f1.txtSend("@35S"+ float.Parse(txt3.Text).ToString("0.000") + ":");
                            Thread.Sleep(1000);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.paraments[1] = float.Parse(txt3.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 1;
                                txt3.Text = f1.paraments[1].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }
                        /*
                        if (txt1.Text.Trim() != string.Empty && float.Parse(txt1.Text) != f1.AdvancedPara[0])
                        {
                            f1.txtSend("@35T" + float.Parse(txt1.Text).ToString("0") + ":");
                            Thread.Sleep(1000);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[0] = float.Parse(txt1.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 2;
                                txt1.Text = f1.AdvancedPara[0].ToString("0");
                            }
                            Thread.Sleep(100);
                        }
                        */
                        if (txt2.Text.Trim() != string.Empty && float.Parse(txt2.Text) != f1.paraments[2])
                        {
                            f1.txtSend("@35O" + float.Parse(txt2.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.paraments[2] = float.Parse(txt2.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 3;
                                txt2.Text = f1.paraments[2].ToString("0.000");
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
                            Thread.Sleep(500);
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

                        if (txt7.Text.Trim() != string.Empty && float.Parse(txt7.Text) != f1.paraments[7])
                        {
                            f1.txtSend("@35M" + float.Parse(txt7.Text).ToString("0") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.paraments[7] = float.Parse(txt7.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 7;
                                txt7.Text = f1.paraments[7].ToString("0");
                            }
                            Thread.Sleep(100);
                        }
                        
                        f1.sp.Close();
                        switch (errorFlag)
                        {
                            case 0:
                                f4 = new Form4("�����Ѹ��£�");
                                f4.Show();
                                break;
                            case 1:
                                f4 = new Form4("�趨ֵ�趨���ɹ���");
                                f4.Show();
                                break;
                            case 2:
                                f4 = new Form4("�����ƿ״̬�趨���ɹ���");
                                f4.Show();
                                break;
                            case 3:
                                f4 = new Form4("����ֵ�趨���ɹ���");
                                f4.Show();
                                break;
                            case 4:
                                f4 = new Form4("PID����P�趨���ɹ���");
                                f4.Show();
                                break;
                            case 5:
                                f4 = new Form4("PID����I�趨���ɹ���");
                                f4.Show();
                                break;
                            case 6:
                                f4 = new Form4("PID����D�趨���ɹ���");
                                f4.Show();
                                break;
                            case 7:
                                f4 = new Form4("������趨���ɹ���");
                                f4.Show();
                                break;
                            case 8:
                                f4 = new Form4("ң��/�����趨���ɹ���");
                                f4.Show();
                                break;
                            default: break;
                        }
                        errorFlag = 0;

                        sw.Write
                            ("Paraments Changed to:  " + "\r\n"
                            + "SV:     " + f1.paraments[1].ToString("0.000") + "\r\n"
                            //+ "THR:    " + f1.AdvancedPara[0].ToString("0") + "\r\n"
                            + "O:      " + f1.paraments[2].ToString("0.000") + "\r\n"
                            + "P:      " + f1.paraments[4].ToString("0.000") + "\r\n"
                            + "I:      " + f1.paraments[5].ToString("0.000") + "\r\n"
                            + "D:      " + f1.paraments[6].ToString("0.000") + "\r\n"
                            + "M:      " + f1.paraments[7].ToString("0") + "\r\n"
                            + "R:      " + f1.paraments[8].ToString("0") + "\r\n"
                            , Encoding.Default);
                        dataNum2++;
                        if (dataNum2 == 201)
                        {
                            dataNum2 = 0;
                        }
                        sw.Close();
                    }
                    break;
                case 0:
                    {
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
                            + "ALM:    " + f1.paraments[1].ToString("0.000") + "\r\n"
                            + "DIFF:   " + f1.AdvancedPara[0].ToString("0") + "\r\n"
                            + "NUM:    " + f1.paraments[2].ToString("0.000") + "\r\n"
                            + "LPO:    " + f1.paraments[4].ToString("0.000") + "\r\n"
                            + "HPO:    " + f1.paraments[5].ToString("0.000") + "\r\n"
                            + "MPO:    " + f1.paraments[6].ToString("0.000") + "\r\n"
                            + "ZERO:   " + f1.paraments[7].ToString("0") + "\r\n"
                            + "FULL:   " + f1.paraments[8].ToString("0") + "\r\n"
                            , Encoding.Default);

                        //��������
                        f1.sp.Open();
                        if (txt1.Text.Trim() != string.Empty && float.Parse(txt1.Text) != f1.AdvancedPara[1])
                        {
                            f1.txtSend("@35A" + float.Parse(txt1.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[1] = float.Parse(txt1.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 1;
                                txt1.Text = f1.AdvancedPara[1].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt2.Text.Trim() != string.Empty && float.Parse(txt2.Text) != f1.AdvancedPara[2])
                        {
                            f1.txtSend("@35E" + float.Parse(txt2.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[2] = float.Parse(txt2.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 2;
                                txt2.Text = f1.AdvancedPara[2].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt3.Text.Trim() != string.Empty && float.Parse(txt3.Text) != f1.AdvancedPara[3])
                        {
                            f1.txtSend("@35N" + float.Parse(txt3.Text).ToString("0") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[3] = float.Parse(txt3.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 3;
                                txt3.Text = f1.AdvancedPara[3].ToString("0");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt4.Text.Trim() != string.Empty && float.Parse(txt1.Text) != f1.AdvancedPara[4])
                        {
                            f1.txtSend("@35W" + float.Parse(txt4.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[4] = float.Parse(txt4.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 4;
                                txt4.Text = f1.AdvancedPara[4].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt5.Text.Trim() != string.Empty && float.Parse(txt5.Text) != f1.AdvancedPara[5])
                        {
                            f1.txtSend("@35H" + float.Parse(txt5.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[5] = float.Parse(txt5.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 5;
                                txt5.Text = f1.AdvancedPara[5].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt6.Text.Trim() != string.Empty && float.Parse(txt6.Text) != f1.AdvancedPara[6])
                        {
                            f1.txtSend("@35B" + float.Parse(txt6.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[6] = float.Parse(txt6.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 6;
                                txt6.Text = f1.AdvancedPara[6].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt7.Text.Trim() != string.Empty && float.Parse(txt7.Text) != f1.AdvancedPara[7])
                        {
                            f1.txtSend("@35Z" + float.Parse(txt7.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[7] = float.Parse(txt7.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 7;
                                txt7.Text = f1.AdvancedPara[7].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        if (txt8.Text.Trim() != string.Empty && float.Parse(txt8.Text) != f1.AdvancedPara[8])
                        {
                            f1.txtSend("@35F" + float.Parse(txt8.Text).ToString("0.000") + ":");
                            Thread.Sleep(500);
                            if (f1.sp.BytesToRead > 0)
                            {
                                f1.AdvancedPara[8] = float.Parse(txt8.Text);
                                f1.sp.DiscardInBuffer();
                            }
                            else
                            {
                                errorFlag = 8;
                                txt8.Text = f1.AdvancedPara[8].ToString("0.000");
                            }
                            Thread.Sleep(100);
                        }

                        f1.sp.Close();
                        switch (errorFlag)
                        {
                            case 0:
                                f4 = new Form4("�����Ѹ��£�");
                                f4.Show();
                                break;
                            case 1:
                                f4 = new Form4("�����¶��趨���ɹ���");
                                f4.Show();
                                break;
                            case 2:
                                f4 = new Form4("��������¶��趨���ɹ���");
                                f4.Show();
                                break;
                            case 3:
                                f4 = new Form4("��������趨���ɹ���");
                                f4.Show();
                                break;
                            case 4:
                                f4 = new Form4("�����Ͷ��趨���ɹ���");
                                f4.Show();
                                break;
                            case 5:
                                f4 = new Form4("�����߶��趨���ɹ���");
                                f4.Show();
                                break;
                            case 6:
                                f4 = new Form4("�����ж��趨���ɹ���");
                                f4.Show();
                                break;
                            case 7:
                                f4 = new Form4("�����趨���ɹ���");
                                f4.Show();
                                break;
                            case 8:
                                f4 = new Form4("�����趨���ɹ���");
                                f4.Show();
                                break;
                            default: break;
                        }
                        errorFlag = 0;

                        sw.Write
                            ("Paraments Changed to:  " + "\r\n"
                            + "ALM:    " + f1.paraments[1].ToString("0.000") + "\r\n"
                            + "DIFF:   " + f1.AdvancedPara[0].ToString("0") + "\r\n"
                            + "NUM:    " + f1.paraments[2].ToString("0.000") + "\r\n"
                            + "LPO:    " + f1.paraments[4].ToString("0.000") + "\r\n"
                            + "HPO:    " + f1.paraments[5].ToString("0.000") + "\r\n"
                            + "MPO:    " + f1.paraments[6].ToString("0.000") + "\r\n"
                            + "ZERO:   " + f1.paraments[7].ToString("0") + "\r\n"
                            + "FULL:   " + f1.paraments[8].ToString("0") + "\r\n"
                            , Encoding.Default);
                        dataNum2++;
                        if (dataNum2 == 201)
                        {
                            dataNum2 = 0;
                        }
                        sw.Close();
                    }
                    break;
                default: break;
            }


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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
                f4.Show();
            }
        }

        private void txt1_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt1;
            tx.BackColor = Color.White;
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

        private void txt7_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt7;
            tx.BackColor = Color.White;
        }

        private void Form3_Closing(object sender, CancelEventArgs e)
        {
            if (f1.timer1Flag)
            {
                f1.timer1.Enabled = true;
                f1.timer1Flag = false;
            }
            GC.Collect();
        }
        /*
        private void TempSet_LostFocus(object sender, EventArgs e)
        {
            txt1.BackColor = Color.Gainsboro;
        }

        private void TempMod_LostFocus(object sender, EventArgs e)
        {
            txt2.BackColor = Color.Gainsboro;
        }

        private void ForwardMod_LostFocus(object sender, EventArgs e)
        {
            txt3.BackColor = Color.Gainsboro;
        }

        private void Fuzzy_LostFocus(object sender, EventArgs e)
        {
            txt4.BackColor = Color.Gainsboro;
        }

        private void Ratio_LostFocus(object sender, EventArgs e)
        {
            txt5.BackColor = Color.Gainsboro;
        }

        private void Integration_LostFocus(object sender, EventArgs e)
        {
            txt6.BackColor = Color.Gainsboro;
        }

        private void Power_LostFocus(object sender, EventArgs e)
        {
            txt7.BackColor = Color.Gainsboro;
        }*/

        private void clear_Click(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.White;
                tx.Text = "";
            }
            else
            {
                f4 = new Form4("����ѡ�������");
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
                f4 = new Form4("����ѡ�������");
                f4.Show();
            }
        }

        private void txt8_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = txt8;
            tx.BackColor = Color.White;
        }

        //private void FlucSet_LostFocus(object sender, EventArgs e)
        //{
        //    txt8.BackColor = Color.Gainsboro;
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    f1.sp.Open();
                    f1.txtSend("@35L2:");
                    Thread.Sleep(500);
                    if (f1.sp.BytesToRead > 0)
                    {
                        f1.paraments[9] = 2;
                        label1.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        txt1.Visible = false;
                        txt4.Visible = false;
                        txt5.Visible = false;
                        txt6.Visible = false;
                        txt7.Visible = false;
                        txt8.Visible = false;

                        label2.Text = "�䶳/����";
                        label3.Text = "�� �� ֵ";
                        txt2.Text = f1.AdvancedPara[0].ToString("0");
                        txt3.Text = f1.paraments[2].ToString("0.000");
                        f1.sp.DiscardInBuffer();
                    }
                    else
                    {
                        f4 = new Form4("����������ʧ�ܣ�");
                        f4.Show();
                    }
                    Thread.Sleep(100);
                    f1.sp.Close();

                    break;
                case 1:
                    if (password.Text == "123456")
                    {

                        f1.sp.Open();
                        f1.txtSend("@35L1:");
                        Thread.Sleep(500);
                        if (f1.sp.BytesToRead > 0)
                        {
                            f1.paraments[9] = 1;
                            label1.Visible = false;
                            label2.Visible = true;
                            label3.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;
                            label7.Visible = false;
                            label8.Visible = false;
                            txt1.Visible = false;
                            txt2.Visible = true;
                            txt3.Visible = true;
                            txt4.Visible = true;
                            txt5.Visible = true;
                            txt6.Visible = true;
                            txt7.Visible = false;
                            txt8.Visible = false;
                            label1.Text = "�����ƿ״̬";
                            label2.Text = "�� �� ֵ";
                            label3.Text = "�� �� ֵ";
                            label4.Text = "PID����P";
                            label5.Text = "PID����I";
                            label6.Text = "PID����D";
                            label7.Text = "�����";
                            txt1.Text =  f1.AdvancedPara[0].ToString("0");
                            txt2.Text = f1.paraments[2].ToString("0.000");
                            txt3.Text = f1.paraments[1].ToString("0.000"); 
                            txt4.Text = f1.paraments[4].ToString("0.000");
                            txt5.Text = f1.paraments[5].ToString("0.000");
                            txt6.Text = f1.paraments[6].ToString("0.000");
                            txt7.Text = f1.paraments[7].ToString("0");
                            f1.sp.DiscardInBuffer();
                        }
                        else
                        {
                            f4 = new Form4("����������ʧ�ܣ�");
                            f4.Show();
                        }
                        Thread.Sleep(100);
                        f1.sp.Close();
                    }
                    else
                    {
                        f4 = new Form4("�������");
                        f4.Show();
                    }
                    break;
                case 2:
                    if (password.Text == "654321")
                    {

                        f1.sp.Open();
                        f1.txtSend("@35L0:");
                        Thread.Sleep(500);
                        if (f1.sp.BytesToRead > 0)
                        {
                            f1.paraments[9] = 0;
                            label1.Visible = true;
                            label2.Visible = true;
                            label3.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;
                            label7.Visible = true;
                            label8.Visible = true;
                            txt1.Visible = true;
                            txt2.Visible = true;
                            txt3.Visible = true;
                            txt4.Visible = true;
                            txt5.Visible = true;
                            txt6.Visible = true;
                            txt7.Visible = true;
                            txt8.Visible = true;
                            label1.Text = "�����¶�";
                            label2.Text = "��������¶�";
                            label3.Text = "�������";
                            label4.Text = "�����Ͷ�";
                            label5.Text = "�����߶�";
                            label6.Text = "�����ж�";
                            label7.Text = "��  ��";
                            label8.Text = "��  ��";
                            txt1.Text = f1.AdvancedPara[1].ToString("0.000");
                            txt2.Text = f1.AdvancedPara[2].ToString("0.000");
                            txt3.Text = f1.AdvancedPara[3].ToString("0");
                            txt4.Text = f1.AdvancedPara[4].ToString("0.000");
                            txt5.Text = f1.AdvancedPara[5].ToString("0.000");
                            txt6.Text = f1.AdvancedPara[6].ToString("0.000");
                            txt7.Text = f1.AdvancedPara[7].ToString("0.000");
                            txt8.Text = f1.AdvancedPara[8].ToString("0.000");
                            f1.sp.DiscardInBuffer();
                        }
                        else
                        {
                            f4 = new Form4("����������ʧ�ܣ�");
                            f4.Show();
                        }
                        Thread.Sleep(100);
                        f1.sp.Close();
                    }
                    else
                    {
                        f4 = new Form4("�������");
                        f4.Show();
                    }
                    break;
                default: break;
            }
            password.Text = "";
        }

        private void password_GotFocus(object sender, EventArgs e)
        {
            if (tx != null)
            {
                tx.BackColor = Color.Gainsboro;
            }
            tx = password;
            tx.BackColor = Color.White;
        }

        //private void password_LostFocus(object sender, EventArgs e)
        //{
        //    password.BackColor = Color.Gainsboro;
        //}
    }
}