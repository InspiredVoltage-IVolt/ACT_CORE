using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ACT.Core.Encoding.JSON;

namespace ACT.Core.ACT_Types.JSON
{
    public class DbJsonArray
    {
        [Attributes.MSSQL_USERTYPES_ATTRIBUTE(UserTypeName = "arraydata")]
        [JsonProperty("arraydata", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Arraydata { get; set; }

        public static DbJsonArray FromJson(string json)
        {
            string JSON = json.Trim();
            
            if (JSON.Contains("\"arraydata\""))
            {
                return JsonConvert.DeserializeObject<DbJsonArray>(json, DefaultConverter.Settings);
            }
            else
            {
                int _indexof1Quote = JSON.IndexOf("\"");
                string _PropName = JSON.Substring(_indexof1Quote + 1); 
                int _indexofF2Quote = _PropName.IndexOf("\"");
                _PropName = JSON.Substring(0, _indexofF2Quote);

                if (_PropName.ToLower() != "arraydata") { JSON = JSON.Replace(_PropName, "arraydata"); }

                try
                {
                    return JsonConvert.DeserializeObject<DbJsonArray>(json, DefaultConverter.Settings);
                }
                catch(Exception ex)
                {
                    _.LogBasicInfoWithException("original: [[[" + json + "]]], reformatted: [[[" + JSON + "]]]", ex);
                    throw new Exception("Invalid Data Found: " + json + " -- " + JSON);
                }
            }

        }
        public string ToJson() { return JsonConvert.SerializeObject(this, DefaultConverter.Settings); }
    }

}
