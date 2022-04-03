using System.Linq;
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
        #region Events
        public static event Delegate.OnChanged AddSystemTimerCheck;
        #endregion

        #region MAIN SYSTEM TIMER

        static System.Timers.Timer ChangeManagementTimer;

        private static void ChangeManagementTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ACT_Status.ACT_Core_Ready == false) { ACT_Status.CHECKREADY("ChangeManagementTimer_Elapsed");}

            ChangeManagementTimer.Stop();

            if (ACT_Status.SystemConfigurationFileChanged)
            {
                if (ACT_Status.AutoSaveChangedSystemConfigurationChanges)
                {
                    string _NewJSON = "";
                    lock (ACT_Status.Primary_Loaded_SystemConfigurationFile)
                    {
                        _NewJSON = ACT_Status.Primary_Loaded_SystemConfigurationFile.ToJson();
                    }
                    if (ACT_Status.EncryptConfigFile)
                    {
                        string _EncNewJSON = _NewJSON.ProtectByMachine();
                        _EncNewJSON.SaveAllText(ACT_Status.SysConfigEncFileLocation);

                        if (ACT_Status.KeepPlaintextConfigfile)
                        {
                            _NewJSON.SaveAllText(ACT_Status.SysConfigFileLocation);
                        }
                    }

                }
            }

            if (AddSystemTimerCheck != null)
            {
                foreach(Delegate.OnChanged _EventToHandle in AddSystemTimerCheck.GetInvocationList())
                {
                    _EventToHandle(ACT_Status.GetChangedItemsForDelegate);
                }
            }

            ChangeManagementTimer.Start();
        }

        #endregion

        /// <summary>
        /// Static Constructor (Runs First Always)
        /// </summary>
        static SystemSettings()
        {
            #region Load Settings.ini File
            if (!ACT_Status.SettingsINIFileLocation.FileExists())
            {
                _.LogBasicInfo("MISSING INI FILE AT: " + ACT_Status.SettingsINIFileLocation);
                ACT_Status.MissingIniFile = true;
            }
            else
            {
                ACT_Status.MissingIniFile = false;
                LoadIniFile();
            }
            #endregion

            #region Config File Checks
            ValidateSystemConfigFileLocations();
            #endregion

            #region Load Configuration File
            ACT_Status.ACT_Core_Ready = ProcessFirstStartup();

            if (ACT_Status.ACT_Core_Ready == false)
            {
                Exception _FatalFinal = new ApplicationException("ACT CORE SYSTEM FAILED TO START");
                _.LogFatalError(_FatalFinal.Message + " __ CHECK LOGS FOR MORE INFO ", _FatalFinal);
                throw _FatalFinal;
            }
            #endregion

            #region Configure Main System Timer
            ChangeManagementTimer = new System.Timers.Timer(ACT_Status.MainTimerInterval);
            ChangeManagementTimer.Elapsed += ChangeManagementTimer_Elapsed;
            ChangeManagementTimer.Start();
            #endregion
        }


        #region Methods

        /// <summary>
        /// Validate Location of Plain Text And/Or Encrypted File Location Based on INI Settings
        /// </summary>
        internal static void ValidateSystemConfigFileLocations()
        {
            bool _ConfigCriticalError = false;
            if (!ACT_Status.SysConfigFileLocation.FileExists())
            {
                ACT_Status.SysConfigFileLocation = ACT_Status.ResourcesDirectory.FindFileReturnPath("SystemConfiguration.json", true);
            }

            if (!ACT_Status.SysConfigEncFileLocation.FileExists())
            {
                ACT_Status.SysConfigEncFileLocation = ACT_Status.ResourcesDirectory.FindFileReturnPath("SystemConfiguration.enc", true);
            }

            if (ACT_Status.EncryptConfigFile == false)
            {
                if (ACT_Status.SysConfigFileLocation.NullOrEmpty()) { _ConfigCriticalError = true; }
            }
            else
            {
                if (ACT_Status.SysConfigFileLocation.NullOrEmpty() && ACT_Status.SysConfigEncFileLocation.NullOrEmpty()) { _ConfigCriticalError = true; }
            }

            if (_ConfigCriticalError)
            {
                ACT_Status.ACT_Core_Ready = false;
                var _EX = new FileNotFoundException("SystemConfiguration Not Found");
                _.LogFatalError("Unable To Locate System Configuration Anywhere under or in the base directory.", _EX);
                throw _EX;
            }

        }

        /// <summary>
        /// Loads the INI File Settings
        /// </summary>
        internal static void LoadIniFile()
        {
            try
            {
                ACT.Core.Managers.ini_File_Manager _IniManager = new Managers.ini_File_Manager(ACT_Status.SettingsINIFileLocation);

                // SECTION configurationfile
                ACT_Status.EncryptConfigFile = _IniManager.GetValue("encryptconfigfile", "configurationfile").ToBool(false);
                ACT_Status.KeepPlaintextConfigfile = _IniManager.GetValue("KeepPlainTextConfigfile", "configurationfile").ToBool(true);
                ACT_Status.EnableAutoEncryptSensitiveSettings = _IniManager.GetValue("enableautoencryptsensitivesettings", "configurationfile").ToBool(false);
                
                // ARRAY BAR SEPERATED STRINGS
                string _TmpAdditionalKeywords = _IniManager.GetValue("additionalsensitivekeywords", "configurationfile");
                if (_TmpAdditionalKeywords.NullOrEmpty() == false)
                {
                    if (_TmpAdditionalKeywords.Contains("|"))
                    {
                        foreach (string keyword in _TmpAdditionalKeywords.SplitString("|", StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (ACT_Status.AdditionalSensitiveKeywords.Contains(keyword)) { continue; }
                            ACT_Status.AdditionalSensitiveKeywords.Add(keyword);
                        }
                    }
                    else
                    {
                        ACT_Status.AdditionalSensitiveKeywords.Add(_TmpAdditionalKeywords);
                    }
                }

                // SECTION actbasicsettings
                ACT_Status.VerboseDebugging = _IniManager.GetValue("verboselogging", "actbasicsettings").ToBool(false);
                ACT_Status.MainTimerInterval = _IniManager.GetValue("maintimerinterval", "actbasicsettings").ToInt(10000);
                ACT_Status.AutoSaveChangedSystemConfigurationChanges = _IniManager.GetValue("autosavechangedsystemconfigurationchanges", "actbasicsettings").ToBool(false);
            }
            catch (Exception ex)
            {
                ACT_Status.MissingIniFile = true;
                _.LogBasicInfo("Error Loading INI File, using Defaults." + ex.Message);
            }
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
        private static bool ProcessFirstStartup()
        {
            // Check If Config Is Encrypted and Needed
            if (ACT_Status.EncryptConfigFile)
            {
                if (ACT_Status.SysConfigEncFileLocation.NullOrEmpty() == true)
                {
                    return LoadDefaultConfigurationFile(false);
                }
                else
                {
                    return LoadDefaultConfigurationFile(true);
                }
            }
            else
            {
                if (ACT_Status.SysConfigFileLocation.NullOrEmpty() == false)
                {
                    return LoadDefaultConfigurationFile(false);
                }
                else
                {
                    var ex = new FileNotFoundException("The UnEncrypted SysConfig File Was Not Found.");
                    _.LogFatalError("The UnEncrypted SysConfig File Was Not Found.", ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Load the Configuration File As Defined and Found
        /// </summary>
        /// <param name="EncryptedFileExists">True if Using Encrypted Path Or Not</param>
        /// <returns>true/false if Success</returns>
        internal static bool LoadDefaultConfigurationFile(bool EncryptedFileExists)
        {
            if (ACT_Status.EncryptConfigFile == true && EncryptedFileExists == false) { ProtectConfigurationFile(); }

            if (EncryptedFileExists)
            {
                try
                {
                    var _EncData = ACT_Status.SysConfigEncFileLocation.ReadAllText();
                    var _Data = Protection.UnProtectByMachine(_EncData);
                    ACT_Status.Primary_Loaded_SystemConfigurationFile = SystemConfiguration.FromJson(_Data);
                    return true;
                }
                catch
                {
                    var _ex = new ApplicationException("Critical Encrypted Data Error");
                    _.LogFatalError("Error Loading Primary Encrypted Config File: " + ACT_Status.SysConfigEncFileLocation, _ex);
                    throw _ex;
                }
            }
            else
            {
                try
                {
                    ACT_Status.Primary_Loaded_SystemConfigurationFile = SystemConfiguration.FromJson(ACT_Status.SysConfigFileLocation.ReadAllText());
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

        /// <summary>
        /// Uses Microsoft Protection Machine Level To Protect Data
        /// </summary>
        /// <returns>True If It Worked, False If Something Broke</returns>
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

        [DEV(ToDo = true, Priority = 10, ToDo_Description = "Check All Settings For Sensitive Data")]
        /// <summary>
        /// Search For Sensitive Files and Auto Encrypt Them
        /// </summary>
        /// <returns>Count Of Items Found</returns>
        internal static int AutoEncryptSensitiveFiles(bool AutoUpdateFile = true, List<string> CustomKeywords = null)
        {
            if (ACT_Status.ACT_Core_Ready == false) { ACT_Status.CHECKREADY("AutoEncryptSensitiveFiles"); }

            List<string> _Keywords = new List<string>();
            if (ACT_Status.AdditionalSensitiveKeywords!= null) { _Keywords.AddRange(ACT_Status.AdditionalSensitiveKeywords); }


            return -1;           
        }

        /// <summary>
        /// Search All Settings For a Setting Wtith a Name
        /// </summary>
        /// <param name="Name">Name OF Property</param>
        /// <param name="SectionsToSearch">One Or More Types Of Sections To Search</param>
        /// <returns>String or Delimited String if Complex Item Is Foound, Null IF NOT FOUND</returns>
        internal static string GetSettingByName(string Name, SystemSettingsSections SectionsToSearch = (SystemSettingsSections.Basic | SystemSettingsSections.Complex))
        {
            if (ACT_Status.ACT_Core_Ready == false) { ACT_Status.CHECKREADY("GetSettingByName"); }
            
            if (ACT_Status.Primary_Loaded_SystemConfigurationFile.BasicSettings.Exists(x => x.Name == Name))
            {
                return ACT_Status.Primary_Loaded_SystemConfigurationFile.BasicSettings.First(x => x.Name == Name).Value;
            }
            else if (ACT_Status.Primary_Loaded_SystemConfigurationFile.ComplexSettings.Exists(x => x.Name == Name))
            {
                return ACT_Status.Primary_Loaded_SystemConfigurationFile.ComplexSettings.First(x => x.Name == Name).Values.ToDelimitedString("###");
            }
            return null;
        }

        [DEV(ToDo = true, Priority = 10, ToDo_Description = "Code this Shit")]
        /// <summary>
        /// Gets Active Config
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static void ChangePrimaryLoadedSystemConfiguration(string Name = "")
        {
            if (ACT_Status.ACT_Core_Ready == false) { ACT_Status.CHECKREADY("ChangePrimaryLoadedSystemConfiguration"); }

            if (Name.NullOrEmpty()) { return; }
            
            string _Current = ACT_Status.Primary_Loaded_SystemConfigurationFile.Name;
            if (_Current == Name) { return; }
            else
            {
                return;
            }
        } 
        
        #endregion
    }
}
