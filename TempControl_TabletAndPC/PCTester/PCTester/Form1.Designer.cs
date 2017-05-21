namespace PCTester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCurTemp = new System.Windows.Forms.TextBox();
            this.txtCurPower = new System.Windows.Forms.TextBox();
            this.txtFluct = new System.Windows.Forms.TextBox();
            this.txtTempSet = new System.Windows.Forms.TextBox();
            this.txtTempMod = new System.Windows.Forms.TextBox();
            this.txtForword = new System.Windows.Forms.TextBox();
            this.txtFuzzy = new System.Windows.Forms.TextBox();
            this.txtProp = new System.Windows.Forms.TextBox();
            this.txtInteg = new System.Windows.Forms.TextBox();
            this.txtPwrCo = new System.Windows.Forms.TextBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.bntReadCurTemp = new System.Windows.Forms.Button();
            this.bntWriteCurTemp = new System.Windows.Forms.Button();
            this.bntReadCurPower = new System.Windows.Forms.Button();
            this.bntReadFluct = new System.Windows.Forms.Button();
            this.bntReadTempSet = new System.Windows.Forms.Button();
            this.bntReadTempMod = new System.Windows.Forms.Button();
            this.bntReadForword = new System.Windows.Forms.Button();
            this.bntReadFuzzy = new System.Windows.Forms.Button();
            this.bntReadProp = new System.Windows.Forms.Button();
            this.bntReadInteg = new System.Windows.Forms.Button();
            this.bntReadPwrCo = new System.Windows.Forms.Button();
            this.bntWriteCurPower = new System.Windows.Forms.Button();
            this.bntWriteFluct = new System.Windows.Forms.Button();
            this.bntWriteTempSet = new System.Windows.Forms.Button();
            this.bntWriteTempMod = new System.Windows.Forms.Button();
            this.bntWriteForword = new System.Windows.Forms.Button();
            this.bntWriteFuzzy = new System.Windows.Forms.Button();
            this.bntWriteProp = new System.Windows.Forms.Button();
            this.bntWriteInteg = new System.Windows.Forms.Button();
            this.bntWritePwrCo = new System.Windows.Forms.Button();
            this.bntCheckLink = new System.Windows.Forms.Button();
            this.BntExit = new System.Windows.Forms.Button();
            this.chbLinked = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前温度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前功率:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "串口号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "10min波动度:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "温度设定值:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "温度调整值:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "超前调整值:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "模糊系数:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "比例系数:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "积分系数:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "功率系数:";
            // 
            // txtCurTemp
            // 
            this.txtCurTemp.Location = new System.Drawing.Point(107, 46);
            this.txtCurTemp.Name = "txtCurTemp";
            this.txtCurTemp.Size = new System.Drawing.Size(100, 21);
            this.txtCurTemp.TabIndex = 1;
            // 
            // txtCurPower
            // 
            this.txtCurPower.Location = new System.Drawing.Point(107, 76);
            this.txtCurPower.Name = "txtCurPower";
            this.txtCurPower.Size = new System.Drawing.Size(100, 21);
            this.txtCurPower.TabIndex = 1;
            // 
            // txtFluct
            // 
            this.txtFluct.Location = new System.Drawing.Point(107, 106);
            this.txtFluct.Name = "txtFluct";
            this.txtFluct.Size = new System.Drawing.Size(100, 21);
            this.txtFluct.TabIndex = 1;
            // 
            // txtTempSet
            // 
            this.txtTempSet.Location = new System.Drawing.Point(107, 136);
            this.txtTempSet.Name = "txtTempSet";
            this.txtTempSet.Size = new System.Drawing.Size(100, 21);
            this.txtTempSet.TabIndex = 1;
            // 
            // txtTempMod
            // 
            this.txtTempMod.Location = new System.Drawing.Point(107, 166);
            this.txtTempMod.Name = "txtTempMod";
            this.txtTempMod.Size = new System.Drawing.Size(100, 21);
            this.txtTempMod.TabIndex = 1;
            // 
            // txtForword
            // 
            this.txtForword.Location = new System.Drawing.Point(107, 196);
            this.txtForword.Name = "txtForword";
            this.txtForword.Size = new System.Drawing.Size(100, 21);
            this.txtForword.TabIndex = 1;
            // 
            // txtFuzzy
            // 
            this.txtFuzzy.Location = new System.Drawing.Point(107, 226);
            this.txtFuzzy.Name = "txtFuzzy";
            this.txtFuzzy.Size = new System.Drawing.Size(100, 21);
            this.txtFuzzy.TabIndex = 1;
            // 
            // txtProp
            // 
            this.txtProp.Location = new System.Drawing.Point(107, 256);
            this.txtProp.Name = "txtProp";
            this.txtProp.Size = new System.Drawing.Size(100, 21);
            this.txtProp.TabIndex = 1;
            // 
            // txtInteg
            // 
            this.txtInteg.Location = new System.Drawing.Point(107, 286);
            this.txtInteg.Name = "txtInteg";
            this.txtInteg.Size = new System.Drawing.Size(100, 21);
            this.txtInteg.TabIndex = 1;
            // 
            // txtPwrCo
            // 
            this.txtPwrCo.Location = new System.Drawing.Point(107, 316);
            this.txtPwrCo.Name = "txtPwrCo";
            this.txtPwrCo.Size = new System.Drawing.Size(100, 21);
            this.txtPwrCo.TabIndex = 1;
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(107, 17);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(100, 20);
            this.cmbComPort.TabIndex = 2;
            // 
            // bntReadCurTemp
            // 
            this.bntReadCurTemp.Location = new System.Drawing.Point(224, 45);
            this.bntReadCurTemp.Name = "bntReadCurTemp";
            this.bntReadCurTemp.Size = new System.Drawing.Size(43, 23);
            this.bntReadCurTemp.TabIndex = 3;
            this.bntReadCurTemp.Text = "查询";
            this.bntReadCurTemp.UseVisualStyleBackColor = true;
            this.bntReadCurTemp.Click += new System.EventHandler(this.bntReadCurTemp_Click);
            // 
            // bntWriteCurTemp
            // 
            this.bntWriteCurTemp.Enabled = false;
            this.bntWriteCurTemp.Location = new System.Drawing.Point(273, 45);
            this.bntWriteCurTemp.Name = "bntWriteCurTemp";
            this.bntWriteCurTemp.Size = new System.Drawing.Size(43, 23);
            this.bntWriteCurTemp.TabIndex = 3;
            this.bntWriteCurTemp.Text = "设置";
            this.bntWriteCurTemp.UseVisualStyleBackColor = true;
            // 
            // bntReadCurPower
            // 
            this.bntReadCurPower.Location = new System.Drawing.Point(224, 75);
            this.bntReadCurPower.Name = "bntReadCurPower";
            this.bntReadCurPower.Size = new System.Drawing.Size(43, 23);
            this.bntReadCurPower.TabIndex = 3;
            this.bntReadCurPower.Text = "查询";
            this.bntReadCurPower.UseVisualStyleBackColor = true;
            this.bntReadCurPower.Click += new System.EventHandler(this.bntReadCurPower_Click);
            // 
            // bntReadFluct
            // 
            this.bntReadFluct.Location = new System.Drawing.Point(224, 105);
            this.bntReadFluct.Name = "bntReadFluct";
            this.bntReadFluct.Size = new System.Drawing.Size(43, 23);
            this.bntReadFluct.TabIndex = 3;
            this.bntReadFluct.Text = "查询";
            this.bntReadFluct.UseVisualStyleBackColor = true;
            this.bntReadFluct.Click += new System.EventHandler(this.bntReadFluct_Click);
            // 
            // bntReadTempSet
            // 
            this.bntReadTempSet.Location = new System.Drawing.Point(224, 135);
            this.bntReadTempSet.Name = "bntReadTempSet";
            this.bntReadTempSet.Size = new System.Drawing.Size(43, 23);
            this.bntReadTempSet.TabIndex = 3;
            this.bntReadTempSet.Text = "查询";
            this.bntReadTempSet.UseVisualStyleBackColor = true;
            this.bntReadTempSet.Click += new System.EventHandler(this.bntReadTempSet_Click);
            // 
            // bntReadTempMod
            // 
            this.bntReadTempMod.Location = new System.Drawing.Point(224, 165);
            this.bntReadTempMod.Name = "bntReadTempMod";
            this.bntReadTempMod.Size = new System.Drawing.Size(43, 23);
            this.bntReadTempMod.TabIndex = 3;
            this.bntReadTempMod.Text = "查询";
            this.bntReadTempMod.UseVisualStyleBackColor = true;
            this.bntReadTempMod.Click += new System.EventHandler(this.bntReadTempMod_Click);
            // 
            // bntReadForword
            // 
            this.bntReadForword.Location = new System.Drawing.Point(224, 195);
            this.bntReadForword.Name = "bntReadForword";
            this.bntReadForword.Size = new System.Drawing.Size(43, 23);
            this.bntReadForword.TabIndex = 3;
            this.bntReadForword.Text = "查询";
            this.bntReadForword.UseVisualStyleBackColor = true;
            this.bntReadForword.Click += new System.EventHandler(this.bntReadForword_Click);
            // 
            // bntReadFuzzy
            // 
            this.bntReadFuzzy.Location = new System.Drawing.Point(224, 225);
            this.bntReadFuzzy.Name = "bntReadFuzzy";
            this.bntReadFuzzy.Size = new System.Drawing.Size(43, 23);
            this.bntReadFuzzy.TabIndex = 3;
            this.bntReadFuzzy.Text = "查询";
            this.bntReadFuzzy.UseVisualStyleBackColor = true;
            this.bntReadFuzzy.Click += new System.EventHandler(this.bntReadFuzzy_Click);
            // 
            // bntReadProp
            // 
            this.bntReadProp.Location = new System.Drawing.Point(224, 255);
            this.bntReadProp.Name = "bntReadProp";
            this.bntReadProp.Size = new System.Drawing.Size(43, 23);
            this.bntReadProp.TabIndex = 3;
            this.bntReadProp.Text = "查询";
            this.bntReadProp.UseVisualStyleBackColor = true;
            this.bntReadProp.Click += new System.EventHandler(this.bntReadProp_Click);
            // 
            // bntReadInteg
            // 
            this.bntReadInteg.Location = new System.Drawing.Point(224, 285);
            this.bntReadInteg.Name = "bntReadInteg";
            this.bntReadInteg.Size = new System.Drawing.Size(43, 23);
            this.bntReadInteg.TabIndex = 3;
            this.bntReadInteg.Text = "查询";
            this.bntReadInteg.UseVisualStyleBackColor = true;
            this.bntReadInteg.Click += new System.EventHandler(this.bntReadInteg_Click);
            // 
            // bntReadPwrCo
            // 
            this.bntReadPwrCo.Location = new System.Drawing.Point(224, 315);
            this.bntReadPwrCo.Name = "bntReadPwrCo";
            this.bntReadPwrCo.Size = new System.Drawing.Size(43, 23);
            this.bntReadPwrCo.TabIndex = 3;
            this.bntReadPwrCo.Text = "查询";
            this.bntReadPwrCo.UseVisualStyleBackColor = true;
            this.bntReadPwrCo.Click += new System.EventHandler(this.bntReadPwrCo_Click);
            // 
            // bntWriteCurPower
            // 
            this.bntWriteCurPower.Enabled = false;
            this.bntWriteCurPower.Location = new System.Drawing.Point(273, 75);
            this.bntWriteCurPower.Name = "bntWriteCurPower";
            this.bntWriteCurPower.Size = new System.Drawing.Size(43, 23);
            this.bntWriteCurPower.TabIndex = 3;
            this.bntWriteCurPower.Text = "设置";
            this.bntWriteCurPower.UseVisualStyleBackColor = true;
            // 
            // bntWriteFluct
            // 
            this.bntWriteFluct.Enabled = false;
            this.bntWriteFluct.Location = new System.Drawing.Point(273, 105);
            this.bntWriteFluct.Name = "bntWriteFluct";
            this.bntWriteFluct.Size = new System.Drawing.Size(43, 23);
            this.bntWriteFluct.TabIndex = 3;
            this.bntWriteFluct.Text = "设置";
            this.bntWriteFluct.UseVisualStyleBackColor = true;
            // 
            // bntWriteTempSet
            // 
            this.bntWriteTempSet.Location = new System.Drawing.Point(273, 135);
            this.bntWriteTempSet.Name = "bntWriteTempSet";
            this.bntWriteTempSet.Size = new System.Drawing.Size(43, 23);
            this.bntWriteTempSet.TabIndex = 3;
            this.bntWriteTempSet.Text = "设置";
            this.bntWriteTempSet.UseVisualStyleBackColor = true;
            this.bntWriteTempSet.Click += new System.EventHandler(this.bntWriteTempSet_Click);
            // 
            // bntWriteTempMod
            // 
            this.bntWriteTempMod.Location = new System.Drawing.Point(273, 165);
            this.bntWriteTempMod.Name = "bntWriteTempMod";
            this.bntWriteTempMod.Size = new System.Drawing.Size(43, 23);
            this.bntWriteTempMod.TabIndex = 3;
            this.bntWriteTempMod.Text = "设置";
            this.bntWriteTempMod.UseVisualStyleBackColor = true;
            this.bntWriteTempMod.Click += new System.EventHandler(this.bntWriteTempMod_Click);
            // 
            // bntWriteForword
            // 
            this.bntWriteForword.Location = new System.Drawing.Point(273, 195);
            this.bntWriteForword.Name = "bntWriteForword";
            this.bntWriteForword.Size = new System.Drawing.Size(43, 23);
            this.bntWriteForword.TabIndex = 3;
            this.bntWriteForword.Text = "设置";
            this.bntWriteForword.UseVisualStyleBackColor = true;
            this.bntWriteForword.Click += new System.EventHandler(this.bntWriteForword_Click);
            // 
            // bntWriteFuzzy
            // 
            this.bntWriteFuzzy.Location = new System.Drawing.Point(273, 225);
            this.bntWriteFuzzy.Name = "bntWriteFuzzy";
            this.bntWriteFuzzy.Size = new System.Drawing.Size(43, 23);
            this.bntWriteFuzzy.TabIndex = 3;
            this.bntWriteFuzzy.Text = "设置";
            this.bntWriteFuzzy.UseVisualStyleBackColor = true;
            this.bntWriteFuzzy.Click += new System.EventHandler(this.bntWriteFuzzy_Click);
            // 
            // bntWriteProp
            // 
            this.bntWriteProp.Location = new System.Drawing.Point(273, 255);
            this.bntWriteProp.Name = "bntWriteProp";
            this.bntWriteProp.Size = new System.Drawing.Size(43, 23);
            this.bntWriteProp.TabIndex = 3;
            this.bntWriteProp.Text = "设置";
            this.bntWriteProp.UseVisualStyleBackColor = true;
            this.bntWriteProp.Click += new System.EventHandler(this.bntWriteProp_Click);
            // 
            // bntWriteInteg
            // 
            this.bntWriteInteg.Location = new System.Drawing.Point(273, 285);
            this.bntWriteInteg.Name = "bntWriteInteg";
            this.bntWriteInteg.Size = new System.Drawing.Size(43, 23);
            this.bntWriteInteg.TabIndex = 3;
            this.bntWriteInteg.Text = "设置";
            this.bntWriteInteg.UseVisualStyleBackColor = true;
            this.bntWriteInteg.Click += new System.EventHandler(this.bntWriteInteg_Click);
            // 
            // bntWritePwrCo
            // 
            this.bntWritePwrCo.Location = new System.Drawing.Point(273, 315);
            this.bntWritePwrCo.Name = "bntWritePwrCo";
            this.bntWritePwrCo.Size = new System.Drawing.Size(43, 23);
            this.bntWritePwrCo.TabIndex = 3;
            this.bntWritePwrCo.Text = "设置";
            this.bntWritePwrCo.UseVisualStyleBackColor = true;
            this.bntWritePwrCo.Click += new System.EventHandler(this.bntWritePwrCo_Click);
            // 
            // bntCheckLink
            // 
            this.bntCheckLink.Location = new System.Drawing.Point(164, 348);
            this.bntCheckLink.Name = "bntCheckLink";
            this.bntCheckLink.Size = new System.Drawing.Size(71, 23);
            this.bntCheckLink.TabIndex = 4;
            this.bntCheckLink.Text = "连接状态";
            this.bntCheckLink.UseVisualStyleBackColor = true;
            this.bntCheckLink.Click += new System.EventHandler(this.bntCheckLink_Click);
            // 
            // BntExit
            // 
            this.BntExit.Location = new System.Drawing.Point(241, 348);
            this.BntExit.Name = "BntExit";
            this.BntExit.Size = new System.Drawing.Size(75, 23);
            this.BntExit.TabIndex = 4;
            this.BntExit.Text = "退出连接";
            this.BntExit.UseVisualStyleBackColor = true;
            this.BntExit.Click += new System.EventHandler(this.BntExit_Click);
            // 
            // chbLinked
            // 
            this.chbLinked.AutoSize = true;
            this.chbLinked.Location = new System.Drawing.Point(107, 353);
            this.chbLinked.Name = "chbLinked";
            this.chbLinked.Size = new System.Drawing.Size(15, 14);
            this.chbLinked.TabIndex = 5;
            this.chbLinked.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "连接状态:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 386);
            this.Controls.Add(this.chbLinked);
            this.Controls.Add(this.BntExit);
            this.Controls.Add(this.bntCheckLink);
            this.Controls.Add(this.bntWritePwrCo);
            this.Controls.Add(this.bntWriteInteg);
            this.Controls.Add(this.bntWriteProp);
            this.Controls.Add(this.bntWriteFuzzy);
            this.Controls.Add(this.bntWriteForword);
            this.Controls.Add(this.bntWriteTempMod);
            this.Controls.Add(this.bntWriteTempSet);
            this.Controls.Add(this.bntWriteFluct);
            this.Controls.Add(this.bntWriteCurPower);
            this.Controls.Add(this.bntWriteCurTemp);
            this.Controls.Add(this.bntReadPwrCo);
            this.Controls.Add(this.bntReadInteg);
            this.Controls.Add(this.bntReadProp);
            this.Controls.Add(this.bntReadFuzzy);
            this.Controls.Add(this.bntReadForword);
            this.Controls.Add(this.bntReadTempMod);
            this.Controls.Add(this.bntReadTempSet);
            this.Controls.Add(this.bntReadFluct);
            this.Controls.Add(this.bntReadCurPower);
            this.Controls.Add(this.bntReadCurTemp);
            this.Controls.Add(this.cmbComPort);
            this.Controls.Add(this.txtPwrCo);
            this.Controls.Add(this.txtInteg);
            this.Controls.Add(this.txtProp);
            this.Controls.Add(this.txtFuzzy);
            this.Controls.Add(this.txtForword);
            this.Controls.Add(this.txtTempMod);
            this.Controls.Add(this.txtTempSet);
            this.Controls.Add(this.txtFluct);
            this.Controls.Add(this.txtCurPower);
            this.Controls.Add(this.txtCurTemp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "PC端测试程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCurTemp;
        private System.Windows.Forms.TextBox txtCurPower;
        private System.Windows.Forms.TextBox txtFluct;
        private System.Windows.Forms.TextBox txtTempSet;
        private System.Windows.Forms.TextBox txtTempMod;
        private System.Windows.Forms.TextBox txtForword;
        private System.Windows.Forms.TextBox txtFuzzy;
        private System.Windows.Forms.TextBox txtProp;
        private System.Windows.Forms.TextBox txtInteg;
        private System.Windows.Forms.TextBox txtPwrCo;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Button bntReadCurTemp;
        private System.Windows.Forms.Button bntWriteCurTemp;
        private System.Windows.Forms.Button bntReadCurPower;
        private System.Windows.Forms.Button bntReadFluct;
        private System.Windows.Forms.Button bntReadTempSet;
        private System.Windows.Forms.Button bntReadTempMod;
        private System.Windows.Forms.Button bntReadForword;
        private System.Windows.Forms.Button bntReadFuzzy;
        private System.Windows.Forms.Button bntReadProp;
        private System.Windows.Forms.Button bntReadInteg;
        private System.Windows.Forms.Button bntReadPwrCo;
        private System.Windows.Forms.Button bntWriteCurPower;
        private System.Windows.Forms.Button bntWriteFluct;
        private System.Windows.Forms.Button bntWriteTempSet;
        private System.Windows.Forms.Button bntWriteTempMod;
        private System.Windows.Forms.Button bntWriteForword;
        private System.Windows.Forms.Button bntWriteFuzzy;
        private System.Windows.Forms.Button bntWriteProp;
        private System.Windows.Forms.Button bntWriteInteg;
        private System.Windows.Forms.Button bntWritePwrCo;
        private System.Windows.Forms.Button bntCheckLink;
        private System.Windows.Forms.Button BntExit;
        private System.Windows.Forms.CheckBox chbLinked;
        private System.Windows.Forms.Label label12;
    }
}

