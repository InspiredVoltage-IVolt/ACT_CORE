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


    }

}
