using ACT.Core.ACT_Types.Attribute_Support;

namespace ACT.Core.Attributes
{
    [AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    [DEV(ToDo = true, ToDo_Description = "Add JSON Enum ACT.Core.Enums.Database.JSON.JSON_MSSQL_TYPES", Priority = 20)]
    public class MSSQL_USERTYPES_ATTRIBUTE : Attribute
    {
        public string UserTypeName;
        public string FullClassName;
        public string MinMSSQLVersion;
        public string Comments;

    }
}
