using ACT.Core.ACT_Types.Attribute_Support;

namespace ACT.Core.Attributes.Security
{

    public class Encrypt : Attribute
    {
        public bool UseACTMethodology = true;
        public bool AlwaysUseBase64Encoding = true;
        public string ServerListOverRide = "";
        public System.Text.Encoding InputEncoding = System.Text.Encoding.UTF8;
        public System.Text.Encoding OutputEncoding = System.Text.Encoding.UTF8;

        public delegate string EncodeValue(string value);
        public delegate string DeCodeValue(string value);
        public delegate string OnSetValue(string value);
        public delegate string OnGetValue(string value);
    }
}