using ACT.Core.Extensions;

/// <summary>
/// ACTLicFileEncryp = Encryption Key For Lic File.
/// </summary>
namespace ACT.PackageManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainRun();

        }
        public static void MainRun()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            string BasePath = "";
            bool ReadAllVersions = false;

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







            // Load the INI Data
            string inifilepath = AppDomain.CurrentDomain.BaseDirectory + "settings.ini";

            if (inifilepath.FileExists() == false) { throw new FileNotFoundException(BasePath); }
            var _data = inifilepath.ReadAllText().SplitString(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            BasePath = _data[0].Substring(_data[0].IndexOf(":") + 1);
            ReadAllVersions = _data[1].Substring(_data[1].IndexOf(":") + 1).ToBool(false);

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
    }
}
