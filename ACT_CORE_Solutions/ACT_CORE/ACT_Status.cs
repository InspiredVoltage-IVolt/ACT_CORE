using ACT.Core.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Core
{
    public static class ACT_Status
    {
        public static bool SystemConfigurationFile_Loaded = false;

        #region Directories
        public static string ResourcesDirectory = AppDomain.CurrentDomain.BaseDirectory.EnsureDirectoryFormat() + "Resources\\";

        #endregion

    }
}
