using ACT.Core.Extensions;

/// <summary>
/// ACTLicFileEncryp = Encryption Key For Lic File.
/// </summary>
namespace ACT.PackageManager
{

    public class Program
    {


        static void Main(string[] args)
        {
            // Console.WriteLine(args.Length);
            foreach (var s in args) { Console.WriteLine(s); }

            if (args.Length > 1)
            {
                GenerateJSONOutput(args[1]);
            }
            else
            {
                GenerateJSONOutput(AppDomain.CurrentDomain.BaseDirectory);
            }

            //foreach (var cult in CultureInfo.GetCultures(CultureTypes.AllCultures).Distinct())
            //{
            //    Console.WriteLine(cult.DisplayName + " : " + cult.TwoLetterISOLanguageName);
            //}

            //MainRun();

        }
        class FileData
        {
            public bool WindowsFlag = false;
            public bool Is32Bit = false;
            public bool Is64Bit = false;
            public bool IsOther = false;
            public bool IsDebugVersion = false;
            public string FullFilePath = "";
            public string FileNameOnly = "";
            public DateTime LastModifiedDate = DateTime.MinValue;
        }

        static void GenerateJSONOutput(string outputPath)
        {
            string BasePath = "";
            bool ReadAllVersions = false;
            List<string> IgnoreFolderHints = new List<string>();

            // Load the INI Data
            string inifilepath = AppDomain.CurrentDomain.BaseDirectory + "settings.ini";

            if (inifilepath.FileExists() == false) { throw new FileNotFoundException(BasePath); }
            var _data = inifilepath.ReadAllText().SplitString(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            BasePath = _data[0].Substring(_data[0].IndexOf(":") + 1);
            ReadAllVersions = _data[1].Substring(_data[1].IndexOf(":") + 1).ToBool(false);
            IgnoreFolderHints.AddRange(_data[2].Substring(_data[2].IndexOf(":") + 1).SplitString(";", StringSplitOptions.RemoveEmptyEntries));

            var _NuGetFiles = Directory.GetFiles(BasePath, "*.nupkg", SearchOption.AllDirectories);

            Dictionary<string, List<FileData>> _Files = new Dictionary<string, List<FileData>>();

            foreach (var file in _NuGetFiles)
            {
                if (file.ToLower().Contains(IgnoreFolderHints, true)) { continue; }

                if (file.EndsWith(".nupkg"))
                {
                    FileData _tmpFile = new FileData();
                    _tmpFile.FullFilePath = file;
                    _tmpFile.FileNameOnly = file.GetFileNameFromFullPath();
                    var _PackageGroupName = "";
                    if (file.GetFileNameWithoutExtension().IndexOf(".") > 0)
                    {
                        _PackageGroupName = file.GetFileNameWithoutExtension().Substring(0, file.GetFileNameWithoutExtension().IndexOf("."));
                    }
                    else
                    {
                        _PackageGroupName = file.GetFileNameWithoutExtension();
                    }

                    if (file.ToLower().Contains("windows")) { _tmpFile.WindowsFlag = true; }
                    if (file.ToLower().Contains("debug")) { _tmpFile.IsDebugVersion = true; }
                    if (file.ToLower().Contains("release")) { _tmpFile.IsDebugVersion = false; }
                    if (file.ToLower().Contains("x86")) { _tmpFile.Is32Bit = true; }
                    if (file.ToLower().Contains("x64")) { _tmpFile.Is64Bit = true; }
                    _tmpFile.FullFilePath = file;
                    _tmpFile.FileNameOnly = file.GetFileNameFromFullPath();
                    if (!_Files.ContainsKey(_PackageGroupName)) { _Files[_PackageGroupName] = new List<FileData>() { _tmpFile }; }
                    else { _Files[_PackageGroupName].Add(_tmpFile); }
                }
            }

            string _Data = Newtonsoft.Json.JsonConvert.SerializeObject(_Files, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(outputPath.EnsureDirectoryFormat() + DateTime.Now.ToUnixTime().ToString() + ".json", _Data);
        }
        /*
        public static void MainRun()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            string BasePath = "";
            bool ReadAllVersions = false;
            List<string> IgnoreFolderHints = new List<string>();

            // Load the INI Data
            string inifilepath = AppDomain.CurrentDomain.BaseDirectory + "settings.ini";

            if (inifilepath.FileExists() == false) { throw new FileNotFoundException(BasePath); }
            var _data = inifilepath.ReadAllText().SplitString(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            BasePath = _data[0].Substring(_data[0].IndexOf(":") + 1);
            ReadAllVersions = _data[1].Substring(_data[1].IndexOf(":") + 1).ToBool(false);
            IgnoreFolderHints.AddRange(_data[2].Substring(_data[2].IndexOf(":") + 1).SplitString(";", StringSplitOptions.RemoveEmptyEntries));

            string OperatingSystemFilter = "";

            Console.Clear();
            Console.WriteLine("------------  Filter By OS ---------");
            Console.WriteLine("A. Windows");
            Console.WriteLine("B. Linux");
            Console.WriteLine("Any Other Key: Grabs All");

            var OperatingSystemFilterChoice = Console.ReadKey();
            if (OperatingSystemFilterChoice.Key == ConsoleKey.A || OperatingSystemFilterChoice.Key == ConsoleKey.B || OperatingSystemFilterChoice.Key == ConsoleKey.C)
            {
                if (OperatingSystemFilterChoice.Key == ConsoleKey.A) { OperatingSystemFilter = "Windows"; }
                if (OperatingSystemFilterChoice.Key == ConsoleKey.B) { OperatingSystemFilter = "Linux"; }
            }

            string ArchitectureFilter = "";

            Console.Clear();
            Console.WriteLine("------------  Filter To Platform ---------");
            Console.WriteLine("A. x86");
            Console.WriteLine("B. x64");
            Console.WriteLine("Any Other Key: 64 bit Version");
            { }
            var ArchitectureFilterKey = Console.ReadKey();

            if (ArchitectureFilterKey.Key == ConsoleKey.A || ArchitectureFilterKey.Key == ConsoleKey.B)
            {
                if (ArchitectureFilterKey.Key == ConsoleKey.A) { ArchitectureFilter = "x86"; }
                if (ArchitectureFilterKey.Key == ConsoleKey.B) { ArchitectureFilter = "x64"; }
            }










            var _NuGetFiles = System.IO.Directory.GetFiles(BasePath, "*.nupkg", SearchOption.AllDirectories);
            var _Files = new List<string>();
            foreach (var file in _NuGetFiles)
            {
                if (file.Contains(OperatingSystemFilter) == true)
                {
                    if (file.EndsWith(".nupkg")) { _Files.Add(file); }
                }
            }
            Dictionary<string, List<string>> Versions = new Dictionary<string, List<string>>();

            foreach (string f in _Files)
            {
                string _FileName = f.GetFileName(false);
                _FileName = _FileName.Substring(0, _FileName.IndexOf('.'));
                if (Versions.ContainsKey(_FileName) == false) { Versions.Add(_FileName, new List<string> { }); }

                Versions[_FileName].Add(f.GetFileName(false));
            }

            foreach (var k in Versions.Keys)
            {
                Console.WriteLine(k);
                Console.WriteLine(k.OrderBy(x => x).First());
            }


            System.Console.ReadLine();
        }
        */
    }


}
