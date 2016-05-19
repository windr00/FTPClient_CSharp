namespace FTPClient
{
    partial class frmMain
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
            this.lsFiles = new System.Windows.Forms.ListView();
            this.lbCurDir = new System.Windows.Forms.Label();
            this.txtCurDir = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsFiles
            // 
            this.lsFiles.AllowDrop = true;
            this.lsFiles.Location = new System.Drawing.Point(12, 52);
            this.lsFiles.Name = "lsFiles";
            this.lsFiles.Size = new System.Drawing.Size(928, 628);
            this.lsFiles.TabIndex = 1;
            this.lsFiles.UseCompatibleStateImageBehavior = false;
            this.lsFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lsFiles_ItemDrag);
            this.lsFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsFiles_DragDrop);
            this.lsFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsFiles_DragEnter);
            this.lsFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.lsFiles_DragOver);
            this.lsFiles.DragLeave += new System.EventHandler(this.lsFiles_DragLeave);
            this.lsFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsFiles_MouseDoubleClick);
            // 
            // lbCurDir
            // 
            this.lbCurDir.AutoSize = true;
            this.lbCurDir.Location = new System.Drawing.Point(100, 26);
            this.lbCurDir.Name = "lbCurDir";
            this.lbCurDir.Size = new System.Drawing.Size(52, 17);
            this.lbCurDir.TabIndex = 2;
            this.lbCurDir.Text = "CurDir :";
            // 
            // txtCurDir
            // 
            this.txtCurDir.Location = new System.Drawing.Point(151, 23);
            this.txtCurDir.Name = "txtCurDir";
            this.txtCurDir.ReadOnly = true;
            this.txtCurDir.Size = new System.Drawing.Size(712, 23);
            this.txtCurDir.TabIndex = 3;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(12, 23);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(35, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "←";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(53, 23);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(35, 23);
            this.btnRedo.TabIndex = 5;
            this.btnRedo.Text = "→";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(869, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 692);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.txtCurDir);
            this.Controls.Add(this.lbCurDir);
            this.Controls.Add(this.lsFiles);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Shown += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lsFiles;
        private System.Windows.Forms.Label lbCurDir;
        private System.Windows.Forms.TextBox txtCurDir;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnRefresh;
    }
}

