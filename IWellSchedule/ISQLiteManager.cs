
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;


namespace IWellSchedule
{
    public interface ISQLiteManager
    {
        string DbPath { get; }

        void ExcuteSql(string sql);
        void ExcuteSql(List<string> listSqls);
        /// <summary>
        /// SQL: "insert into student values(@id)"; 
        /// Param: new SQLiteParameter("@id", 1)             
        /// </summary>
        /// <param name="listSqls"></param>
        /// <param name="listParams"></param>
        void ExcuteSqlWithParams(List<string> listSqls, List<SQLiteParameter[]> listParams);


        DataTable GetDataTable(string sql);
    }
}
