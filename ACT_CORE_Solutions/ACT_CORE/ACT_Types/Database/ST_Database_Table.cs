using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace ACT.MSSQL.CLR
{
    public class ST_Database_Table
    {
        public ST_Database_Table() { Columns = new List<ST_Database_Column>(); }

        [JsonProperty(propertyName: "table_name")]
        public string Table_Name;

        [JsonProperty(propertyName: "schema_id")]
        public string Schema_ID;

        [JsonProperty(propertyName: "modify_date")]
        public string Modify_Date;

        [JsonProperty(propertyName: "create_date")]
        public string Create_Date;

        [JsonProperty(propertyName: "object_id")]
        public string Object_ID;

        [JsonProperty(propertyName: "columns")]
        List<ST_Database_Column> Columns;

        public void PopulateData(string DatabaseName, string TableName)
        {
            string _SQL = Helper.TableInfo_WithDatabaseName;
            _SQL = _SQL.Replace("###DATABASENAME###", DatabaseName);
            _SQL = _SQL.Replace("###TABLENAME###", TableName);

            DataTable _DataTable = DatabaseHelper.RunQuery(_SQL, "TableName_Info");

            if (_DataTable.Rows.Count == 0) { return; }

            Table_Name = TableName;
            Schema_ID = Convert.ToString(_DataTable.Rows[0]["schema_id"]);
            Modify_Date = Convert.ToString(_DataTable.Rows[0]["modify_date"]);
            Create_Date = Convert.ToString(_DataTable.Rows[0]["create_date"]);
            Object_ID = Convert.ToString(_DataTable.Rows[0]["object_id"]);


            string _SQL2 = Helper.DatabaseTable_Columns_SQLStatement;
            _SQL2 = _SQL2.Replace("###DATABASENAME###", DatabaseName);
            _SQL2 = _SQL2.Replace("###TABLENAME###", TableName);
            DataTable _DataTableColumns = DatabaseHelper.RunQuery(_SQL2, "TableName_Info");

            foreach (DataRow drCol in _DataTableColumns.Rows)
            {
                ST_Database_Column _tmp = ST_Database_Column.FillTable(drCol);
                Columns.Add(_tmp);
            }
        }
    }
}
