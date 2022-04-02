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

        public static string Generate_Development_Status_Report(string DLL_PATH, string ExportLogTo = null)
        {
            string _OriginalPath = DLL_PATH;

            if (ExportLogTo == null) {
                var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };                
                ExportLogTo = (LogManager.Configuration.FindTargetByName("file") as FileTarget).FileName.Render(logEventInfo);             
            }
            if (ExportLogTo.DirectoryExists() == false)
            {
                try
                {
                    ExportLogTo.CreateDirectoryStructure(null);
                }
                catch(Exception ex)
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
                   
            string _Code = GetDevReport(DLL_PATH);
      
            string DevReportFileName = ""

            if (ExportLogTo.GetDirectoryFromFileLocation().EnsureDirectoryFormat().DirectoryExists() == false
                || _ExportToLocation.ToLower().EndsWith(".json") == false)
            {
                SC.WriteLine("Error Invalid Path. Please Try Again.");
                goto GetExportLocation;
            }
            _Code.SaveAllText(_ExportToLocation);

            SC.WriteLine("");
            SC.Write("Report Saved: Press Any Key To Continue: ");
            SC.ReadKey();
            goto mainMenu;
        }

        static string GetDevReport(string Path)
        {
            return ACT.Core.Attributes.Helper.GenerateJSONDevelopmentReport(Path, true);
        }
    }
}
