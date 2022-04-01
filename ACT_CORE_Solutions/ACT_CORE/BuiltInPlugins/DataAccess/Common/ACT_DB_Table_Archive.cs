using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACT.Core.Encoding;
using ACT.Core.Enums;
using ACT.Core.Interfaces.Common;
using ACT.Core.Interfaces.Security;
using ACT.Core.Types;

namespace ACT.Core.BuiltInPlugins.DataAccess
{
    /// <summary>
    /// ACT_DB_Table Archive Plugin
    /// </summary>
    public class ACT_DB_Table_Archive : ACT_Core, ACT.Core.Interfaces.DataAccess.I_DB_Table_Archive
    {
        public I_Author Author => throw new NotImplementedException();

        public bool IsACTInternal => throw new NotImplementedException();

        public string DLLFileName => throw new NotImplementedException();

        public string SubIdentifier => throw new NotImplementedException();

        public Dictionary<Type, Dictionary<int, string>> TypesAndClassNames => throw new NotImplementedException();

        public string GitHubPackageName => throw new NotImplementedException();

        public string GitHubPackageVersion => throw new NotImplementedException();

        public string ArchiveAllData(string TableName, string EncryptionKey = "", Plugin PluginConfigInfo = null)
        {
            throw new NotImplementedException();
        }

        public ACT_Package ArchiveToPackage(string TableName, string EncryptionKey = "", Plugin PluginConfigInfo = null)
        {
            throw new NotImplementedException();
        }

        public string GenerateArchiveSQL(string TableName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetDependantTables(string TableName)
        {
            throw new NotImplementedException();
        }

        public List<string> ReturnRequiredFiles(bool PerformReplacements = false)
        {
            throw new NotImplementedException();
        }

        public List<string> ReturnSystemSettingRequirements(bool PerformReplacements = false)
        {
            throw new NotImplementedException();
        }
    }
}
