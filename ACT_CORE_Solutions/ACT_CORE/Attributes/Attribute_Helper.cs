using ACT.Core.ACT_Types.Attribute_Support;

namespace ACT.Core.Attributes
{

    public class Helper
    {

        /// <summary>
        /// Helper Method to Grab the Value of an Attribute on a Method
        /// </summary>
        /// <example>var name = GetMethodAttributeValue<MyAttribute, string>(MyMethod, x => x.Name);</example>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="action"></param>
        /// <param name="valueSelector"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetMethodAttributeValue<TAttribute, TValue>(Action action, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            if (valueSelector == null) { throw new ArgumentNullException(nameof(valueSelector)); }
            if (action == null) { throw new ArgumentNullException(nameof(action)); }

            var methodInfo = action.Method;
            TAttribute attr = methodInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null) { throw new ArgumentNullException(nameof(attr)); }
            else
            {
                var _tmpReturn = valueSelector(attr);
                if (_tmpReturn != null) { return _tmpReturn; }
                else { throw new ArgumentNullException("Default Value Is Null"); }
            }

        }

        /// <summary>
        /// Generates a Development Report Based on the DEV Attribute.
        /// </summary>
        /// <param name="DLLPath_or_LocalName">DLL To Evaluate</param>
        /// <param name="JSONFormat">Return JSON</param>
        /// <param name="CSVFormat">Return CSV</param>
        /// <returns>Development Report For DLL</returns>
        public static Attribute_Development_Data GenerateDevelopmentReportData(string DLLPath_or_LocalName, bool SortByPriority = true)
        {
            Attribute_Development_Data _TmpObject = new Attribute_Development_Data();

            System.Reflection.Assembly _Asm;

            try
            {
                if (DLLPath_or_LocalName.ToLower().EndsWith(".dll"))
                {
                    _Asm = System.Reflection.Assembly.LoadFile(DLLPath_or_LocalName);
                }
                else
                {
                    _Asm = System.Reflection.Assembly.Load(DLLPath_or_LocalName);
                }
            }
            catch
            {
                throw;
            }


            foreach (var ASMTYP in _Asm.GetExportedTypes())
            {
                string className = ASMTYP.Name;
                string typeName = "";

                foreach (var ASMConstructor in ASMTYP.GetConstructors())
                {
                    typeName = ASMConstructor.GetType().ToString();
                    foreach (var DevAttr in ASMConstructor.GetCustomAttributes(true).Where(x => x.ToString() == "ACT.DEV"))
                    {
                        _TmpObject.DevelopmentData.Add(DEV.ToDevelopmentDefinition((ACT.DEV)DevAttr, className, typeName));
                    }
                }

                foreach (var ASMMethod in ASMTYP.GetMethods())
                {
                    typeName = ASMMethod.GetType().ToString();
                    foreach (var DevAttr in ASMMethod.GetCustomAttributes(true).Where(x => x.ToString() == "ACT.DEV"))
                    {
                        _TmpObject.DevelopmentData.Add(DEV.ToDevelopmentDefinition((ACT.DEV)DevAttr, className, typeName));
                    }
                }

                foreach (var ASMProperties in ASMTYP.GetProperties())
                {
                    typeName = ASMProperties.GetType().ToString();
                    foreach (var DevAttr in ASMProperties.GetCustomAttributes(true).Where(x => x.ToString() == "ACT.DEV"))
                    {
                        _TmpObject.DevelopmentData.Add(DEV.ToDevelopmentDefinition((ACT.DEV)DevAttr, className, typeName));
                    }
                }

                foreach (var ASMFields in ASMTYP.GetFields())
                {
                    typeName = ASMFields.GetType().ToString();
                    foreach (var DevAttr in ASMFields.GetCustomAttributes(true).Where(x => x.ToString() == "ACT.DEV"))
                    {
                        _TmpObject.DevelopmentData.Add(DEV.ToDevelopmentDefinition((ACT.DEV)DevAttr, className, typeName));
                    }
                }

                foreach (var DevAttr in ASMTYP.GetCustomAttributes(true).Where(x => x.ToString() == "ACT.DEV"))
                {
                    typeName = "Class";
                    _TmpObject.DevelopmentData.Add(DEV.ToDevelopmentDefinition((ACT.DEV)DevAttr, className, typeName));
                }

                _Asm = null;
            }

            if (SortByPriority)
            {
                _TmpObject.SortData();
                return _TmpObject;
            }
            else
            {
                return _TmpObject;
            }
        }


        /// <summary>
        /// Generates a Development Report Based on the DEV Attribute.
        /// </summary>
        /// <param name="DLLPath_or_LocalName">DLL To Evaluate</param>
        /// <param name="JSONFormat">Return JSON</param>
        /// <param name="CSVFormat">Return CSV</param>
        /// <returns>Development Report For DLL</returns>
        public static string GenerateJSONDevelopmentReport(string DLLPath_or_LocalName, bool SortByPriority = true)
        {
            return GenerateDevelopmentReportData(DLLPath_or_LocalName, false).ToJSON(SortByPriority);
        }
    }
}