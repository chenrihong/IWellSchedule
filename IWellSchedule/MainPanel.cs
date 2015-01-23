using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IWellSchedule
{
    public partial class MainPanel : Form
    {

        /// <summary>
        /// 调度管理器
        /// </summary>
        private QuartzServer quartz_server { get; set; }


        public MainPanel()
        {
            InitializeComponent();

            // 初始调度服务
            quartz_server = new QuartzServer();
            quartz_server.Initialize();

            // 初始数据库
            new SQLiteDbInitialize().InitTable();

            reloadDataGridView();
        }

        private void reloadDataGridView()
        {
            var dt = new QuartzJobs().GetDataTable();
            this.dataGridView1.DataSource = dt;
        }


        private void 时间片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("QuartzCronGenerator.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("找不到QuartzCronGenerator.exe文件");
            }

        }

        private void 启动调度器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quartz_server.Start();

            this.启动调度器ToolStripMenuItem.Enabled = false;
            this.停止调度器ToolStripMenuItem.Enabled = true;
            this.暂停调度器ToolStripMenuItem.Enabled = true;

            MessageBox.Show("调度系统启动成功", "提示");
        }



        private void 暂停调度器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var txt = this.暂停调度器ToolStripMenuItem.Text;

            if (txt == "暂停调度器")
            {
                quartz_server.Pause();
                this.暂停调度器ToolStripMenuItem.Text = "恢复调度器";
            }
            if (txt == "恢复调度器")
            {
                quartz_server.Resume();
                this.暂停调度器ToolStripMenuItem.Text = "暂停调度器";
            }

        }

        private void 停止调度器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quartz_server.Stop();
            this.Close();
        }

        private void 增加DLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DllFile().AddFile();
            reloadDataGridView();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);

                    bool isStart = !this.启动调度器ToolStripMenuItem.Enabled;

                    if (isStart)
                    {
                        this.删除记录ToolStripMenuItem.Enabled = false;
                        this.生成配置文件ToolStripMenuItem.Enabled = false;
                    }

                }
            }
        }

        private void 生成配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuartzGenerateXML xml = new QuartzGenerateXML();
            xml.GenerateXML();
        }

        private void 重置软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteDbInitialize db = new SQLiteDbInitialize();
            db.DropTable();
            db.InitTable();
            reloadDataGridView();
        }

        private void 修改时间片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in this.dataGridView1.SelectedRows)
            {
                if (dr.IsNewRow)
                {
                    return;
                }
                string id = dr.Cells[0].Value.ToString();
                string corn = dr.Cells[4].Value.ToString();
                string corndesc = dr.Cells[5].Value.ToString();

                var x = new ModifyCronPanel(id, corn, corndesc);
                x.ShowDialog(this);
                reloadDataGridView();
            }
        }

        private void 删除记录ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            QuartzJobs jobs = new QuartzJobs();

            foreach (DataGridViewRow dr in this.dataGridView1.SelectedRows)
            {
                string id = dr.Cells[0].Value.ToString();

                jobs.Delete(id);

                dataGridView1.Rows.Remove(dr);

            }
        }

        private void 作废记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (QuartzJobs jobs = new QuartzJobs())
            {
                foreach (DataGridViewRow dr in this.dataGridView1.SelectedRows)
                {
                    string id = dr.Cells[0].Value.ToString();
                    string flag = dr.Cells[6].Value.ToString();

                    flag = Math.Abs(0 - int.Parse(flag)).ToString();

                    jobs.SetValid(id, flag);
                    reloadDataGridView();

                }
            }
        }






    }
}
