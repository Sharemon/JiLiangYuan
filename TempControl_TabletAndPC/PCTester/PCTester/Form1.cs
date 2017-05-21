using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace PCTester
{
    public partial class Form1 : Form
    {
        private SerialPort sp = new SerialPort();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                try
                {
                    sp.PortName = "COM" + i;
                    sp.Open();
                    sp.Close();

                    cmbComPort.Items.Add(sp.PortName);
                }
                catch (Exception)
                {
                    ;
                }
            }

            if(cmbComPort.Items.Count > 0)
                cmbComPort.SelectedIndex = 0;

            sp.BaudRate = 115200;
            sp.ReadTimeout = 2000;
        }

        private bool CheckLinked()
        {
            sp.PortName = cmbComPort.Text;

            try
            {
                sp.Open();
                sp.Write("ECHO!@");
                string back = sp.ReadTo("@");
                sp.DiscardInBuffer();
                sp.Close();
                if (back != "ECHO$")
                    return false;
            }
            catch (Exception)
            {
                if (sp.IsOpen)
                    sp.Close();
                return false;
            }

            if (sp.IsOpen)
                sp.Close();
            return true;

        }

        private void bntCheckLink_Click(object sender, EventArgs e)
        {
            chbLinked.Checked = CheckLinked();
        }

        private void BntExit_Click(object sender, EventArgs e)
        {
            if(!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("EXIT!@");
            sp.DiscardInBuffer();
            sp.Close();
        }

        private void bntReadCurTemp_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("CTEMP?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtCurTemp.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadCurPower_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("CPOWER?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtCurPower.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadFluct_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("FLUCT?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtFluct.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadTempSet_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("TMSET?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtTempSet.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadTempMod_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("TMMOD?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtTempMod.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadForword_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("FORWO?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtForword.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadFuzzy_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("FUZZY?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtFuzzy.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadProp_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("PROP?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtProp.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadInteg_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("INTEG?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtInteg.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntReadPwrCo_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            sp.Open();
            sp.Write("PWRCO?@");
            string read = sp.ReadTo("$");
            sp.DiscardInBuffer();
            txtPwrCo.Text = read.Split(new char[] { ':' })[1];
            sp.Close();
        }

        private void bntWriteTempSet_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if(!float.TryParse(txtTempSet.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("TMSET:{0:f3}!@",value));
            sp.Close();
        }

        private void bntWriteTempMod_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if (!float.TryParse(txtTempMod.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("TMMOD:{0:f3}!@", value));
            sp.Close();
        }

        private void bntWriteForword_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if (!float.TryParse(txtForword.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("FORWO:{0:f3}!@", value));
            sp.Close();
        }

        private void bntWriteFuzzy_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if (!float.TryParse(txtFuzzy.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("FUZZY:{0:f3}!@", value));
            sp.Close();
        }

        private void bntWriteProp_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if (!float.TryParse(txtProp.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("PROP:{0:f3}!@", value));
            sp.Close();
        }

        private void bntWriteInteg_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if (!float.TryParse(txtInteg.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("INTEG:{0:f3}!@", value));
            sp.Close();
        }

        private void bntWritePwrCo_Click(object sender, EventArgs e)
        {
            if (!CheckLinked())
            {
                MessageBox.Show("连接错误！");
                return;
            }

            float value = 0.0f;
            if (!float.TryParse(txtPwrCo.Text, out value))
            {
                MessageBox.Show("请确认输入正确后再试！");
                return;
            }

            sp.Open();
            sp.Write(string.Format("PWRCO:{0:f3}!@", value));
            sp.Close();
        }
    }
}
