using ACT.Core.Enums;

namespace ACT.Core
{
    public static class ACTConfig
    {
        internal static SystemSettings ConfigSettings = new SystemSettings();

        /// <summary>
        /// Loads and Encrypts the configuration file.
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="IsEncrypted"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool LoadConfigurationFile(string Path, bool IsEncrypted, string configType = "default")
        {
            return ConfigSettings.LoadConfigurationFile(Path, IsEncrypted, configType);
        }

        /// <summary>
        /// Load the Encryption Key
        /// </summary>
        internal static System.Security.SecureString Default_EncryptionKey
        {
            get { return ConfigSettings.Default_EncryptionKey; }
        }

        /// <summary>
        /// Load a secondary or seperate key
        /// </summary>
        /// <param name="Identifier"></param>
        /// <returns></returns>
        public static bool LoadEncryptionKey(string Identifier)
        {
            return ConfigSettings.LoadEncryptionKey(Identifier);
        }

        /// <summary>
        /// Search For Sensitive Files and Auto Encrypt Them
        /// </summary>
        /// <returns></returns>
        public static List<string> DetectSensitiveFiles(List<string> CustomKeywords)
        {
            return ConfigSettings.DetectSensitiveFiles(CustomKeywords);
        }

        /// <summary>
        /// Search For a Specific Setting
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="SectionsToSearch"></param>
        /// <returns></returns>
        public static string GetSettingByName(string Name, SystemSettingsSections SectionsToSearch = (SystemSettingsSections.Basic | SystemSettingsSections.Complex))
        {
            return ConfigSettings.GetSettingByName(Name, SectionsToSearch);
        }

        /// <summary>
        /// Gets Active Config
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static Structs.SystemSettingsData GetAndSet_ActiveConfig(string Name = "default")
        {
            return ConfigSettings.GetAndSet_ActiveConfig(Name);
        }

    }

}
