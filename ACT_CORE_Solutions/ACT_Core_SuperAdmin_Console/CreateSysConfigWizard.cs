//using ACT.Core.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SC = System.Console;

//namespace ACT.SuperAdmin.Console
//{
//    public static class CreateSysConfigWizard
//    {
//        public static ACT.Core.ACT_Types.SystemSettingsData START()
//        {
//            ACT.Core.ACT_Types.SystemSettingsData _tmpReturn = new Core.ACT_Types.SystemSettingsData();

//            SC.Clear();
//            SC.WriteLine("      SystemConfiguration Creation Wizard");
//            SC.WriteLine("---------------------------------------------------");
//            SC.WriteLine("Press q or ESC to quit and return to main menu.");
//            SC.WriteLine("---------------------------------------------------");
//            SC.WriteLine();
//            SC.Write("Press any key to continue.");
//            var _K = SC.ReadKey().Key;
//            if (QuitPressed(_K)) { return null; }

//            SC.Write("Skip Addings Dependancy DLLs? (Q or ESC)");

//            _tmpReturn.Dependancies = new Core.ACT_Types.Dependancies();

//            while (SC.ReadKey().Key != ConsoleKey.Escape)
//            {
//                var _quit = SC.ReadKey().Key;
//                if (QuitPressed(_quit)) { return null; }
//                string _DLLName = HelperTmp.GetUserInput("DLL Name: ", null, false, false);
//                string _FullFileLocation = HelperTmp.GetUserInput("DLL File Path: ", null, false, true, new List<string>() { ".dll" });
//                _tmpReturn.Dependancies.Dlls.Add(new Core.ACT_Types.Dll() { Filename = _FullFileLocation, Name = _DLLName, Id = Guid.NewGuid().ToString() });
//                SC.Write("Quit? (Q or ESC)");
//            }

//            // NEXT ACTLIB

//            SC.Write("Skip Addings ACTLIB DLLs? (Q or ESC)");

//            _tmpReturn.Dependancies.Actlib = new List<Core.ACT_Types.Actlib>();

//            while (SC.ReadKey().Key != ConsoleKey.Escape)
//            {
//                var _quit = SC.ReadKey().Key;
//                if (QuitPressed(_quit)) { return null; }
//                string _DLLName = HelperTmp.GetUserInput("DLL Name: ", null, false, false, null);
//                string _FullFileLocation = HelperTmp.GetUserInput("DLL File Path: ", null, false, true, new List<string>() { ".dll" });
//                string _FileVersion = HelperTmp.GetUserInput("File Version: ", null, false, false, null);
//                string _UpdateSource = HelperTmp.GetUserInput("Update Source: ", null, false, false, null);

//                _tmpReturn.Dependancies.Actlib.Add(new Core.ACT_Types.Actlib() { Filename = _FullFileLocation, Name = _DLLName, Fileversion = _FileVersion, Updatesource = _UpdateSource, Id = Guid.NewGuid().ToString() });
//                SC.Write("Quit? (Q or ESC)");
//            }

//            // NEXT Nuget Package

//            SC.Write("Skip Addings Nuget Packages? (Q or ESC)");

//            _tmpReturn.Dependancies.NugetPackages = new List<Core.ACT_Types.NugetPackage>();

//            while (SC.ReadKey().Key != ConsoleKey.Escape)
//            {
//                var _quit = SC.ReadKey().Key;
//                if (QuitPressed(_quit)) { return null; }
//                string _Name = HelperTmp.GetUserInput("Package Name: ", null, false, false, null);
//                string _Version = HelperTmp.GetUserInput("Version: ", null, false, false, null);
//                string _MinVersion = HelperTmp.GetUserInput("Min Version: ", null, false, false, null);
//                string _UpdateSource = HelperTmp.GetUserInput("Package Source: ", null, false, false, null);

//                _tmpReturn.Dependancies.NugetPackages.Add(new Core.ACT_Types.NugetPackage() { Name = _Name, Version = _Version, MinVersion = _MinVersion, PackageSource = _UpdateSource });
//                SC.Write("Quit? (Q or ESC)");
//            }

//            // NEXT Plugins

//            SC.Write("Skip Addings Plugins? (Q or ESC)");

//            _tmpReturn.Plugins = new List<Core.ACT_Types.ConfigurationDataPlugin>();
//            int _Order = 1;
//            while (SC.ReadKey().Key != ConsoleKey.Escape)
//            {
//                var _quit = SC.ReadKey().Key;
//                if (QuitPressed(_quit)) { return null; }
//                string _RegistrationID = HelperTmp.GetUserInput("Registration ID: ", null, false, false, null);
//                string _FileName = HelperTmp.GetUserInput("File Name: ", null, false, true, new List<string> { ".dll" });
//                string _Type = HelperTmp.GetUserInput("Type: ", null, false, false, null);
//                string _StoreOnce = HelperTmp.GetUserInput("Store Once: ", null, false, false, null);
//                string _DataFiles = HelperTmp.GetUserInput("Required Data Files (Comma Seperated): ", null, false, false, null);
//                string _Arguments = HelperTmp.GetUserInput("Arguments: (Comma Seperated) ", null, false, false, null);
//                string _Checksum = HelperTmp.GetUserInput("Checksum: ", null, false, false, null);
//                string _LicenseKey = HelperTmp.GetUserInput("License Key: ", null, false, false, null);

//                _tmpReturn.Plugins.Add(new Core.ACT_Types.ConfigurationDataPlugin()
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    RegistrationId = _RegistrationID,
//                    FileName = _FileName,
//                    Type = _Type,
//                    StoreOnce = _StoreOnce.ToBool(true),
//                    Data_Files = _DataFiles.SplitString(",", StringSplitOptions.RemoveEmptyEntries).ToList(),
//                    Arguments = _Arguments.SplitString(",", StringSplitOptions.RemoveEmptyEntries).ToList(),
//                    Checksum = _Checksum,
//                    LicenseKey = _LicenseKey,
//                    Order = _Order.ToString()
//                });
//                _Order++;
//                SC.Write("Quit? (Q or ESC)");
//            }

//            // Interfaces

//            SC.Write("Generate ACT Interface Array? (Y,N): ");
//            var _GenerateACTInterfaces = SC.ReadKey();
//            if (_GenerateACTInterfaces.Key == ConsoleKey.Y)
//            {
//              //  ReflectionManagement.ExportDictionaryToJSONFile("");
//            }


//            return _tmpReturn;
//        }

//        static bool QuitPressed(ConsoleKey KeyToTest)
//        {
//            if (KeyToTest == ConsoleKey.Q || KeyToTest == ConsoleKey.Escape) { return true; }
//            return false;
//        }
//    }
//}
