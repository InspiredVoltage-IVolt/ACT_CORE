namespace ACT.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Encrypt : Attribute
    {
        public string SettingName { get { return _SettingName; } }
        private string _SettingName = "";

        public Encrypt(string SettingName)
        {
            _SettingName = SettingName;
        }
    }
}
