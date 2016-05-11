namespace FTPClient
{
    partial class frmServerList
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
            this.listServer = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listServer
            // 
            this.listServer.FormattingEnabled = true;
            this.listServer.ItemHeight = 17;
            this.listServer.Location = new System.Drawing.Point(13, 13);
            this.listServer.Name = "listServer";
            this.listServer.Size = new System.Drawing.Size(414, 276);
            this.listServer.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 306);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(99, 32);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(118, 306);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(99, 32);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(223, 306);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(99, 32);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(328, 306);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(99, 32);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "退出";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // frmSeverList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 351);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.listServer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmSeverList";
            this.Text = "FTP服务器列表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
    }
}