namespace IWellSchedule
{
    partial class MainPanel
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动调度器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停调度器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止调度器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重置软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.时间片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入DLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加DLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.生成配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改时间片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.作废记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.导入DLLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动调度器ToolStripMenuItem,
            this.暂停调度器ToolStripMenuItem,
            this.停止调度器ToolStripMenuItem,
            this.重置软件ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 启动调度器ToolStripMenuItem
            // 
            this.启动调度器ToolStripMenuItem.Name = "启动调度器ToolStripMenuItem";
            this.启动调度器ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.启动调度器ToolStripMenuItem.Text = "启动调度器";
            this.启动调度器ToolStripMenuItem.Click += new System.EventHandler(this.启动调度器ToolStripMenuItem_Click);
            // 
            // 暂停调度器ToolStripMenuItem
            // 
            this.暂停调度器ToolStripMenuItem.Enabled = false;
            this.暂停调度器ToolStripMenuItem.Name = "暂停调度器ToolStripMenuItem";
            this.暂停调度器ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.暂停调度器ToolStripMenuItem.Text = "暂停调度器";
            this.暂停调度器ToolStripMenuItem.Click += new System.EventHandler(this.暂停调度器ToolStripMenuItem_Click);
            // 
            // 停止调度器ToolStripMenuItem
            // 
            this.停止调度器ToolStripMenuItem.Enabled = false;
            this.停止调度器ToolStripMenuItem.Name = "停止调度器ToolStripMenuItem";
            this.停止调度器ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.停止调度器ToolStripMenuItem.Text = "停止调度器";
            this.停止调度器ToolStripMenuItem.Click += new System.EventHandler(this.停止调度器ToolStripMenuItem_Click);
            // 
            // 重置软件ToolStripMenuItem
            // 
            this.重置软件ToolStripMenuItem.Name = "重置软件ToolStripMenuItem";
            this.重置软件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.重置软件ToolStripMenuItem.Text = "重置软件";
            this.重置软件ToolStripMenuItem.Click += new System.EventHandler(this.重置软件ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.时间片ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 时间片ToolStripMenuItem
            // 
            this.时间片ToolStripMenuItem.Name = "时间片ToolStripMenuItem";
            this.时间片ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.时间片ToolStripMenuItem.Text = "时间片";
            this.时间片ToolStripMenuItem.Click += new System.EventHandler(this.时间片ToolStripMenuItem_Click);
            // 
            // 导入DLLToolStripMenuItem
            // 
            this.导入DLLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加DLLToolStripMenuItem});
            this.导入DLLToolStripMenuItem.Name = "导入DLLToolStripMenuItem";
            this.导入DLLToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.导入DLLToolStripMenuItem.Text = "任务";
            // 
            // 增加DLLToolStripMenuItem
            // 
            this.增加DLLToolStripMenuItem.Name = "增加DLLToolStripMenuItem";
            this.增加DLLToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.增加DLLToolStripMenuItem.Text = "增加DLL";
            this.增加DLLToolStripMenuItem.Click += new System.EventHandler(this.增加DLLToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(783, 368);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成配置文件ToolStripMenuItem,
            this.修改时间片ToolStripMenuItem,
            this.删除记录ToolStripMenuItem,
            this.作废记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // 生成配置文件ToolStripMenuItem
            // 
            this.生成配置文件ToolStripMenuItem.Name = "生成配置文件ToolStripMenuItem";
            this.生成配置文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.生成配置文件ToolStripMenuItem.Text = "生成配置文件";
            this.生成配置文件ToolStripMenuItem.Click += new System.EventHandler(this.生成配置文件ToolStripMenuItem_Click);
            // 
            // 修改时间片ToolStripMenuItem
            // 
            this.修改时间片ToolStripMenuItem.Name = "修改时间片ToolStripMenuItem";
            this.修改时间片ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改时间片ToolStripMenuItem.Text = "修改时间片";
            this.修改时间片ToolStripMenuItem.Click += new System.EventHandler(this.修改时间片ToolStripMenuItem_Click);
            // 
            // 删除记录ToolStripMenuItem
            // 
            this.删除记录ToolStripMenuItem.Name = "删除记录ToolStripMenuItem";
            this.删除记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除记录ToolStripMenuItem.Text = "删除记录";
            this.删除记录ToolStripMenuItem.Click += new System.EventHandler(this.删除记录ToolStripMenuItem_Click_1);
            // 
            // 作废记录ToolStripMenuItem
            // 
            this.作废记录ToolStripMenuItem.Name = "作废记录ToolStripMenuItem";
            this.作废记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.作废记录ToolStripMenuItem.Text = "作废/恢复";
            this.作废记录ToolStripMenuItem.Click += new System.EventHandler(this.作废记录ToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 393);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainPanel";
            this.Text = "简惠任务调度管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动调度器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停调度器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止调度器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入DLLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加DLLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 时间片ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改时间片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 作废记录ToolStripMenuItem;

    }
}

