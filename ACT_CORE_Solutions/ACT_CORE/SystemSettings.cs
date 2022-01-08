using ACT.Core.Enums;
using ACT.Core.Exceptions;
using ACT.Core.Extensions;

namespace ACT.Core
{
    /// <summary>
    /// Important Class
    /// </summary>
    internal class SystemSettings
    {
        #region Private Variable

        private bool HasStartedUpProperly = false;
        internal Structs.SystemSettingsData _LoadedConfigurationData = null;
        internal Dictionary<string, Structs.SystemSettingsData> _OtherConfigurationData = new Dictionary<string, Structs.SystemSettingsData>();
        private string LIC { get { return AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "lic.txt"; } }
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

        /// <summary>
        /// Checks to see if this is the first time ACT_Core has been used.
        /// </summary>
        /// <returns></returns>
        private bool ProcessFirstStartup()
        {
            string[] _FileLocations = new string[] { BaseDirectory + "SystemConfiguration.enc", BaseDirectory + "Resources\\SystemConfiguration.enc", BaseDirectory + "Data\\SystemConfiguration.enc" };
            string[] _FileLocationsUnEncrypted = new string[] { BaseDirectory + "SystemConfiguration.json", BaseDirectory + "Resources\\SystemConfiguration.json", BaseDirectory + "Data\\SystemConfiguration.json" };

            string _FoundLocation = null;
            bool _IsEncrypted = false;
            _FileLocations.ForEach(x =>
            {
                if (x.FileExists(x))
                {
                    _FoundLocation = x;
                    return;
                }
            });
            if (_FoundLocation == null)
            {
                _FileLocationsUnEncrypted.ForEach(x =>
                {
                    if (x.FileExists(x))
                    {
                        _IsEncrypted = true;
                        _FoundLocation = x;
                        return;
                    }
                });
            }

            if (_FoundLocation == null) { HasStartedUpProperly = false; return false; }
            else { return LoadConfigurationFile(_FoundLocation, _IsEncrypted); }
        }

        /// <summary>
        /// Loads and Encrypts the configuration file.
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="IsEncrypted"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool LoadConfigurationFile(string Path, bool IsEncrypted, string configType = "default")
        {
            string _Data = "";
            if (Path.NullOrEmpty()) { throw new ArgumentNullException(nameof(Path)); }
            if (IsEncrypted) { _Data = Path.ReadAllText().UnProtect(); }
            else { _Data = Path.ReadAllText(); }

            var _tmpConfig = Structs.SystemSettingsData.FromJson(_Data);
            var _Version = _tmpConfig.FileVersion.ToInt(0);

            if (_Version > 1 && _Version < 2) { }
            else { HasStartedUpProperly = false; return false; }

            if (IsEncrypted == false)
            {
                _tmpConfig.Save(Path.Replace(".json", ".enc"));
                Path.DeleteFile(2000);
            }

            if (configType == "default") { _LoadedConfigurationData = _tmpConfig; }
            else
            {
                if (_OtherConfigurationData.ContainsKey(configType)) { _OtherConfigurationData[configType] = _tmpConfig; }
                else { _OtherConfigurationData.Add(configType, _tmpConfig); }
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
        public Structs.SystemSettingsData GetAndSet_ActiveConfig(string Name = "")
        {
            if (Name.NullOrEmpty()) { Name = "Default"; }

            if (SettingsLoaded == false) { return null; }

            if (Name == "default") { return _LoadedConfigurationData; }
            else
            {
                if (_OtherConfigurationData.ContainsKey(Name))
                {
                    return _OtherConfigurationData[Name];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
