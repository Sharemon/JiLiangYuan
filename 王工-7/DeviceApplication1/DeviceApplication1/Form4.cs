using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeviceApplication1
{
    public partial class Form4 : Form
    {
        private string errorString;
        public Form4(string str)
        {
            InitializeComponent();
            this.errorString = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Closing(object sender, CancelEventArgs e)
        {
            GC.Collect();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(150, 86);
            label1.Text = errorString;
        }
    }
}