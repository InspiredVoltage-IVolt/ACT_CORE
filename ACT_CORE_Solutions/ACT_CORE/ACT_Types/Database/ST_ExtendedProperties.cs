using System;
using System.Data;
using Newtonsoft.Json;

namespace ACT.MSSQL.CLR
{

    public class ST_ExtendedProperties
    {
        public ST_ExtendedProperties() { }

        #region Properties

        [JsonProperty(PropertyName = "class")]
        public string EP_Class { get; set; }

        [JsonProperty(PropertyName = "class_desc")]
        public string EP_ClassDesc { get; set; }

        [JsonProperty(PropertyName = "major_id")]
        public string EP_Major_ID { get; set; }

        [JsonProperty(PropertyName = "minor_id")]
        public string EP_Minor_ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string EP_Name { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string EP_Value { get; set; }

        #endregion

        public static ST_ExtendedProperties Populate(DataRow Data)
        {
            ST_ExtendedProperties _tmp = new ST_ExtendedProperties();
            _tmp.EP_Class = Convert.ToString(Data["class"]);
            _tmp.EP_ClassDesc = Convert.ToString(Data["class_desc"]);
            _tmp.EP_Major_ID = Convert.ToString(Data["major_id"]);
            _tmp.EP_Minor_ID = Convert.ToString(Data["minor_id"]);
            _tmp.EP_Name = Convert.ToString(Data["name"]);
            _tmp.EP_Value = Convert.ToString(Data["value"]);
            return _tmp;
        }
    }
}
