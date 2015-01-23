using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IWellSchedule
{
    public class QuartzJobs : IDisposable
    {
        public void SetValid(string id, string val)
        {
            ISQLiteManager manager = new SQLiteManager();

            manager.ExcuteSql("UPDATE SC_JOBS SET FLAGVALID = '" + val + "' WHERE id = '" + id + "'");

        }

        public void Delete(string id)
        {
            ISQLiteManager manager = new SQLiteManager();

            manager.ExcuteSql("DELETE FROM SC_JOBS WHERE id = '" + id + "'");

        }

        /// <summary>
        /// 取 FLAGVALID = 1 的数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetValidData()
        {
            return GetDataTable("FLAGVALID = '1'");
        }

        public DataTable GetDataTable(string whereClause)
        {
            ISQLiteManager manager = new SQLiteManager();
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM SC_JOBS";
            if (!string.IsNullOrEmpty(whereClause))
            {
                sql += " WHERE " + whereClause;
            }
            dt = manager.GetDataTable(sql);


            //ID INT,DLLNAME TEXT,NAMESPACE TEXT,CLASSNAME TEXT,CORN TEXT,FLAGVALID,IMPORTTIME TEXT
            dt.Columns["DLLNAME"].ColumnName = "动态链接库";
            dt.Columns["NAMESPACE"].ColumnName = "命名空间";
            dt.Columns["CLASSNAME"].ColumnName = "类";

            dt.Columns["FLAGVALID"].ColumnName = "启用";
            dt.Columns["IMPORTTIME"].ColumnName = "创建时间";
            dt.Columns["CORNDESC"].ColumnName = "时间片描述";
            dt.Columns["CORN"].ColumnName = "时间片";

            return dt;
        }


        public DataTable GetDataTable()
        {
            return GetDataTable("");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
