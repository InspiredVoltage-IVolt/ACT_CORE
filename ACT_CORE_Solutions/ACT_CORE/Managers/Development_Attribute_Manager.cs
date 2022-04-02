using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACT.Core.Extensions;
using NLog.Targets;
using NLog;

namespace ACT.Core.Managers
{
    public static class Development_Attribute_Manager
    {
        /// <summary>
        /// Generates the Development Attribute Report
        /// </summary>
        /// <param name="DLL_PATH">DLL To Evaluate</param>
        /// <param name="ExportLogTo">Location To save Report To</param>
        /// <returns></returns>
        public static string Generate_Development_Status_Report(string DLL_PATH, string ExportLogTo = null)
        {
            string _OriginalPath = DLL_PATH;

            if (ExportLogTo == null)
            {
                var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
                ExportLogTo = (LogManager.Configuration.FindTargetByName("file") as FileTarget).FileName.Render(logEventInfo);
            }

            if (ExportLogTo.DirectoryExists() == false)
            {
                try
                {
                    ExportLogTo.CreateDirectoryStructure(null);
                }
                catch (Exception ex)
                {
                    ExportLogTo = AppDomain.CurrentDomain.BaseDirectory + "Resources\\Logs\\";
                    _.LogBasicInfoWithException("ACT.Core.Managers.Generate_Development_Status_Report(DLL Path) NO FLL FOUND...", ex);
                    throw;
                }
            }

            if (DLL_PATH.FileExists() == false && DLL_PATH.ToLower().EndsWith(".dll") == false)
            {
                if ((AppDomain.CurrentDomain.BaseDirectory + DLL_PATH).FileExists())
                {
                    DLL_PATH = AppDomain.CurrentDomain.BaseDirectory + DLL_PATH;
                }
                else
                {
                    var _ex = new DllNotFoundException("Original Path: '" + _OriginalPath + "' Modified Path: '" + DLL_PATH + "'Neither Were Found'");
                    _.LogBasicInfoWithException("ACT.Core.Managers.Generate_Development_Status_Report(DLL Path) NO FLL FOUND...", _ex);
                    throw _ex;
                }
            }

            string DevReportFileName = DateTime.Now.ToString("MM-dd-yyyy-ff") + "-DEV-TODO-REPORT.txt";

            string _Code = GetDevReport(DLL_PATH);

            System.IO.File.WriteAllText(ExportLogTo.EnsureDirectoryFormat(), _Code);

            return ExportLogTo.EnsureDirectoryFormat() + DevReportFileName;
        }

        /// <summary>
        /// Shortcut to attribute Method
        /// </summary>
        /// <param name="Path">Path Tp DLL</param>
        /// <returns>REPORT TEXT</returns>
        static string GetDevReport(string Path)
        {
            return Attributes.Helper.GenerateJSONDevelopmentReport(Path, true);
        }
    }
}
