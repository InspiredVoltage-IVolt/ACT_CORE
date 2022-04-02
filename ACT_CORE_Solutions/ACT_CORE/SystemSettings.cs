using ACT.Core.Enums;
using ACT.Core.Exceptions;
using ACT.Core.Extensions;
using ACT.Core.ACT_Types;
using ACT.Core.Security;

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

            ACT_Status.ACT_Core_Ready = false;
            if (ACT_Status.ACT_Core_Ready == false) { ProcessFirstStartup(); }


        }

        #region Public Configuration Variables

        public static SystemConfiguration Primary_Loaded_SystemConfigurationFile = null;
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
            // Check If Config Is Encrypted and Needed
            if (ACT_Status.EncryptConfigFile)
            {
                if (ACT_Status.SysConfigEncFileLocation.FileExists() == false)
                {
                    // Search For Encrypted File
                    ACT_Status.SysConfigEncFileLocation = ACT_Status.ResourcesDirectory.FindFileReturnPath("SystemConfiguration.enc", true);
                    if (ACT_Status.SysConfigEncFileLocation == "")
                    {
                        var ex = new FileNotFoundException("The Encryption File Was Not Found and is Required By the Settings INI");
                        _.LogFatalError("SystemConfiguration Encrypted File Not Found", ex);
                        throw ex;
                    }
                }
                return LoadConfigurationFile(false);
            }
            else
            {
                if (ACT_Status.SysConfigFileLocation.FileExists() == false)
                    // Search For SystemConfiguratioin File
                    ACT_Status.SysConfigFileLocation = ACT_Status.ResourcesDirectory.FindFileReturnPath("SystemConfiguration.json", true);
                if (ACT_Status.SysConfigFileLocation == "")
                {
                    var ex = new FileNotFoundException("The UnEncrypted SysConfig File Was Not Found.");
                    _.LogFatalError("The UnEncrypted SysConfig File Was Not Found.", ex);
                    throw ex;
                }
            }
            return LoadConfigurationFile(true);
        }

        /// <summary>
        /// Load the Configuration File As Defined and Found
        /// </summary>
        /// <param name="IsEncrypted">True if Using Encrypted Path Or Not</param>
        /// <returns>true/false if Success</returns>
        internal static bool LoadConfigurationFile(bool IsEncrypted)
        {
            if (ACT_Status.EncryptConfigFile == true && IsEncrypted == false) { ProtectConfigurationFile(); }
            

            if (IsEncrypted)
            {

            }
            else
            {
                try
                {
                    Primary_Loaded_SystemConfigurationFile = SystemConfiguration.FromJson(ACT_Status.SysConfigFileLocation.ReadAllText());
                    return true;
                }
                catch
                {
                    var _ex = new ApplicationException("Critical Data Error");
                    _.LogFatalError("Error Loading Primary Config File: " + ACT_Status.SysConfigFileLocation, _ex);
                    throw _ex;
                }
            }
        }

        // Uses Microsoft Protection Machine Level To Protect Data
        internal static bool ProtectConfigurationFile()
        {
            string _Data = "";
            _Data = ACT_Status.SysConfigFileLocation.ReadAllText().FromBase64();

            var _ProtectedData = _Data.ProtectByMachine();

            if (_ProtectedData.NullOrEmpty()) 
            {
                _.LogFatalError("ACT.Core.Security.ProtectByMachine Unable To Protect  the Data: " + _ProtectedData, new Exception("Unable To Encrypt File"));
                return false; 
            }

            try
            {
                File.WriteAllText(ACT_Status.SysConfigEncFileLocation, _ProtectedData, System.Text.Encoding.Default);
            }
            catch (Exception ex)
            {
                _.LogFatalError("Unable To Create Encrypted File", ex);
                throw;
            }

            if (ACT_Status.SysConfigFileLocation.FileExists())
            {
                try { ACT_Status.SysConfigFileLocation.DeleteFile(50, true); }
                catch (Exception ex)
                {
                    _.LogFatalError("Unable To Delete The Unencrypted ConfigurationFile", ex);
                    throw;
                }
            }

            return true;
        }

        #endregion




        /// <summary>
        /// Search For Sensitive Files and Auto Encrypt Them
        /// </summary>
        /// <returns></returns>
        public List<string> DetectSensitiveFiles(List<string> CustomKeywords)
        {
            if (SettingsLoaded == false) { throw new Exception("Settings Not Loaded"); }

            var _Keywords = Primary_Loaded_SystemConfigurationFile.ComplexSettings.First(x => x.GroupName.ToLower() == "system" && x.Name.ToLower() == "sensitivefiles").Values;
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

            if (Primary_Loaded_SystemConfigurationFile.BasicSettings.Exists(x => x.Name == Name))
            {
                return Primary_Loaded_SystemConfigurationFile.BasicSettings.First(x => x.Name == Name).Value;
            }
            else if (Primary_Loaded_SystemConfigurationFile.ComplexSettings.Exists(x => x.Name == Name))
            {
                return Primary_Loaded_SystemConfigurationFile.ComplexSettings.First(x => x.Name == Name).Value;
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

            if (Name == "default") { return Primary_Loaded_SystemConfigurationFile; }
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
