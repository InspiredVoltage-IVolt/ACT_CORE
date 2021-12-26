using ACT.Core.Enums;
using ACT.Core.Exceptions;
using ACT.Core.Extensions;

namespace ACT.Core
{
    public partial class SystemSettings
    {
        private bool FirstStartup { get; set; }

        private string BD { get { return AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat(); } }
        private string LIC { get { return AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "lic.txt"; } }

        public bool SettingsLoaded { get; internal set; }

        public bool SettingsNeedSaving { get; internal set; }

        public string SettingsPath { get; internal set; } = "";
        char[] _Storage = null;

        private System.Security.SecureString _StorageKeyData = null;

        private bool IsFirstStartup()
        {
            /// Only Locations Tje Data Woll Exist Ink
            string[] _FileLocations = new string[] { BD + "settings.enc", BD + "Resources\\settings.enc", BD + "Data\\settings.enc", BD + "\\readme.enc" };
            string _FoundLocation = null;

            _FileLocations.ForEach(x =>
            {
                if (x.FileExists(x)) { _FoundLocation = x; return; }
            });

            if (_FoundLocation == null)
            {
                //  var _settings = System.Security.Data

            }
            return false;
        }

        internal System.Security.SecureString EncryptionKey_Protected
        {
            get
            {
                if (_StorageKeyData == null)
                {
                    _Storage = "Goto SecretSection".ToCharArray();
                    _StorageKeyData = new System.Security.SecureString();
                    _Storage.ForEach(c => _StorageKeyData.AppendChar(c));
                }

                if (_StorageKeyData == null) { throw new Missing_Encryption_Key(); }

                return _StorageKeyData;
            }
        }

        internal SystemSettings.ConfigurationData _LoadedConfigurationData = null;

        public void Load(string Path = "")
        {
            if (Path.NullOrEmpty())
            {
                // Search For The Settings File
                string _SysConfig = AppDomain.CurrentDomain.BaseDirectory.FindFileReturnPath("SystemConfiguration.json");
                string _SysConfigEnc = AppDomain.CurrentDomain.BaseDirectory.FindFileReturnPath("SystemConfiguration.enc");
                if (_SysConfigEnc != null)
                {
                    //_SysConfigEnc.DecryptString(this.Ab);
                }
            }
        }

        public string GetSettingByName(string Name, SystemSettingsSections SectionsToSearch = (SystemSettingsSections.Basic | SystemSettingsSections.Complex))
        {
            return "";
        }
    }
}
