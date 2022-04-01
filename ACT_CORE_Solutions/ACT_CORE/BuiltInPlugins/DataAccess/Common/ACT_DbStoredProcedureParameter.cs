using ACT.Core.Interfaces.Common;
using ACT.Core.Interfaces.DataAccess;
using ACT.Core.Interfaces.Security;

namespace ACT.Core.BuiltInPlugins.DataAccess
{
    public class ACT_DbStoredProcedureParameter : ACT_Core, I_DbStoredProcedureParameter
    {
        public string Name
        {
            get; set;
        }

        public System.Data.DbType DataType
        {
            get; set;
        }

        public int Length
        {
            get; set;
        }

        public int Order
        {
            get; set;
        }

        public string DataTypeName
        {
            get;
            set;
        }

        public I_Author Author => throw new NotImplementedException();

        public bool IsACTInternal => throw new NotImplementedException();

        public string DLLFileName => throw new NotImplementedException();

        public string SubIdentifier => throw new NotImplementedException();

        public Dictionary<Type, Dictionary<int, string>> TypesAndClassNames => throw new NotImplementedException();

        public string GitHubPackageName => throw new NotImplementedException();

        public string GitHubPackageVersion => throw new NotImplementedException();

        public List<string> ReturnRequiredFiles(bool PerformReplacements = false)
        {
            throw new NotImplementedException();
        }

        public List<string> ReturnSystemSettingRequirements(bool PerformReplacements = false)
        {
            throw new NotImplementedException();
        }

        public override I_Result ValidatePluginRequirements()
        {
            var _TR = ACT.Core.CurrentCore<I_Result>.GetCurrent();
            _TR.Success = true;
            return _TR;
        }
    }
}
