namespace FTPClient.Forms
{
    partial class frmTransfer
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
            this.progressOne = new System.Windows.Forms.ProgressBar();
            this.lbFileName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressAll = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCurrentFile = new System.Windows.Forms.Label();
            this.lbAll = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressOne
            // 
            this.progressOne.Location = new System.Drawing.Point(15, 179);
            this.progressOne.Name = "progressOne";
            this.progressOne.Size = new System.Drawing.Size(451, 27);
            this.progressOne.TabIndex = 0;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(12, 25);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(0, 17);
            this.lbFileName.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progressAll
            // 
            this.progressAll.Location = new System.Drawing.Point(15, 65);
            this.progressAll.Name = "progressAll";
            this.progressAll.Size = new System.Drawing.Size(451, 27);
            this.progressAll.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "所有文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "当前文件";
            // 
            // lbCurrentFile
            // 
            this.lbCurrentFile.AutoSize = true;
            this.lbCurrentFile.Location = new System.Drawing.Point(81, 150);
            this.lbCurrentFile.Name = "lbCurrentFile";
            this.lbCurrentFile.Size = new System.Drawing.Size(0, 17);
            this.lbCurrentFile.TabIndex = 6;
            // 
            // lbAll
            // 
            this.lbAll.AutoSize = true;
            this.lbAll.Location = new System.Drawing.Point(81, 25);
            this.lbAll.Name = "lbAll";
            this.lbAll.Size = new System.Drawing.Size(0, 17);
            this.lbAll.TabIndex = 8;
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 281);
            this.Controls.Add(this.lbAll);
            this.Controls.Add(this.lbCurrentFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.progressOne);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransfer";
            this.Text = "传输";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressOne;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCurrentFile;
        private System.Windows.Forms.Label lbAll;
    }
}