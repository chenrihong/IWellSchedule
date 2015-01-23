using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;

namespace IWellSchedule
{
    public class SQLiteDbInitialize
    {
        private readonly ILog logger;

        public SQLiteDbInitialize()
        {
            try
            {
                logger = LogManager.GetLogger(GetType());
                InitTable();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex);
            }
        }

        public void InitTable()
        {

            ISQLiteManager manager = new SQLiteManager();


            List<string> sqls = new List<string>();

            sqls.Add(
                "CREATE TABLE IF NOT EXISTS SC_JOBS(ID TEXT PRIMARY KEY,DLLNAME TEXT,NAMESPACE TEXT,CLASSNAME TEXT,CORN TEXT,CORNDESC TEXT,FLAGVALID TEXT,IMPORTTIME TEXT)");

            manager.ExcuteSql(sqls);

        }

        public void DropTable()
        {
            ISQLiteManager manager = new SQLiteManager();


            List<string> sqls = new List<string>();

            sqls.Add("DROP TABLE IF EXISTS SC_JOBS");

            manager.ExcuteSql(sqls);
        }
    }
}
