using ACT.Core.Extensions;
using SC = System.Console;

/// <summary>
/// ACTLicFileEncryp = Encryption Key For Lic File.
/// </summary>
namespace ACT.SuperAdmin.Console // Note: actual namespace depends on the project name.
{
    public class Program
    {

        public static void Main(string[] args)
        {

        mainMenu:
            SC.Clear();
            SC.WriteLine("ACT Super Admin");
            SC.WriteLine("---------------------------------------------");
            SC.WriteLine("");
            SC.WriteLine("SystemConfiguration - New Wizard (CC) ");
            SC.WriteLine("Reflection - Generate Interfaces (GI) ");
            SC.WriteLine("Generate Dev Report (DR) ");
            SC.Write("Enter your Selection: ");

            string _Entry = SC.ReadLine();

            if (_Entry.ToLower() == "gi")
            {
                SC.Clear();
                SC.WriteLine("<Generate Interface Report>");

                SC.WriteLine("---------------------------------------------");
                SC.WriteLine("");
            getDLLLocation:
                SC.Write("Enter the DLL You wish to extract the interfaces From: ");
                string _DLL_Location = SC.ReadLine();

                if (_DLL_Location.ToLower() == "q") { goto mainMenu; }

                if (_DLL_Location.FileExists() == false || _DLL_Location.ToLower().EndsWith(".dll") == false)
                {
                    if ((AppDomain.CurrentDomain.BaseDirectory + _DLL_Location).FileExists())
                    {
                        _DLL_Location = AppDomain.CurrentDomain.BaseDirectory + _DLL_Location;
                    }
                    else
                    {
                        SC.WriteLine("Error DLL Not Found. Please Try Again. Press Q to Quite to Main Menu");
                        goto getDLLLocation;
                    }
                }

                var _Results = ReflectionManagement.GetACTInterfaces(_DLL_Location);

            GetExportLocation:
                SC.WriteLine("");
                SC.Write("Enter the Full JSONFile Report Destination: ");
                string _ExportToLocation = SC.ReadLine();

                if (_ExportToLocation.GetDirectoryFromFileLocation().EnsureDirectoryFormat().DirectoryExists() == false
                    || _ExportToLocation.ToLower().EndsWith(".json") == false)
                {
                    SC.WriteLine("Error Invalid Path. Please Try Again.");
                    goto GetExportLocation;
                }

                var _Interfaces = ReflectionManagement.GetACTInterfaces(_DLL_Location);
                ReflectionManagement.ExportDictionaryToJSONFile(_Interfaces).SaveAllText(_ExportToLocation);

            }
            else if (_Entry.ToLower() == "dr")
            {
            getDLLLocation:
                SC.Write("Enter the DLL You wish to run the Dev Report On: ");
                string _DLL_Location = SC.ReadLine();

                if (_DLL_Location.ToLower() == "q") { goto mainMenu; }

                if (_DLL_Location.FileExists() == false || _DLL_Location.ToLower().EndsWith(".dll") == false)
                {
                    if ((AppDomain.CurrentDomain.BaseDirectory + _DLL_Location).FileExists())
                    {
                        _DLL_Location = AppDomain.CurrentDomain.BaseDirectory + _DLL_Location;
                    }
                    else
                    {
                        SC.WriteLine("Error DLL Not Found. Please Try Again. Press Q to Quite to Main Menu");
                        goto getDLLLocation;
                    }
                }

                SC.Clear();
                SC.WriteLine("Processing...");

                string _Code = GetDevReport(_DLL_Location);
            GetExportLocation:
                SC.WriteLine("");
                SC.Write("Enter the Full JSONFile Report Destination: ");
                string _ExportToLocation = SC.ReadLine();

                if (_ExportToLocation.GetDirectoryFromFileLocation().EnsureDirectoryFormat().DirectoryExists() == false
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
            else if (_Entry.ToLower() == "cc")
            {

            }
            else
            {
                SC.WriteLine("");
                SC.Write("Invalid Entry (Press Q to Quit or Any Key to Try Again: ");
                if (SC.ReadKey().Key == ConsoleKey.Q) { return; }
                goto mainMenu;
            }


        }

        static string GetDevReport(string Path)
        {
            return ACT.Core.Attributes.Helper.GenerateJSONDevelopmentReport(Path, true);
        }



        /// <summary>
        /// Generate Client License
        /// </summary>
        /// <returns>License Text</returns>
        [DEV(ToDo = true, ToDo_Description = "Finish Code", Priority = 20)]
        static string GenerateClientLic()
        {
            Dictionary<string, string> _Data = new Dictionary<string, string>();

            SC.WriteLine("Client (Short) Name: ");
            string _ClientName = SC.ReadLine();

            SC.WriteLine("Product (Short) Name: ");
            string _ProductName = SC.ReadLine();

            SC.WriteLine("Purchase ID: ");
            string _PurchaseID = SC.ReadLine();

            SC.WriteLine("Purchase Date: ");
            string _PurchaseDate = SC.ReadLine();

            SC.WriteLine("Quantity: ");
            string _Quantity = SC.ReadLine();

            SC.WriteLine("Code: ");
            string _Code = SC.ReadLine();

            _Data.Add("ClientID", "");


            string _fn = @"D:\IVolt_Development\ACT_Core\ACT_CORE\ACT_CORE_Solutions\ACT_CORE\Lic.txt";

            //  string _LicFile = _Data.EncryptString("ACTLicFileEncryp");
            //_LicFile.SaveAllText(_fn);
            return "";
        }
    }
}