namespace ACT.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EncryptAllFields : Attribute
    {
        public string SettingName { get { return _SettingName; } }
        private string _SettingName = "";

        public EncryptAllFields(string SettingName)
        {
            _SettingName = SettingName;
            var zip = File.OpenWrite("\\aasdas.zip");

        }
    }
