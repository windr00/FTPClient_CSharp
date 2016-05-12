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
            this.treeRemoteDir = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lbCurDir = new System.Windows.Forms.Label();
            this.txtCurDir = new System.Windows.Forms.TextBox();
            this.lbRemoteTree = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeRemoteDir
            // 
            this.treeRemoteDir.Location = new System.Drawing.Point(12, 62);
            this.treeRemoteDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeRemoteDir.Name = "treeRemoteDir";
            this.treeRemoteDir.Size = new System.Drawing.Size(299, 609);
            this.treeRemoteDir.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(335, 76);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(928, 595);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lbCurDir
            // 
            this.lbCurDir.AutoSize = true;
            this.lbCurDir.Location = new System.Drawing.Point(353, 20);
            this.lbCurDir.Name = "lbCurDir";
            this.lbCurDir.Size = new System.Drawing.Size(80, 17);
            this.lbCurDir.TabIndex = 2;
            this.lbCurDir.Text = "当前文件夹：";
            // 
            // txtCurDir
            // 
            this.txtCurDir.Location = new System.Drawing.Point(517, 17);
            this.txtCurDir.Name = "txtCurDir";
            this.txtCurDir.ReadOnly = true;
            this.txtCurDir.Size = new System.Drawing.Size(746, 23);
            this.txtCurDir.TabIndex = 3;
            // 
            // lbRemoteTree
            // 
            this.lbRemoteTree.AutoSize = true;
            this.lbRemoteTree.Location = new System.Drawing.Point(14, 20);
            this.lbRemoteTree.Name = "lbRemoteTree";
            this.lbRemoteTree.Size = new System.Drawing.Size(80, 17);
            this.lbRemoteTree.TabIndex = 4;
            this.lbRemoteTree.Text = "远程目录层次";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 702);
            this.Controls.Add(this.lbRemoteTree);
            this.Controls.Add(this.txtCurDir);
            this.Controls.Add(this.lbCurDir);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeRemoteDir);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeRemoteDir;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lbCurDir;
        private System.Windows.Forms.TextBox txtCurDir;
        private System.Windows.Forms.Label lbRemoteTree;
    }
}

