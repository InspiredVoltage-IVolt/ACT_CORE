using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Core.Encoding.JSON
{
    public static class GenericJSONSerializer
    {
        public static string EncodeToJSON<T>(object Obj, bool Base64Encode)
        {

            var _String = Newtonsoft.Json.JsonConvert.SerializeObject(Obj, typeof(T), new Newtonsoft.Json.JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All });

            if (Base64Encode)
            {
                return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(_String));
            }
            
            return _String;
        }
    }
}
