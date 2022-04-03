/*
    Version 
        1.2
    Author
        Mark ALicz
    TODO 
        Dependancy Normalization
        Web Service Integration
        Security
        ...
 */
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ACT.Core
{

    public class SystemConfiguration
    {
        [JsonProperty("file_version", NullValueHandling = NullValueHandling.Ignore)]
        public double? FileVersion { get; set; }

        [JsonProperty("optional_custom_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("installation_info", NullValueHandling = NullValueHandling.Ignore)]
        public InstallationInfo InstallationInfo { get; set; }

        [JsonProperty("authentication_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthenticationMode { get; set; }

        [JsonProperty("config_purpose", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfigPurpose { get; set; }

        [JsonProperty("nuget_sources", NullValueHandling = NullValueHandling.Ignore)]
        public List<NugetSource> NugetSources { get; set; }

        [JsonProperty("nuget_packages", NullValueHandling = NullValueHandling.Ignore)]
        public List<NugetPackage> NugetPackages { get; set; }

        [JsonProperty("included_dependancies", NullValueHandling = NullValueHandling.Ignore)]
        public List<IncludedDependancy> IncludedDependancies { get; set; }

        [JsonProperty("act_interfaces", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActInterface> ActInterfaces { get; set; }

        [JsonProperty("plugins", NullValueHandling = NullValueHandling.Ignore)]
        public List<SystemConfigurationPlugin> Plugins { get; set; }

        [JsonProperty("basic_settings", NullValueHandling = NullValueHandling.Ignore)]
        public List<BasicSetting> BasicSettings { get; set; }

        [JsonProperty("complex_settings", NullValueHandling = NullValueHandling.Ignore)]
        public List<ComplexSetting> ComplexSettings { get; set; }

        [JsonProperty("installed_applications", NullValueHandling = NullValueHandling.Ignore)]
        public List<InstalledApplication> InstalledApplications { get; set; }

        public static SystemConfiguration FromJson(string json) => JsonConvert.DeserializeObject<SystemConfiguration>(json, Encoding.JSON.DefaultConverter.Settings);

        public string ToJson() => JsonConvert.SerializeObject(this, Encoding.JSON.DefaultConverter.Settings);

    }

    public partial class ActInterface
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("full_class_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullClassName { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("is_core", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCore { get; set; }

        [JsonProperty("date_added", NullValueHandling = NullValueHandling.Ignore)]
        public string DateAdded { get; set; }

        [JsonProperty("plugins", NullValueHandling = NullValueHandling.Ignore)]
        public List<ActInterfacePlugin> Plugins { get; set; }
    }

    public partial class ActInterfacePlugin
    {
        [JsonProperty("full_class_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullClassName { get; set; }

        [JsonProperty("plugin_ID", NullValueHandling = NullValueHandling.Ignore)]
        public string PluginId { get; set; }

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }

        [JsonProperty("date_added", NullValueHandling = NullValueHandling.Ignore)]
        public string DateAdded { get; set; }

        [JsonProperty("usage_override", NullValueHandling = NullValueHandling.Ignore)]
        public string UsageOverride { get; set; }
    }

    public partial class BasicSetting
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("group_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupName { get; set; }

        [JsonProperty("encrypted", NullValueHandling = NullValueHandling.Ignore)]
        public string Encrypted { get; set; }

        [JsonProperty("pointer", NullValueHandling = NullValueHandling.Ignore)]
        public string Pointer { get; set; }
    }

    public partial class ComplexSetting
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("group_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupName { get; set; }

        [JsonProperty("encrypted", NullValueHandling = NullValueHandling.Ignore)]
        public string Encrypted { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Values { get; set; }
    }

    public partial class IncludedDependancy
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }
    }

    public partial class InstallationInfo
    {
        [JsonProperty("install_path", NullValueHandling = NullValueHandling.Ignore)]
        public string InstallPath { get; set; }

        [JsonProperty("application_install_path", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationInstallPath { get; set; }

        [JsonProperty("license_key", NullValueHandling = NullValueHandling.Ignore)]
        public string LicenseKey { get; set; }

        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }

        [JsonProperty("order_date", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderDate { get; set; }

        [JsonProperty("permission_file_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PermissionFilePath { get; set; }

        [JsonProperty("installed_version", NullValueHandling = NullValueHandling.Ignore)]
        public string InstalledVersion { get; set; }

        [JsonProperty("installed_by", NullValueHandling = NullValueHandling.Ignore)]
        public string InstalledBy { get; set; }
    }

    public partial class InstalledApplication
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("install_location", NullValueHandling = NullValueHandling.Ignore)]
        public string InstallLocation { get; set; }
    }

    public partial class NugetPackage
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("exact_version", NullValueHandling = NullValueHandling.Ignore)]
        public string ExactVersion { get; set; }

        [JsonProperty("auto_version_upgrade", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoVersionUpgrade { get; set; }

        [JsonProperty("package_source_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PackageSourceId { get; set; }
    }

    public partial class NugetSource
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("requires_apikey", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequiresApikey { get; set; }

        [JsonProperty("web_management_url", NullValueHandling = NullValueHandling.Ignore)]
        public string WebManagementUrl { get; set; }

        [JsonProperty("login_source", NullValueHandling = NullValueHandling.Ignore)]
        public string LoginSource { get; set; }
    }

    public partial class SystemConfigurationPlugin
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

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

        [JsonProperty("interface_support", NullValueHandling = NullValueHandling.Ignore)]
        public List<InterfaceSupport> InterfaceSupport { get; set; }
    }

    public partial class InterfaceSupport
    {
        [JsonProperty("interface_id", NullValueHandling = NullValueHandling.Ignore)]
        public string InterfaceId { get; set; }

        [JsonProperty("full_class_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullClassName { get; set; }
    }

}
