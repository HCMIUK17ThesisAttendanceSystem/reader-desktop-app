
namespace ReadTag
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
            this.TxtTcp = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.GrpSetting = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnClearLog = new System.Windows.Forms.Button();
            this.GrpSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtTcp
            // 
            this.TxtTcp.Location = new System.Drawing.Point(121, 20);
            this.TxtTcp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtTcp.Name = "TxtTcp";
            this.TxtTcp.Size = new System.Drawing.Size(221, 22);
            this.TxtTcp.TabIndex = 0;
            this.TxtTcp.Text = "192.168.1.116:9090";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(352, 17);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(100, 28);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // GrpSetting
            // 
            this.GrpSetting.Controls.Add(this.label1);
            this.GrpSetting.Controls.Add(this.TxtTcp);
            this.GrpSetting.Controls.Add(this.BtnConnect);
            this.GrpSetting.Location = new System.Drawing.Point(16, 15);
            this.GrpSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrpSetting.Name = "GrpSetting";
            this.GrpSetting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GrpSetting.Size = new System.Drawing.Size(480, 63);
            this.GrpSetting.TabIndex = 2;
            this.GrpSetting.TabStop = false;
            this.GrpSetting.Text = "Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "TCP Address:";
            // 
            // TxtLog
            // 
            this.TxtLog.Location = new System.Drawing.Point(16, 110);
            this.TxtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.Size = new System.Drawing.Size(393, 313);
            this.TxtLog.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(419, 110);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(100, 28);
            this.BtnStart.TabIndex = 5;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(420, 394);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(100, 28);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            // 
            // BtnClearLog
            // 
            this.BtnClearLog.Location = new System.Drawing.Point(420, 146);
            this.BtnClearLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnClearLog.Name = "BtnClearLog";
            this.BtnClearLog.Size = new System.Drawing.Size(100, 28);
            this.BtnClearLog.TabIndex = 7;
            this.BtnClearLog.Text = "Clear Log";
            this.BtnClearLog.UseVisualStyleBackColor = true;
            this.BtnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 444);
            this.Controls.Add(this.BtnClearLog);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.GrpSetting);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GrpSetting.ResumeLayout(false);
            this.GrpSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtTcp;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.GroupBox GrpSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnClearLog;
    }
}

