namespace ACT.Core.Attributes
{
    public class Localization : Attribute
    {
        public string CultureName { get; set; } = "en-us";
        /// <summary>
        /// Fallback Culture - Language for missing translations
        /// </summary>
        public string DefaultCultureForMissingTranslations { get; set; } = "en-us";
        /// <summary>
        /// Enable Cache
        /// </summary>
        public bool EnableCache { get; set; } = true;

        /// <summary>
        /// Blank uses the built in cache engine
        /// </summary>
        public string CachePluginID { get; set; } = "";

        /// <summary>
        /// Amount of time to clear unused cache items.
        /// </summary>
        public int CacheClenseTimeInSeconds { get; set; } = 86400;

        /// <summary>
        /// Amount of time to clear complete cache.
        /// </summary>
        public int CompleteCacheClenseTimeInSeconds { get; set; } = 864000;

        /// <summary>
        /// Max Growth Size. in Bytes
        /// </summary>
        public int CacheMaxSizeInBytes { get; set; } = 104857600;
    }
}
