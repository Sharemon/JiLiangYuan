namespace DeviceApplication1
{
    partial class LogForm
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
            this.LogList = new System.Windows.Forms.ListBox();
            this.LogContent = new System.Windows.Forms.TextBox();
            this.LogBnt = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogList
            // 
            this.LogList.Location = new System.Drawing.Point(20, 18);
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size(144, 162);
            this.LogList.TabIndex = 0;
            // 
            // LogContent
            // 
            this.LogContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogContent.Location = new System.Drawing.Point(183, 18);
            this.LogContent.Multiline = true;
            this.LogContent.Name = "LogContent";
            this.LogContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogContent.Size = new System.Drawing.Size(277, 204);
            this.LogContent.TabIndex = 1;
            // 
            // LogBnt
            // 
            this.LogBnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LogBnt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.LogBnt.Location = new System.Drawing.Point(20, 194);
            this.LogBnt.Name = "LogBnt";
            this.LogBnt.Size = new System.Drawing.Size(65, 28);
            this.LogBnt.TabIndex = 3;
            this.LogBnt.Text = "导  出";
            this.LogBnt.Click += new System.EventHandler(this.LogBnt_Click);
            // 
            // Return
            // 
            this.Return.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Return.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Return.Location = new System.Drawing.Point(99, 194);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(65, 28);
            this.Return.TabIndex = 3;
            this.Return.Text = "返  回";
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(478, 232);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.LogBnt);
            this.Controls.Add(this.LogContent);
            this.Controls.Add(this.LogList);
            this.Name = "LogForm";
            this.Text = "工作日志";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.TextBox LogContent;
        private System.Windows.Forms.Button LogBnt;
        private System.Windows.Forms.Button Return;
    }
}