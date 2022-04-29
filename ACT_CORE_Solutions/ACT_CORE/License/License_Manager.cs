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

    
}
