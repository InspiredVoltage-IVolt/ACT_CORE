using ACT.Core.Extensions;
using Newtonsoft.Json;

namespace ACT.Core.License
{
    internal class License_Manager
    {
        private bool _IsValid { get; set; } = false;
        private bool _IsDevelopment { get; set; } = false;

        internal ACT_License_Info ACTLicenseInfo;
        string _FilePath = "";
        string _FileContents = "";

        public License_Manager(string FilePath)
        {
            _FilePath = FilePath;

            //TODO Update to New Extensions Version
            try
            {
                _FileContents = FilePath.ReadAllText();
                try
                {
                    var ACTLicenseInfo = ACT_License_Info.FromJson(_FileContents);
                    if (ACTLicenseInfo.Code.FromBase64() == "Development Beta") { _IsDevelopment = true; _IsValid = true; }
                    // TODO Develop All Code
                    if (ACTLicenseInfo.Licensekey.NullOrEmpty() == false) { _IsValid = true; }
                }
                catch
                {
                    _IsValid = false; _IsDevelopment = false;
                }
            }
            catch
            {
                _IsValid = false; _IsDevelopment = false;
            }

        }
    }

    internal class ACT_License_Info
    {
        [JsonProperty("licensekey", NullValueHandling = NullValueHandling.Ignore)]
        public string Licensekey { get; set; }

        [JsonProperty("companyid", NullValueHandling = NullValueHandling.Ignore)]
        public string Companyid { get; set; }

        [JsonProperty("productid", NullValueHandling = NullValueHandling.Ignore)]
        public string Productid { get; set; }

        [JsonProperty("purchaseid", NullValueHandling = NullValueHandling.Ignore)]
        public string Purchaseid { get; set; }

        [JsonProperty("purchasedate", NullValueHandling = NullValueHandling.Ignore)]
        public string Purchasedate { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        public static ACT_License_Info FromJson(string json) => JsonConvert.DeserializeObject<ACT_License_Info>(json, ACT.Core.Encoding.JSON.DefaultConverter.Settings);

        public string ToJson() => JsonConvert.SerializeObject(this, ACT.Core.Encoding.JSON.DefaultConverter.Settings);
    }
}
