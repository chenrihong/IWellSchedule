using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IWellSchedule
{
    public partial class ModifyCronPanel : Form
    {
        public ModifyCronPanel(string id,string corn,string corndesc)
        {
            InitializeComponent();

            this.label1.Text = id;
            this.corn.Text = corn;
            this.corndesc.Text = corndesc;
        }

        private void opencornbtn_Click(object sender, EventArgs e)
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (this.corn.Text.Trim() == "")
            {
                MessageBox.Show("请输入表达试!");
                return;
            }

            string sql = "UPDATE SC_JOBS SET CORN = '" + this.corn.Text.Trim() + "' , CORNDESC = '" + this.corndesc.Text +"'";
            sql += " WHERE ID = '" + this.label1.Text + "'";

            ISQLiteManager manager = new SQLiteManager();
            manager.ExcuteSql(sql);
            this.Close();
        }
    }
}
