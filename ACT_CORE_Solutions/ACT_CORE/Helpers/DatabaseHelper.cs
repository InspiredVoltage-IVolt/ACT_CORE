using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Security.Cryptography;

namespace ACT.Core.Helpers
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// TODO TEST AND FIX
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        /// <param name="InitialCatalog"></param>
        /// <param name="DataSource"></param>
        /// <param name="Timeout"></param>
        /// <param name="Port"></param>
        /// <param name="DBEngine"></param>
        /// <returns></returns>
        public static string GenerateConnectionString(string UserID, string Password, string InitialCatalog, string DataSource, int Timeout = 30, int Port = -1, Enums.Database.Database_Engine DBEngine = Enums.Database.Database_Engine.MSSQL)
        {
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

            myBuilder.UserID = UserID;
            myBuilder.Password = Password;
            myBuilder.InitialCatalog = InitialCatalog;
          
            myBuilder.ConnectTimeout = Timeout;

            if (DBEngine == Enums.Database.Database_Engine.ORACLE)
            {
                myBuilder.ConnectTimeout = Timeout;
                if (Port == -1) { Port = 1521; }
                myBuilder.DataSource = DataSource + ":" + Port.ToString();
            }
            else if (DBEngine == Enums.Database.Database_Engine.MSSQL)
            {
                myBuilder.ConnectTimeout = Timeout;
                if (Port == -1) {  Port = 1433;  }
                myBuilder.DataSource = DataSource + ", " + Port.ToString();
                
            }
            else if (DBEngine == Enums.Database.Database_Engine.MYSQL)
            {
                if (Port == -1) { Port = 3306; }
                myBuilder.Add("Server", DataSource + ":" + Port.ToString() + ":" + InitialCatalog);
                //Server = myServerAddress; Port = 1234; Database = myDataBase; Uid = myUsername; Pwd = myPassword;
            }
            return myBuilder.ConnectionString;
        }

        public static string GenerateConnectionStringIntegratedSecurity(string InitialCatalog, string DataSource, int Timeout = 30, Enums.Database.Database_Engine DBEngine = Enums.Database.Database_Engine.MSSQL)
        {
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

            myBuilder.InitialCatalog = InitialCatalog;
            myBuilder.DataSource = DataSource;

            if (DBEngine == Enums.Database.Database_Engine.ORACLE)
            {
                myBuilder.PersistSecurityInfo = true;
                myBuilder.ConnectTimeout = Timeout;
            }
            else if (DBEngine == Enums.Database.Database_Engine.MSSQL)
            {
                myBuilder.IntegratedSecurity = true;
                myBuilder.ConnectTimeout = Timeout;
            }

            return myBuilder.ConnectionString;
        }
    }
}
