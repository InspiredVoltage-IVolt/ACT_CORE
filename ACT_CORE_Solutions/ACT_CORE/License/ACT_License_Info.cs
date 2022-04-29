using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Core.License
{
    [DEV(OriginaDeveloperInfo = "Mark Alicz, Darkbit@Gmail.com")]
    [DEV(ToDo = true, ToDo_Description = "Check Security Rules", LastDeveloperInfo = "Mark Alicz, Darkbit@Gmail.com")]
    [DEV(ToDo = true, ToDo_Description = "Build Test Case")]
    [DEV(RemoveBeforeRelease = true, RemoveBeforeRelease_Description = "Because Its Crappy")]
    public class ACT_License_Info
    {
        [JsonProperty("licensekey", NullValueHandling = NullValueHandling.Ignore)]
        public string Licensekey { get; set; }

        [JsonProperty("companyid", NullValueHandling = NullValueHandling.Ignore)]
        public string Companyid { get; set; }

        [JsonProperty("productid", NullValueHandling = NullValueHandling.Ignore)]
        public string Productid { get; set; }

        [DEV(ToDo = true, ToDo_Description = "Rename to match other code....")]
        [JsonProperty("purchaseid", NullValueHandling = NullValueHandling.Ignore)]
        public string Purchaseid { get; set; }

        [JsonProperty("purchasedate", NullValueHandling = NullValueHandling.Ignore)]
        public string Purchasedate { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [DEV(ToDo = true, ToDo_Description = "Build Test Case")]
        public static ACT_License_Info FromJson(string json) => JsonConvert.DeserializeObject<ACT_License_Info>(json, ACT.Core.Encoding.JSON.DefaultConverter.Settings);

        [DEV(ToDo = true, ToDo_Description = "Build Test Case")]
        public string ToJson() => JsonConvert.SerializeObject(this, ACT.Core.Encoding.JSON.DefaultConverter.Settings);
    }
}
