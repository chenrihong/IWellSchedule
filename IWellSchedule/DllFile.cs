using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Quartz;

namespace IWellSchedule
{
    public class DllFile
    { 
        public void AddFile()
        {
            string defaultpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            FileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = defaultpath;
            dialog.Filter = "类库 (*.dll)|*.dll";
            dialog.ShowDialog();
            string filename = dialog.FileName;// 物理路径

            if (filename == "")
            {
                return;
            }

            string copytoPath = defaultpath + "\\" + Path.GetFileName(filename);

            FileInfo cptofi = new FileInfo(copytoPath);
           
            if (cptofi.Exists)
            {
                DialogResult dr = MessageBox.Show("文件已经存在，是否覆盖？", "提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                try
                {
                    cptofi.Delete();
                }
                catch (Exception)
                {
                    MessageBox.Show("覆盖失败，请先停止调度","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }
            }

            FileInfo fi = new FileInfo(filename);
            if (fi.Exists)
            {
                fi.CopyTo(copytoPath);
                AddToSC_JOBS(Path.GetFileName(filename));
            }
            else
            {
                MessageBox.Show("操作失败，文件已经被删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToSC_JOBS(string assemblyName)
        {
            string defaultpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = defaultpath + "\\" + assemblyName;

            if (!System.IO.File.Exists(file))
            {
                return;
            }

            Assembly assembly = Assembly.LoadFile(file);

            List<string> sqls = new List<string>();

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IJob).IsAssignableFrom(type) && type.IsClass)
                {
                    string dllName = assemblyName;
                    string nameSapce = assembly.GetName().Name;
                    string className = type.FullName;

                    string sql = "INSERT INTO SC_JOBS(DLLNAME,NAMESPACE ,CLASSNAME ,CORN ,FLAGVALID,IMPORTTIME,ID,CORNDESC)";
                    sql += string.Format(" VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                        dllName, 
                        nameSapce,
                        className,
                        "0/3 * * * * ?",
                        "1",
                        DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm:ss"),
                        System.Guid.NewGuid().ToString(),
                        "每隔3秒"
                        );

                    sqls.Add(sql);
                }
            }

            if (sqls.Count == 0)
            {
                MessageBox.Show("此文件未找到实现IJob接口的类，是无效文件");
                FileInfo fi = new FileInfo(file);
                fi.Delete();
                return;
            }

            ISQLiteManager manager = new SQLiteManager();
            manager.ExcuteSql(sqls);
        }

        private DataTable GetAssemblies()
        {
            ISQLiteManager manager = new SQLiteManager();
            return manager.GetDataTable("SELECT DLLNAME FROM SC_JOBS");

        }

        private void DeleteAssembly(string dllName)
        {
            ISQLiteManager manager = new SQLiteManager();
            manager.ExcuteSql("DELETE SC_JOBS WHERE DLLNAME = '" + dllName + "'");
        }
    }
}



