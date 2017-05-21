namespace 串口测试程序
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.COM = new System.Windows.Forms.TextBox();
            this.TxtReceive = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtSend = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtCount = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // COM
            // 
            this.COM.Location = new System.Drawing.Point(34, 153);
            this.COM.Margin = new System.Windows.Forms.Padding(2);
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(39, 21);
            this.COM.TabIndex = 0;
            this.COM.Text = "4";
            // 
            // TxtReceive
            // 
            this.TxtReceive.Location = new System.Drawing.Point(34, 41);
            this.TxtReceive.Margin = new System.Windows.Forms.Padding(2);
            this.TxtReceive.Name = "TxtReceive";
            this.TxtReceive.Size = new System.Drawing.Size(169, 21);
            this.TxtReceive.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 141);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtSend
            // 
            this.TxtSend.Location = new System.Drawing.Point(34, 91);
            this.TxtSend.Margin = new System.Windows.Forms.Padding(2);
            this.TxtSend.Name = "TxtSend";
            this.TxtSend.Size = new System.Drawing.Size(169, 21);
            this.TxtSend.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 141);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "end";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtCount
            // 
            this.TxtCount.Location = new System.Drawing.Point(34, 212);
            this.TxtCount.Name = "TxtCount";
            this.TxtCount.Size = new System.Drawing.Size(166, 21);
            this.TxtCount.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 268);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TxtCount);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtSend);
            this.Controls.Add(this.TxtReceive);
            this.Controls.Add(this.COM);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "v";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort sp;
        private System.Windows.Forms.TextBox COM;
        private System.Windows.Forms.TextBox TxtReceive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtSend;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtCount;
        private System.Windows.Forms.TextBox textBox1;
    }
}

