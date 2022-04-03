using ACT.Core.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Core
{
    public static class ACT_Status
    {
        public static void CHECKREADY(string METHOD = "")
        {
            var _ex = new ApplicationException(" - WAS RAN BEFORE ACT WAS LOADED");
            _.LogFatalError(_ex + " : CHECK LOGS", _ex);
            throw _ex;
        }

        #region Critical Classes
        #region Public Configuration Variables

        public static SystemConfiguration Primary_Loaded_SystemConfigurationFile = null;
        public static Dictionary<string, SystemConfiguration> _AdditionalLoadedConfiguration = new Dictionary<string, SystemConfiguration>();

        #endregion
        #endregion

        #region Directories
        public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat();
        public static string ResourcesDirectory = BaseDirectory.EnsureDirectoryFormat() + "Resources\\";
        public static string AssetsDirectory = ResourcesDirectory + "Assets\\";
        public static string CheatSheetsDirectory = ResourcesDirectory + "Assets\\CheatSheets\\";
        public static string IconsDirectory = ResourcesDirectory + "Assets\\Icons\\";
        public static string LogsDirectory = ResourcesDirectory + "Logs\\";
        public static string LicenceFilePath = ResourcesDirectory + "Licenses\\";
        #endregion

        #region File Paths
        public static string LicenceFileFileLocation = LicenceFilePath + "Lic.enc";
        public static string SettingsINIFileLocation = ResourcesDirectory + "Settings.ini";
        public static string SysConfigFileLocation = ResourcesDirectory + "SystemConfiguration.json";
        public static string SysConfigEncFileLocation = ResourcesDirectory + "SystemConfiguration.enc";
        #endregion

        #region INIFILE SETTINGS
        public static bool MissingIniFile = true;

        public static bool EncryptConfigFile = false;
        public static bool EnableAutoEncryptSensitiveSettings = false;
        public static bool KeepPlaintextConfigfile = true;
        public static bool AutoSaveChangedSystemConfigurationChanges = true;

        public static bool VerboseDebugging = false;
        public static int MainTimerInterval = 10000;
        public static List<string> AdditionalSensitiveKeywords = new List<string>();

        #endregion

        #region SYSTEM READY CHECKS
        private static bool _SystemConfigurationFileChanged = false;
        private static bool _ACT_Core_Ready = false;


        public static bool SystemConfigurationFile_Loaded
        {
            get
            {
                if (ACT_Core_Ready && Primary_Loaded_SystemConfigurationFile.FileVersion != null) { return true; }
                else { return false; }
            }
        }
        public static bool SystemConfigurationFileChanged
        {
            get { return _SystemConfigurationFileChanged; }
            internal set { _SystemConfigurationFileChanged = value; }

        }
        public static bool ACT_Core_Ready
        {
            get
            {
                if (_ACT_Core_Ready && ACT_Status.Primary_Loaded_SystemConfigurationFile != null) { return true; }
                else { return false; }
            }
            internal set { _ACT_Core_Ready = value; }
        }
        #endregion

        #region ACT - CLASS-PROPERTY Change Management

        private static List<(string, object)> _CurrentChanges = new List<(string, object)>();

        internal static bool AddChange(string Property, object ClassChanged)
        {
            (string, object) _item = new(Property, ClassChanged);

            if (_CurrentChanges.Contains(_item) == false) { _CurrentChanges.Add(_item); return true; }
            else { return false; }
        }
        internal static void RemoveChange(string Property, object ClassChanged)
        {
            (string, object) _item = new(Property, ClassChanged);

            if (_CurrentChanges.Contains(_item) == false) { return; }
            else { _CurrentChanges.Remove(_item); return; }
        }
        internal static List<(string, object)> CurrentChanges { get { return _CurrentChanges; } }

        public static List<(string, object)> GetChangedItemsForDelegate { get { return CurrentChanges; } }

        #endregion


    }
}
