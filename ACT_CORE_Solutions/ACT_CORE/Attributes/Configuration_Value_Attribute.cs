namespace ACT.Core.Attributes
{
    public class Configuration_Value_Attribute : Attribute
    {
        Configuration_Value_Attribute() { }

        public Enums.SystemSettingsSections ValueSection { get; set; }
        public string ConfigurationName { get; set; }
        public string GroupName { get; set; }
        public string IsValueArray { get; set; }

        List<string> RetrievedValues { get; set; } = new List<string>();
        string RetrievedValue { get; set; } = "";
    }
}
