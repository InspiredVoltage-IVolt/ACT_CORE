using System;
using Newtonsoft.Json;
using System.Data;


namespace ACT.MSSQL.CLR
{
    public class ST_Database_Column
    {
        [JsonProperty("object_id")]
        public string object_id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("column_id")]
        public string Column_ID;

        [JsonProperty("system_type_id")]
        public string System_Type_ID;

        [JsonProperty("user_type_id")]
        public string User_Type_ID;

        [JsonProperty("max_length")]
        public string Max_Length;

        [JsonProperty("precision")]
        public string Precision;

        [JsonProperty("scale")]
        public string Scale;

        [JsonProperty("is_nullable")]
        public string Is_Nullable;


        public static ST_Database_Column FillTable(DataRow rowData)
        {
            ST_Database_Column _tmp = new ST_Database_Column();
            _tmp.object_id = Convert.ToString(rowData["object_id"]);
            _tmp.Name = Convert.ToString(rowData["name"]);
            _tmp.Column_ID = Convert.ToString(rowData["column_id"]);
            _tmp.System_Type_ID = Convert.ToString(rowData["system_type_id"]);
            _tmp.User_Type_ID = Convert.ToString(rowData["user_type_id"]);
            _tmp.Max_Length = Convert.ToString(rowData["max_length"]);
            _tmp.Precision = Convert.ToString(rowData["Precision"]);
            _tmp.Scale = Convert.ToString(rowData["scale"]);
            _tmp.Is_Nullable = Convert.ToString(rowData["is_nullable"]);
            return _tmp;
        }
    }
}
