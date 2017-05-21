using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeviceApplication1
{
    public partial class LogForm : Form
    {
        private string logPath = "\\SDMEM\\Operating\\";


        public LogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 把文件名转化成时间格式
        /// </summary>
        /// <param name="file">文件名</param>
        /// <returns>时间格式的字符串</returns>
        string ToTime(string file)
        {
            file = file.Insert(12, ":");
            file = file.Insert(10, ":");
            file = file.Insert(8, " ");
            file = file.Insert(6, "/");
            file = file.Insert(2, "/");

            return file;
        }

        /// <summary>
        /// 把时间字符串转化为文件名
        /// </summary>
        /// <param name="time">时间字符串</param>
        /// <returns>文件名</returns>
        string ToFilename(string time)
        {
            time = time.Replace(":", "");
            time = time.Replace(" ", "");
            time = time.Replace("/", "");

            return time;

        }


        private void LogForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(150, 0);
            string[] files = Directory.GetFiles(logPath);
            string timeStr;
            foreach (string file in files)
            {
                timeStr = ToTime(Path.GetFileNameWithoutExtension(file));
                LogList.Items.Add(timeStr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogBnt_Click(object sender, EventArgs e)
        {
            string filename = ToFilename((string)LogList.SelectedItem);
            filename = logPath + filename + ".txt";

            StreamReader sw = new StreamReader(filename);

            LogContent.Text = sw.ReadToEnd();

            sw.Close();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}