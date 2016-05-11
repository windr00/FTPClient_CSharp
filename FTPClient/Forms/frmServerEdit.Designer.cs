namespace FTPClient
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
            this.domPort = new System.Windows.Forms.DomainUpDown();
            this.checkAnnoymous = new System.Windows.Forms.CheckBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lbUserPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.MaskedTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
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
            this.txtServerAddr.Location = new System.Drawing.Point(150, 29);
            this.txtServerAddr.Name = "txtServerAddr";
            this.txtServerAddr.Size = new System.Drawing.Size(108, 23);
            this.txtServerAddr.TabIndex = 1;
            // 
            // lbServerPort
            // 
            this.lbServerPort.AutoSize = true;
            this.lbServerPort.Location = new System.Drawing.Point(22, 67);
            this.lbServerPort.Name = "lbServerPort";
            this.lbServerPort.Size = new System.Drawing.Size(80, 17);
            this.lbServerPort.TabIndex = 2;
            this.lbServerPort.Text = "服务器端口号";
            // 
            // domPort
            // 
            this.domPort.Location = new System.Drawing.Point(150, 67);
            this.domPort.Name = "domPort";
            this.domPort.Size = new System.Drawing.Size(108, 23);
            this.domPort.TabIndex = 3;
            // 
            // checkAnnoymous
            // 
            this.checkAnnoymous.AutoSize = true;
            this.checkAnnoymous.Location = new System.Drawing.Point(25, 107);
            this.checkAnnoymous.Name = "checkAnnoymous";
            this.checkAnnoymous.Size = new System.Drawing.Size(99, 21);
            this.checkAnnoymous.TabIndex = 4;
            this.checkAnnoymous.Text = "使用匿名登录";
            this.checkAnnoymous.UseVisualStyleBackColor = true;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(22, 150);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(44, 17);
            this.lbUserName.TabIndex = 5;
            this.lbUserName.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(150, 147);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(108, 23);
            this.txtUserName.TabIndex = 6;
            // 
            // lbUserPass
            // 
            this.lbUserPass.AutoSize = true;
            this.lbUserPass.Location = new System.Drawing.Point(22, 188);
            this.lbUserPass.Name = "lbUserPass";
            this.lbUserPass.Size = new System.Drawing.Size(32, 17);
            this.lbUserPass.TabIndex = 7;
            this.lbUserPass.Text = "密码";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(150, 188);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(108, 23);
            this.txtPass.TabIndex = 8;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 235);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(266, 24);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(266, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmServerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 298);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lbUserPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.checkAnnoymous);
            this.Controls.Add(this.domPort);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbServerAddr;
        private System.Windows.Forms.TextBox txtServerAddr;
        private System.Windows.Forms.Label lbServerPort;
        private System.Windows.Forms.DomainUpDown domPort;
        private System.Windows.Forms.CheckBox checkAnnoymous;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lbUserPass;
        private System.Windows.Forms.MaskedTextBox txtPass;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnOK;
    }
}