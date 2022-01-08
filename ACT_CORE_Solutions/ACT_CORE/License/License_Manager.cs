using ACT.Core.Attributes;
using ACT.Core.Extensions;
using Newtonsoft.Json;


namespace ACT.Core.License
{
    [DEV(OriginaDeveloperInfo = "Mark R Alicz, Darkbit@Gmail.com")]
    [Localization()]
    public class License_Manager : ACT_Core
    {
        private bool _IsValid { get; set; } = false;
        private bool _IsDevelopment { get; set; } = false;

        internal ACT_License_Info ACTLicenseInfo;
        string _FilePath = "";
        string _FileContents = "";

        [DEV(Priority = 10, RemoveBeforeRelease = true, RemoveBeforeRelease_Description = "Incorporate Real Security Local Security or Server Security", ToDo = true)]
        [DEV(ToDo = true, ToDo_Description = "Build Test Case")]
        public License_Manager(string FilePath)
        {
            _FilePath = FilePath;

            try
            {
                _FileContents = FilePath.ReadAllText().DecryptString("ACTLicFileEncryp");
                try
                {
                    ACTLicenseInfo = ACT_License_Info.FromJson(_FileContents);
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
