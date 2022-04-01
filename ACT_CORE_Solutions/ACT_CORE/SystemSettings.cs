using ACT.Core.Enums;
using ACT.Core.Exceptions;
using ACT.Core.Extensions;
using ACT.Core.ACT_Types;

namespace ACT.Core
{
    /// <summary>
    /// Important Class
    /// 
    ///  FIRST METHOD CALLED ALWAYS
    ///     ProcessFirstStartup() 
    ///         - Looks For Both Plain Text and Encrypted ConfigurationFiles
    ///         - If Found it Loads the Configuration and Encrypts the File using ProtectedData - UserLevel
    /// 
    /// 
    /// 
    /// </summary>
    internal class SystemSettings
    {
        #region Private Variable

        private bool HasStartedUpProperly = false;

        internal SystemSettingsData _LoadedConfigurationData = null;

        internal Dictionary<string, SystemSettingsData> _AdditionalConfiguration = new Dictionary<string, SystemSettingsData>();

        private string LicFilePath { get { return AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "lic.txt"; } }

        private char[] _Storage = null;

        private Dictionary<string, System.Security.SecureString> _StorageKeyData = new Dictionary<string, System.Security.SecureString>();

        #endregion

        #region Public Properties

        // Public Path Locations
        public static string BaseDirectory { get { return AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat(); } }
        public static string ResourceDirectory { get { return AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\"; } }
        internal static string SysConfig = AppDomain.CurrentDomain.BaseDirectory.FindFileReturnPath("SystemConfiguration.json");



        internal static string SysConfigEnc = AppDomain.CurrentDomain.BaseDirectory.FindFileReturnPath("SystemConfiguration.enc");

        public bool SettingsLoaded { get { if (HasStartedUpProperly && _LoadedConfigurationData != null) { return true; } else { return false; } } }
        public bool SettingsNeedSaving { get; internal set; }
        public string SettingsPath { get; internal set; } = "";
        

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor For the System Settings Class
        /// </summary>
        public SystemSettings()
        {
            HasStartedUpProperly = false;
            if (HasStartedUpProperly == false) { ProcessFirstStartup(); }
        }

        #endregion

 
        public bool LoadConfigurationFile(string Path, bool IsEncrypted, string configType = "default")
        {
            return false;
        }

     

        /// <summary>
        /// Checks to see if this is the first time ACT_Core has been used.
        /// Make Sure the Settings File Is Encrypted UNLESS AppDomain.CurrentDirectory\\Resources\\config.noprotect exists
        /// This will encrypt the configuration file unless config.noprotect file exists
        /// Content Doesnt Matter
        /// </summary>
        /// <dependson>
        /// LoadConfigurationFile()
        /// </dependson>
        /// <returns>true / false</returns>
        private bool ProcessFirstStartup()
        {
            string[] _FileLocationsEncrypted = new string[] { BaseDirectory + "SystemConfiguration.enc", BaseDirectory + "Resources\\SystemConfiguration.enc", BaseDirectory + "Data\\SystemConfiguration.enc" };
            string[] _FileLocationsPlainText = new string[] { BaseDirectory + "SystemConfiguration.json", BaseDirectory + "Resources\\SystemConfiguration.json", BaseDirectory + "Data\\SystemConfiguration.json" };

            string _FoundLocation = null; bool _IsEncrypted = false;

            // Loop over all Encrypted Files
            // If Found Nothing Left to Do.
            foreach (string x in _FileLocationsEncrypted)
            {
                if (x.FileExists(x))
                {
                    _FoundLocation = x;
                    _IsEncrypted = true;
                    goto foundFileLabel;
                }
            }

            // If No Encrypted File Is Found
            if (_FoundLocation == null)
            {
                foreach (string x in _FileLocationsPlainText)
                {
                    if (x.FileExists())
                    {
                        _IsEncrypted = false;
                        _FoundLocation = x;
                        goto foundFileLabel;
                    }
                }
            }

            HasStartedUpProperly = false;
            return false;

        foundFileLabel:

            // Make Sure the Settings File Is Encrypted UNLESS config.noprotect file exists
            if (_IsEncrypted == false)
            {
                if ((ResourceDirectory + "config.noprotect").FileExists() == true)
                {
                    return LoadConfigurationFile(_FoundLocation);
                }
                else
                {
                    ProtectConfigurationFile(_FoundLocation);
                    return LoadConfigurationFile(_FoundLocation);
                }
            }
            else
            {
                return LoadConfigurationFile(_FoundLocation);
            }
        }

        internal bool ProtectConfigurationFile(string Path)
        {
            return false;
            string _Data = "";
            _Data = Path.ReadAllText();

            if ((AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\SystemConfiguration.enc").FileExists())
            {
                //string _BackupConfigFile = (AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\SystemConfiguration.enc").CopyFile_Passivly();
                _Data.SaveAllText(AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\SystemConfiguration.enc");
            }

            _Data.SaveAllText(AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\SystemConfiguration.enc");

            if ((AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\SystemConfiguration.json").FileExists())
            {
                (AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\SystemConfiguration.json").DeleteFile(4999);
            }

            Path.DeleteFile(2000);
        }




        /// <summary>
        /// Loads and Encrypts the configuration file.
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="IsEncrypted"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool LoadConfigurationFile(string Path, string configType = "default")
        {
            //var _tmpConfig = 
            var _tmpConfig = SystemSettingsData.FromJson(Path.ReadAllText());

            if (configType == "default") { _LoadedConfigurationData = _tmpConfig; }
            else
            {
                if (_AdditionalConfiguration.ContainsKey(configType)) { _AdditionalConfiguration[configType] = _tmpConfig; }
                else { _AdditionalConfiguration.Add(configType, _tmpConfig); }
            }

            if (_LoadedConfigurationData == null) { HasStartedUpProperly = false; return false; }

            HasStartedUpProperly = true;
            return true;
        }


        /// <summary>
        /// Load the Encryption Key
        /// </summary>
        internal System.Security.SecureString Default_EncryptionKey
        {
            get
            {
                if (_StorageKeyData != null) { return _StorageKeyData["default"]; }
                else
                {
                    if (_LoadedConfigurationData.EncryptionKeys.Exists(x => x.Identifier == "default" && x.KeyValue.NullOrEmpty() == false))
                    {
                        _Storage = _LoadedConfigurationData.EncryptionKeys.First(x => x.Identifier == "default").KeyValue.ToCharArray();
                        _StorageKeyData.Add("default", new System.Security.SecureString());
                        _Storage.ForEach(c => _StorageKeyData["default"].AppendChar(c));
                    }
                }

                if (_StorageKeyData == null) { throw new Missing_Encryption_Key(); }
                return _StorageKeyData[default];
            }
        }

        /// <summary>
        /// Load a secondary or seperate key
        /// </summary>
        /// <param name="Identifier"></param>
        /// <returns></returns>
        public bool LoadEncryptionKey(string Identifier)
        {
            if (SettingsLoaded == false) { throw new Exception("Settings Not Loaded"); }

            try
            {
                if (_LoadedConfigurationData.EncryptionKeys.Exists(x => x.Identifier == Identifier && x.KeyValue.NullOrEmpty() == false))
                {
                    _Storage = _LoadedConfigurationData.EncryptionKeys.First(x => x.Identifier == Identifier).KeyValue.ToCharArray();
                    _StorageKeyData.Add(Identifier, new System.Security.SecureString());
                    _Storage.ForEach(c => _StorageKeyData[Identifier].AppendChar(c));
                    return true;
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Search For Sensitive Files and Auto Encrypt Them
        /// </summary>
        /// <returns></returns>
        public List<string> DetectSensitiveFiles(List<string> CustomKeywords)
        {
            if (SettingsLoaded == false) { throw new Exception("Settings Not Loaded"); }

            var _Keywords = _LoadedConfigurationData.ComplexSettings.First(x => x.GroupName.ToLower() == "system" && x.Name.ToLower() == "sensitivefiles").Values;
            if (_Keywords == null || _Keywords.Count == 0) { return null; }

            return _Keywords;
        }

        /// <summary>
        /// Search For a Specific Setting
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="SectionsToSearch"></param>
        /// <returns></returns>
        public string GetSettingByName(string Name, SystemSettingsSections SectionsToSearch = (SystemSettingsSections.Basic | SystemSettingsSections.Complex))
        {
            if (SettingsLoaded == false) { return null; }

            if (_LoadedConfigurationData.BasicSettings.Exists(x => x.Name == Name))
            {
                return _LoadedConfigurationData.BasicSettings.First(x => x.Name == Name).Value;
            }
            else if (_LoadedConfigurationData.ComplexSettings.Exists(x => x.Name == Name))
            {
                return _LoadedConfigurationData.ComplexSettings.First(x => x.Name == Name).Value;
            }
            return "";
        }

        /// <summary>
        /// Gets Active Config
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public ACT_Types.SystemSettingsData GetAndSet_ActiveConfig(string Name = "")
        {
            if (Name.NullOrEmpty()) { Name = "Default"; }

            if (SettingsLoaded == false) { return null; }

            if (Name == "default") { return _LoadedConfigurationData; }
            else
            {
                if (_AdditionalConfiguration.ContainsKey(Name))
                {
                    return _AdditionalConfiguration[Name];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
