using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACT.MSSQL.CLR
{
    public class TreeORoot_Manager
    {
        public TreeORoot_Manager()
        {
            Databases = new List<ST_Database>();

        }

        [JsonProperty(PropertyName = "backup_date")]
        public DateTime BackupDate = DateTime.Now;

        [JsonProperty(PropertyName = "databases")]
        public List<ST_Database> Databases;

        [JsonIgnore()]
        private bool _Populated = false;

        /// <summary>
        /// Populate Database
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Populate(List<string> IgnoreDatabases)
        {

            string _SQL = "SELECT name FROM sys.databases WHERE name NOT IN ('master','tempdb','model', 'msdb'";
            foreach (string DB in IgnoreDatabases)
            {
                _SQL = _SQL + ",[" + DB + "]";
            }
            _SQL = _SQL + ") ORDER BY Name ASC";

            var _DataTable = DatabaseHelper.RunQuery(_SQL, "AllDatabases");

            foreach (System.Data.DataRow DR in _DataTable.Rows)
            {
                var _tmpDB = new ST_Database();
                _tmpDB.DatabaseName = Convert.ToString(DR["name"].ToString());

                var _SQL_Tables = Helper.All_TableNames_For_One_Database;
                _SQL_Tables = _SQL_Tables.Replace("###DATABASENAME###", _tmpDB.DatabaseName);

                var TablesAndColumnsDT = DatabaseHelper.RunQuery(_SQL_Tables, "All_Databases_Tables");

                foreach (DataRow DtrRow in TablesAndColumnsDT.Rows)
                {
                    ST_Database_Table _tmpTable = new ST_Database_Table();
                    _tmpTable.PopulateData(_tmpDB.DatabaseName, Convert.ToString(DtrRow["TABLE_NAME"]));

                    _tmpDB.DatabaseTables.Add(_tmpTable);
                }

                var _SQLEProp = Helper.Table_Get_Extended_Properties;
                _SQLEProp = _SQLEProp.Replace("###DATABASENAME###", _tmpDB.DatabaseName);

                var DBExtendedProperties = DatabaseHelper.RunQuery(_SQLEProp, "All_Extended_Properties");
                _tmpDB.DatabaseExtendedProperties = new List<ST_ExtendedProperties>();
                foreach (DataRow PropDR in DBExtendedProperties.Rows) { _tmpDB.DatabaseExtendedProperties.Add(ST_ExtendedProperties.Populate(PropDR)); }
                Databases.Add(_tmpDB);
            }
            _Populated = true;
        }

        /// <summary>
        /// Export All Data To JSON
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ExportAll()
        {
            if (_Populated == false) { throw new Exception("Please Populate the Database First"); }
            return JsonConvert.SerializeObject(this);
        }
    }
}

