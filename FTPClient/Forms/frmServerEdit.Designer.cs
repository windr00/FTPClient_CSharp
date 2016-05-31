namespace FTPClient.Forms
{
    partial class frmServerEdit
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
            this.lbServerAddr = new System.Windows.Forms.Label();
            this.txtServerAddr = new System.Windows.Forms.TextBox();
            this.lbServerPort = new System.Windows.Forms.Label();
            this.checkAnnoymous = new System.Windows.Forms.CheckBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lbUserPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.MaskedTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lbServerAddr
            // 
            this.lbServerAddr.AutoSize = true;
            this.lbServerAddr.Location = new System.Drawing.Point(22, 29);
            this.lbServerAddr.Name = "lbServerAddr";
            this.lbServerAddr.Size = new System.Drawing.Size(68, 17);
            this.lbServerAddr.TabIndex = 0;
            this.lbServerAddr.Text = "服务器地址";
            // 
            // txtServerAddr
            // 
            this.txtServerAddr.Location = new System.Drawing.Point(167, 29);
            this.txtServerAddr.Name = "txtServerAddr";
            this.txtServerAddr.Size = new System.Drawing.Size(234, 23);
            this.txtServerAddr.TabIndex = 1;
            // 
            // lbServerPort
            // 
            this.lbServerPort.AutoSize = true;
            this.lbServerPort.Location = new System.Drawing.Point(22, 76);
            this.lbServerPort.Name = "lbServerPort";
            this.lbServerPort.Size = new System.Drawing.Size(80, 17);
            this.lbServerPort.TabIndex = 2;
            this.lbServerPort.Text = "服务器端口号";
            // 
            // checkAnnoymous
            // 
            this.checkAnnoymous.AutoSize = true;
            this.checkAnnoymous.Location = new System.Drawing.Point(28, 214);
            this.checkAnnoymous.Name = "checkAnnoymous";
            this.checkAnnoymous.Size = new System.Drawing.Size(99, 21);
            this.checkAnnoymous.TabIndex = 4;
            this.checkAnnoymous.Text = "使用匿名登录";
            this.checkAnnoymous.UseVisualStyleBackColor = true;
            this.checkAnnoymous.CheckedChanged += new System.EventHandler(this.checkAnnoymous_CheckedChanged);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(25, 258);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(44, 17);
            this.lbUserName.TabIndex = 5;
            this.lbUserName.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(167, 255);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(234, 23);
            this.txtUserName.TabIndex = 6;
            // 
            // lbUserPass
            // 
            this.lbUserPass.AutoSize = true;
            this.lbUserPass.Location = new System.Drawing.Point(25, 303);
            this.lbUserPass.Name = "lbUserPass";
            this.lbUserPass.Size = new System.Drawing.Size(32, 17);
            this.lbUserPass.TabIndex = 7;
            this.lbUserPass.Text = "密码";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(167, 300);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(234, 23);
            this.txtPass.TabIndex = 8;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 140);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(405, 51);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 361);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(405, 51);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(281, 76);
            this.numPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 23);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // frmServerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 430);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbUserPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.checkAnnoymous);
            this.Controls.Add(this.lbServerPort);
            this.Controls.Add(this.txtServerAddr);
            this.Controls.Add(this.lbServerAddr);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServerEdit";
            this.Text = "编辑连接设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServerEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbServerAddr;
        private System.Windows.Forms.TextBox txtServerAddr;
        private System.Windows.Forms.Label lbServerPort;
        private System.Windows.Forms.CheckBox checkAnnoymous;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lbUserPass;
        private System.Windows.Forms.MaskedTextBox txtPass;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numPort;
    }
}