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
        public static bool EncryptConfigFile = false;
        public static bool VerboseDebugging = false;
        #endregion

        #region Critical Files
        public static bool SystemConfigurationFile_Loaded = false;
        #endregion

        private static bool _ACT_Needs_Saving = false;
        private static bool _ACT_Core_Ready = false; 
        
        public static bool SettingsNeedSaving { get { return _ACT_Needs_Saving; } internal set { _ACT_Needs_Saving = value; } }
        public static bool ACT_Core_Ready { get { if (_ACT_Core_Ready && SystemSettings.Primary_Loaded_SystemConfigurationFile != null) { return true; } else { return false; } } internal set { _ACT_Core_Ready = value; } }


        

    }
}
