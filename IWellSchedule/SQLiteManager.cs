using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;


/*
 * http://hzy3774.iteye.com/blog/1691932
 */

namespace IWellSchedule
{
    public class SQLiteManager : ISQLiteManager
    {

        /// <summary>
        /// SQLite 数据库位置
        /// </summary>
        public string DbPath
        {
            get { return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\my.db"; }
        }

        private string ConnectionString
        {
            get { return "Data Source =" + DbPath + ";Pooling=true;FailIfMissing=false"; }
        }

        public void ExcuteSql(string sql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcuteSqlWithParams(List<string> listSqls, List<SQLiteParameter[]> listParams)
        {
            if (listSqls.Count == 0 || listParams.Count == 0)
            {
                throw new Exception("参数 listSqls 或 listParam Count 为 0");
            }

            //创建连接  
            using (SQLiteConnection conn = new SQLiteConnection("Data Source =" + DbPath))
            {
                //打开连接  
                conn.Open();
                //实例化一个事务  
                using (SQLiteTransaction tran = conn.BeginTransaction())
                {
                    for (int i = 0; i < listSqls.Count; i++)
                    {
                        string sql = listSqls[i];
                        SQLiteParameter[] param = listParams[i];

                        //实例化SQL命令  
                        SQLiteCommand cmd = new SQLiteCommand(conn);
                        cmd.Transaction = tran;

                        cmd.CommandText = sql; //设置带参SQL语句  
                        cmd.Parameters.AddRange(param);

                        cmd.ExecuteNonQuery(); //执行查询  
                    }
                    tran.Commit(); //提交  
                }
            }
        }

        public void ExcuteSql(List<string> listSqls)
        {
            if (listSqls.Count == 0)
            {
                throw new Exception("参数 listSqls Count 为 0");
            }

            //创建连接  
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                //打开连接  
                conn.Open();
                //实例化一个事务  
                using (SQLiteTransaction tran = conn.BeginTransaction())
                {
                    foreach (string sql in listSqls)
                    {
                        //实例化SQL命令  
                        SQLiteCommand cmd = new SQLiteCommand(conn);
                        cmd.Transaction = tran;

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        /*
                        cmd.CommandText = "insert into student values(@id, @name, @sex)"; //设置带参SQL语句  
                        cmd.Parameters.AddRange(new[]
                        {
                            //添加参数  
                            new SQLiteParameter("@id", i),
                            new SQLiteParameter("@name", "中国人"),
                            new SQLiteParameter("@sex", "男")
                        });
                        */
                    }
                    tran.Commit(); //提交  
                }
                conn.Close();
            }
        }


        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                SQLiteDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                conn.Close();
            }

            return dt;
        }

    }
}
