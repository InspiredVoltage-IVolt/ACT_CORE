using ACT.Core.Structs.Attribute_Support;

namespace ACT
{
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class DEV : Attribute
    {
        private bool _ToDo = false;
        private string _ToDo_Description = "";
        private bool _RemoveBeforeRelease = false;
        private string _RemoveBeforeRelease_Description = "";
        private int _Priority = 0;
        private string _OriginaDeveloperInfo = "";
        private string _LastDeveloperInfo = "";

        public DEV() { }


        public bool ToDo { get { return _ToDo; } set { _ToDo = value; } }
        public string ToDo_Description { get { return _ToDo_Description; } set { _ToDo_Description = value; } }
        public bool RemoveBeforeRelease { get { return _RemoveBeforeRelease; } set { _RemoveBeforeRelease = value; } }
        public string RemoveBeforeRelease_Description { get { return _RemoveBeforeRelease_Description; } set { _RemoveBeforeRelease_Description = value; } }
        public int Priority { get { return _Priority; } set { _Priority = value; } }
        // string i.e "Mark Alicz, Darkbit@gmail.com"
        public string OriginaDeveloperInfo { get { return _OriginaDeveloperInfo; } set { _OriginaDeveloperInfo = value; } }
        // string i.e "John Prine, JohnPrineForever@goofmail.com"
        public string LastDeveloperInfo { get { return _LastDeveloperInfo; } set { _LastDeveloperInfo = value; } }

        public static Attribute_Single_Development_Definition ToDevelopmentDefinition(DEV devInstance, string ClassName, string TypeName)
        {
            Attribute_Single_Development_Definition _tmpReturn = new Attribute_Single_Development_Definition();

            _tmpReturn.classname = ClassName;
            _tmpReturn.typename = TypeName;
            _tmpReturn.todo = devInstance.ToDo.ToString();
            _tmpReturn.todo_description = devInstance.ToDo_Description.ToString();
            _tmpReturn.removebeforerelease = devInstance.RemoveBeforeRelease.ToString();
            _tmpReturn.removebeforerelease_description = devInstance.RemoveBeforeRelease_Description.ToString();
            _tmpReturn.priority = devInstance.Priority;
            _tmpReturn.originadeveloperinfo = devInstance.OriginaDeveloperInfo.ToString();
            _tmpReturn.lastdeveloperinfo = devInstance.LastDeveloperInfo.ToString();

            return _tmpReturn;
        }

        public static string ToJSON(DEV devInstance, string ClassName, string TypeName)
        {
            string TmpReturn = "{" + Environment.NewLine;

            TmpReturn += "\"classname\":\"" + ClassName + "\"" + Environment.NewLine;
            TmpReturn += "\"typename\":\"" + TypeName + "\"" + Environment.NewLine;
            TmpReturn += "\"todo\":\"" + devInstance.ToDo.ToString() + "\"" + Environment.NewLine;
            TmpReturn += "\"todo_description\":\"" + devInstance.ToDo_Description.ToString() + "\"" + Environment.NewLine;
            TmpReturn += "\"removebeforerelease\":\"" + devInstance.RemoveBeforeRelease.ToString() + "\"" + Environment.NewLine;
            TmpReturn += "\"removebeforerelease_description\":\"" + devInstance.RemoveBeforeRelease_Description.ToString() + "\"" + Environment.NewLine;
            TmpReturn += "\"priority\":\"" + devInstance.Priority.ToString() + "\"" + Environment.NewLine;
            TmpReturn += "\"originadeveloperinfo\":\"" + devInstance.OriginaDeveloperInfo.ToString() + "\"" + Environment.NewLine;
            TmpReturn += "\"lastdeveloperinfo\":\"" + devInstance.LastDeveloperInfo.ToString() + "\"" + Environment.NewLine;


            TmpReturn += "}";
            return TmpReturn;
        }
    }
}
