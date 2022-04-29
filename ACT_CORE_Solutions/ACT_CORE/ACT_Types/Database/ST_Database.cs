using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACT.MSSQL.CLR
{
    public class ST_Database
    {
        public ST_Database()
        {
            DatabaseTables = new List<ST_Database_Table>();
          //  DatabaseColumns = new List<ST_Database_Column>();
            DatabaseExtendedProperties = new List<ST_ExtendedProperties>(); 
        }

        [JsonProperty(PropertyName = "database-name")]
        public string DatabaseName;

        [JsonProperty(PropertyName = "database-tables")]
        public List<ST_Database_Table> DatabaseTables;

      //  [JsonProperty(PropertyName = "database-columns")]
      //  public List<ST_Database_Column> DatabaseColumns;

        [JsonProperty(PropertyName = "database-extendedproperties")]
        public List<ST_ExtendedProperties> DatabaseExtendedProperties;

       

    }
}
