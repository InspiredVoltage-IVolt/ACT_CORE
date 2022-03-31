using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.SuperAdmin.Console
{
    internal static class ReflectionManagement
    {
        public static string GenerateSystemConfigurationSection(string ACTCore_DLL_Location)
        {
            var _R = GetACTInterfaces(ACTCore_DLL_Location);
            return ExportDictionaryToJSONFile(_R);
        }

        public static Dictionary<string, Type> GetACTInterfaces(string DLL_Location = null)
        {
            Dictionary<string, Type> ret = new Dictionary<string, Type>();

            var _ASM = System.Reflection.Assembly.LoadFrom(DLL_Location);

            foreach (var tt in _ASM.GetTypes())
            {
                if (ret.ContainsKey(tt.FullName) == false)
                {
                    GetInterfaces(tt, ref ret);
                }
            }

            return ret;
        }
        // Recursive Analysis
        private static void GetInterfaces(Type t, ref Dictionary<string, Type> Data)
        {
            foreach (var IntFace in t.GetInterfaces())
            {
                Data.Add(IntFace.FullName, IntFace);
            }

            foreach (var tt in t.GetNestedTypes())
            {
                if (Data.ContainsKey(tt.FullName) == false)
                {
                    GetInterfaces(tt, ref Data);
                }
            }

            return;
        }

        public static string ExportDictionaryToJSONFile(Dictionary<string, Type> Data)
        {
            StringBuilder sb = new StringBuilder();

            string _TemplateHeader = "\t\"interfaces\": [" + Environment.NewLine;
            string _TemplateFooter = "\t]," + Environment.NewLine;
            string _Template = "\t\t{" + Environment.NewLine;
            _Template += "\t\t\t\"id\": \"###ID###\"," + Environment.NewLine;
            _Template += "\t\t\t\"name\": \"###SHORTNAME###\"," + Environment.NewLine;
            _Template += "\t\t\t\"full_interface_name\": \"###FULLINTERFACENAME###\"," + Environment.NewLine;
            _Template += "\t\t\t\"type\": \"###INTERFACETYPE###\"," + Environment.NewLine;
            _Template += "\t\t\t\"is_core\": ###ISCORE###," + Environment.NewLine;
            _Template += "\t\t\t\"plugins\": [" + Environment.NewLine;
            _Template += "\t\t\t\t{" + Environment.NewLine;
            _Template += "\t\t\t\t\t\"full_class_name\": \"\"," + Environment.NewLine;
            _Template += "\t\t\t\t\t\"plugin_id\": \"\"" + Environment.NewLine;
            _Template += "\t\t\t\t}" + Environment.NewLine;
            _Template += "\t\t\t]" + Environment.NewLine;
            _Template += "\t\t}" + Environment.NewLine;

            sb.Append(_TemplateHeader);

            foreach (string InterfaceFullPathName in Data.Keys)
            {
                string _Item = _Template;
                _Item = _Item.Replace("###ID###", Guid.NewGuid().ToString());
                _Item = _Item.Replace("###SHORTNAME###", Data[InterfaceFullPathName].Name);
                _Item = _Item.Replace("###FULLINTERFACENAME###", Data[InterfaceFullPathName].FullName);
                _Item = _Item.Replace("###INTERFACETYPE###", "Core");
                _Item = _Item.Replace("###ISCORE###", "true");
                sb.Append(_Item);
            }

            sb.Append(_TemplateFooter);
            return sb.ToString();
        }
    }
}
