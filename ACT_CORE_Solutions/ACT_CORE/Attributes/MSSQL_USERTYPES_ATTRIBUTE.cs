using ACT.Core.ACT_Types.Attribute_Support;

namespace ACT.Core.Attributes
{
    [AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]

    public class MSSQL_USERTYPES_ATTRIBUTE : Attribute
    {
        public string UserTypeName;
        public string FullClassName;
        public string MinMSSQLVersion;
        public string Comments;
    }
}
