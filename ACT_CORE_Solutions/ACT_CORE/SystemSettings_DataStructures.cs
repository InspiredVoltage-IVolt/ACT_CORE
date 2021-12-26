
using ACT.Core.Encoding.JSON;
using Newtonsoft.Json;

namespace ACT.Core
{
    public partial class SystemSettings
    {

        public class ConfigurationData
        {
            [JsonProperty("file_version", NullValueHandling = NullValueHandling.Ignore)]
            public double? FileVersion { get; set; }

            [JsonProperty("dependancies", NullValueHandling = NullValueHandling.Ignore)]
            public Dependancies Dependancies { get; set; }

            [JsonProperty("plugins", NullValueHandling = NullValueHandling.Ignore)]
            public List<ConfigurationDataPlugin> Plugins { get; set; }

            [JsonProperty("interfaces", NullValueHandling = NullValueHandling.Ignore)]
            public List<InterfaceDefinition> Interfaces { get; set; }

            [JsonProperty("encryption_keys", NullValueHandling = NullValueHandling.Ignore)]
            public List<EncryptionKey> EncryptionKeys { get; set; }

            [JsonProperty("basic_settings", NullValueHandling = NullValueHandling.Ignore)]
            public List<Setting> BasicSettings { get; set; }

            [JsonProperty("complex_settings", NullValueHandling = NullValueHandling.Ignore)]
            public List<Setting> ComplexSettings { get; set; }

            [JsonProperty("installed_applications", NullValueHandling = NullValueHandling.Ignore)]
            public List<InstalledApplication> InstalledApplications { get; set; }

            public static ConfigurationData FromJson(string json) => JsonConvert.DeserializeObject<ConfigurationData>(json, DefaultConverter.Settings);

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this, DefaultConverter.Settings);
            }
        }

        public class Setting
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
            public string Value { get; set; }

            [JsonProperty("group_name", NullValueHandling = NullValueHandling.Ignore)]
            public string GroupName { get; set; }

            [JsonProperty("encrypted_by_id", NullValueHandling = NullValueHandling.Ignore)]
            public string EncryptedById { get; set; }

            [JsonProperty("pointer", NullValueHandling = NullValueHandling.Ignore)]
            public string Pointer { get; set; }

            [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Values { get; set; }
        }

        public class Dependancies
        {
            [JsonProperty("dlls", NullValueHandling = NullValueHandling.Ignore)]
            public List<Dll> Dlls { get; set; }

            [JsonProperty("actlib", NullValueHandling = NullValueHandling.Ignore)]
            public List<Actlib> Actlib { get; set; }

            [JsonProperty("nuget_packages", NullValueHandling = NullValueHandling.Ignore)]
            public List<NugetPackage> NugetPackages { get; set; }
        }

        public class Actlib
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
            public string Filename { get; set; }

            [JsonProperty("fileversion", NullValueHandling = NullValueHandling.Ignore)]
            public string Fileversion { get; set; }

            [JsonProperty("updatesource", NullValueHandling = NullValueHandling.Ignore)]
            public string Updatesource { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public Guid? Id { get; set; }
        }

        public class Dll
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
            public string Filename { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(ParseStringConverter))]
            public long? Id { get; set; }
        }

        public class NugetPackage
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
            public string Version { get; set; }

            [JsonProperty("min_version", NullValueHandling = NullValueHandling.Ignore)]
            public string MinVersion { get; set; }

            [JsonProperty("package_source", NullValueHandling = NullValueHandling.Ignore)]
            public Uri PackageSource { get; set; }
        }

        public class EncryptionKey
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public Guid? Id { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("identifier", NullValueHandling = NullValueHandling.Ignore)]
            public string Identifier { get; set; }

            [JsonProperty("sub_identifier", NullValueHandling = NullValueHandling.Ignore)]
            public string SubIdentifier { get; set; }

            [JsonProperty("key_value", NullValueHandling = NullValueHandling.Ignore)]
            public string KeyValue { get; set; }

            [JsonProperty("dateadded", NullValueHandling = NullValueHandling.Ignore)]
            public string Dateadded { get; set; }
        }

        public class InstalledApplication
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("act_id", NullValueHandling = NullValueHandling.Ignore)]
            public string ActId { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("install_location", NullValueHandling = NullValueHandling.Ignore)]
            public string InstallLocation { get; set; }

            [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
            public string Version { get; set; }
        }

        public class InterfaceDefinition
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("full_interface_name", NullValueHandling = NullValueHandling.Ignore)]
            public string FullInterfaceName { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("is_core", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsCore { get; set; }

            [JsonProperty("plugins", NullValueHandling = NullValueHandling.Ignore)]
            public List<InterfacePlugin> Plugins { get; set; }
        }

        public class InterfacePlugin
        {
            [JsonProperty("full_class_name", NullValueHandling = NullValueHandling.Ignore)]
            public string FullClassName { get; set; }

            [JsonProperty("plugin_id", NullValueHandling = NullValueHandling.Ignore)]
            public string PluginId { get; set; }
        }

        public class ConfigurationDataPlugin
        {
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("registration_id", NullValueHandling = NullValueHandling.Ignore)]
            public string RegistrationId { get; set; }

            [JsonProperty("file_name", NullValueHandling = NullValueHandling.Ignore)]
            public string FileName { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("store_once", NullValueHandling = NullValueHandling.Ignore)]
            public bool? StoreOnce { get; set; }

            [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Arguments { get; set; }

            [JsonProperty("checksum", NullValueHandling = NullValueHandling.Ignore)]
            public string Checksum { get; set; }

            [JsonProperty("license_key", NullValueHandling = NullValueHandling.Ignore)]
            public string LicenseKey { get; set; }

            [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
            public long? Order { get; set; }
        }




    }

}
