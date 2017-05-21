namespace DeviceApplication1
{
    partial class SetTempForm
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
            this.dot = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.seven = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.TempSet = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Plus10 = new System.Windows.Forms.Button();
            this.Plus5 = new System.Windows.Forms.Button();
            this.Minus5 = new System.Windows.Forms.Button();
            this.Minus10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dot
            // 
            this.dot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dot.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.dot.Location = new System.Drawing.Point(336, 268);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(60, 60);
            this.dot.TabIndex = 29;
            this.dot.Text = ".";
            this.dot.Click += new System.EventHandler(this.dot_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(336, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 60);
            this.button4.TabIndex = 34;
            this.button4.Text = "←";
            this.button4.Click += new System.EventHandler(this.backspace_Click);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.clear.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.clear.Location = new System.Drawing.Point(336, 189);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(60, 60);
            this.clear.TabIndex = 35;
            this.clear.Text = "C";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.minus.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.minus.Location = new System.Drawing.Point(186, 347);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(60, 60);
            this.minus.TabIndex = 36;
            this.minus.Text = "-/+";
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.exit.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.exit.Location = new System.Drawing.Point(336, 347);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(60, 60);
            this.exit.TabIndex = 32;
            this.exit.Text = "返回";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // zero
            // 
            this.zero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.zero.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.zero.Location = new System.Drawing.Point(111, 347);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(60, 60);
            this.zero.TabIndex = 33;
            this.zero.Text = "0";
            this.zero.Click += new System.EventHandler(this.zero_Click);
            // 
            // nine
            // 
            this.nine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nine.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.nine.Location = new System.Drawing.Point(261, 268);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(60, 60);
            this.nine.TabIndex = 40;
            this.nine.Text = "9";
            this.nine.Click += new System.EventHandler(this.nine_Click);
            // 
            // seven
            // 
            this.seven.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.seven.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.seven.Location = new System.Drawing.Point(111, 268);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(60, 60);
            this.seven.TabIndex = 41;
            this.seven.Text = "7";
            this.seven.Click += new System.EventHandler(this.seven_Click);
            // 
            // eight
            // 
            this.eight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.eight.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.eight.Location = new System.Drawing.Point(186, 268);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(60, 60);
            this.eight.TabIndex = 42;
            this.eight.Text = "8";
            this.eight.Click += new System.EventHandler(this.eight_Click);
            // 
            // six
            // 
            this.six.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.six.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.six.Location = new System.Drawing.Point(261, 189);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(60, 60);
            this.six.TabIndex = 37;
            this.six.Text = "6";
            this.six.Click += new System.EventHandler(this.six_Click);
            // 
            // five
            // 
            this.five.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.five.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.five.Location = new System.Drawing.Point(186, 189);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(60, 60);
            this.five.TabIndex = 38;
            this.five.Text = "5";
            this.five.Click += new System.EventHandler(this.five_Click);
            // 
            // three
            // 
            this.three.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.three.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.three.Location = new System.Drawing.Point(261, 110);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(60, 60);
            this.three.TabIndex = 39;
            this.three.Text = "3";
            this.three.Click += new System.EventHandler(this.three_Click);
            // 
            // four
            // 
            this.four.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.four.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.four.Location = new System.Drawing.Point(111, 189);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(60, 60);
            this.four.TabIndex = 28;
            this.four.Text = "4";
            this.four.Click += new System.EventHandler(this.four_Click);
            // 
            // two
            // 
            this.two.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.two.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.two.Location = new System.Drawing.Point(186, 110);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(60, 60);
            this.two.TabIndex = 27;
            this.two.Text = "2";
            this.two.Click += new System.EventHandler(this.two_Click);
            // 
            // one
            // 
            this.one.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.one.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.one.Location = new System.Drawing.Point(111, 110);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(60, 60);
            this.one.TabIndex = 30;
            this.one.Text = "1";
            this.one.Click += new System.EventHandler(this.one_Click);
            // 
            // TempSet
            // 
            this.TempSet.BackColor = System.Drawing.Color.Gainsboro;
            this.TempSet.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.TempSet.ForeColor = System.Drawing.Color.Green;
            this.TempSet.Location = new System.Drawing.Point(214, 41);
            this.TempSet.Name = "TempSet";
            this.TempSet.Size = new System.Drawing.Size(125, 29);
            this.TempSet.TabIndex = 23;
            this.TempSet.GotFocus += new System.EventHandler(this.TempSet_GotFocus);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(261, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 18;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(71, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.Text = "设 定 温 度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Plus10
            // 
            this.Plus10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Plus10.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.Plus10.Location = new System.Drawing.Point(29, 110);
            this.Plus10.Name = "Plus10";
            this.Plus10.Size = new System.Drawing.Size(60, 60);
            this.Plus10.TabIndex = 34;
            this.Plus10.Text = "+10";
            this.Plus10.Click += new System.EventHandler(this.Plus10_Click);
            // 
            // Plus5
            // 
            this.Plus5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Plus5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.Plus5.Location = new System.Drawing.Point(29, 189);
            this.Plus5.Name = "Plus5";
            this.Plus5.Size = new System.Drawing.Size(60, 60);
            this.Plus5.TabIndex = 34;
            this.Plus5.Text = "+5";
            this.Plus5.Click += new System.EventHandler(this.Plus5_Click);
            // 
            // Minus5
            // 
            this.Minus5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Minus5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.Minus5.Location = new System.Drawing.Point(29, 268);
            this.Minus5.Name = "Minus5";
            this.Minus5.Size = new System.Drawing.Size(60, 60);
            this.Minus5.TabIndex = 34;
            this.Minus5.Text = "-5";
            this.Minus5.Click += new System.EventHandler(this.Minus5_Click);
            // 
            // Minus10
            // 
            this.Minus10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Minus10.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.Minus10.Location = new System.Drawing.Point(29, 347);
            this.Minus10.Name = "Minus10";
            this.Minus10.Size = new System.Drawing.Size(60, 60);
            this.Minus10.TabIndex = 34;
            this.Minus10.Text = "-10";
            this.Minus10.Click += new System.EventHandler(this.Minus10_Click);
            // 
            // SetTempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(426, 430);
            this.Controls.Add(this.dot);
            this.Controls.Add(this.Minus10);
            this.Controls.Add(this.Minus5);
            this.Controls.Add(this.Plus5);
            this.Controls.Add(this.Plus10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.zero);
            this.Controls.Add(this.nine);
            this.Controls.Add(this.seven);
            this.Controls.Add(this.eight);
            this.Controls.Add(this.six);
            this.Controls.Add(this.five);
            this.Controls.Add(this.three);
            this.Controls.Add(this.four);
            this.Controls.Add(this.two);
            this.Controls.Add(this.one);
            this.Controls.Add(this.TempSet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "SetTempForm";
            this.Text = "温度设定";
            this.Load += new System.EventHandler(this.SetTempForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SetTempForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dot;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.TextBox TempSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Plus10;
        private System.Windows.Forms.Button Plus5;
        private System.Windows.Forms.Button Minus5;
        private System.Windows.Forms.Button Minus10;
    }
}