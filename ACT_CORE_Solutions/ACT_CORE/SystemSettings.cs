using ACT.Core.Enums;
using ACT.Core.Exceptions;
using ACT.Core.Extensions;
using ACT.Core.ACT_Types;

namespace ACT.Core
{
    /// <summary>
    /// Important Class - Uses SystemConfiguration as the Holder Class
    /// 
    ///  FIRST METHOD CALLED ALWAYS
    ///     ProcessFirstStartup() 
    ///         - Looks For Both Plain Text and Encrypted ConfigurationFiles
    ///         - If Found it Loads the Configuration and Encrypts the File using ProtectedData - UserLevel
    /// 
    /// 
    /// 
    /// </summary>
    public static class SystemSettings
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static SystemSettings()
        {
            if (!ACT_Status.SysConfigFileLocation.FileExists()) { ACT_Status.SysConfigFileLocation = ACT_Status.BaseDirectory.FindFileReturnPath("SystemConfiguration.json", true); }
            else
            {
                _ACT_Core_Ready = false;
                var _EX = new FileNotFoundException("SystemConfiguration.json Not Found");
                _.LogFatalError("Unable To Locate System Configuration Anywhere under or in the base directory.", _EX);
                throw _EX;
            }

            #region Load Settings.ini File

            var _INIData = ACT_Status.SettingsINIFileLocation.ReadAllText().SplitString(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            if (_INIData[0].ToLower() == "encrypt_configfile") { ACT_Status.EncryptConfigFile = Convert.ToBoolean(_INIData[0].Substring(_INIData[0].IndexOf(":") + 1)); }
            if (_INIData[1].ToLower() == "verbose-logging") { ACT_Status.VerboseDebugging = Convert.ToBoolean(_INIData[1].Substring(_INIData[1].IndexOf(":") + 1)); }

            #endregion

            // Load Configuration

            _ACT_Core_Ready = false;
            if (ACT_Core_Ready == false) { ProcessFirstStartup(); }


            


        }

        #region public Variables

        public static SystemConfiguration _LoadedConfigurationData = null;
        public static Dictionary<string, SystemConfiguration> _AdditionalLoadedConfiguration = new Dictionary<string, SystemConfiguration>();

       
        #endregion

        #region Methods



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
        private static bool ProcessFirstStartup()
        {
            bool _IsEncrypted = false;

            // Check If Config Is Encrypted
            if (ACT_Status.SysConfigEncFileLocationc.FileExists()) { _IsEncrypted = true; }
            else
            {

            }


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

            ACT_Core_Ready = false;
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

        #endregion

        public bool LoadConfigurationFile(string Path, bool IsEncrypted, string configType = "default")
        {
            return false;
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
            var _tmpConfig = SystemConfiguration.FromJson(Path.ReadAllText());

            if (configType == "default") { _LoadedConfigurationData = _tmpConfig; }
            else
            {
                if (_AdditionalLoadedConfiguration.ContainsKey(configType)) { _AdditionalLoadedConfiguration[configType] = _tmpConfig; }
                else { _AdditionalLoadedConfiguration.Add(configType, _tmpConfig); }
            }

            if (_LoadedConfigurationData == null) { ACT_Core_Ready = false; return false; }

            ACT_Core_Ready = true;
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
        public ACT_Types.SystemConfiguration GetAndSet_ActiveConfig(string Name = "")
        {
            if (Name.NullOrEmpty()) { Name = "Default"; }

            if (SettingsLoaded == false) { return null; }

            if (Name == "default") { return _LoadedConfigurationData; }
            else
            {
                if (_AdditionalLoadedConfiguration.ContainsKey(Name))
                {
                    return _AdditionalLoadedConfiguration[Name];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
