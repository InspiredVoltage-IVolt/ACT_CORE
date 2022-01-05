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

            //if (SC.ReadKey().Key == ConsoleKey.C)
            //{
            //    string _Code = GenerateDevReport(();

            //}

            //string _FN = @"D:\IVolt_Development\ACT_Core\ACT_CORE\ACT_CORE_Solutions\ACT_Core_SuperAdmin_Console\bin\Debug\net6.0\ACT_CORE.dll";

            string _FN = "ACT_CORE";
            //string _DetailedData = GetDevReport(_FN);

            //string _DevReport = "{" + Environment.NewLine;
            //_DevReport += "\t\"DevelopmentData\": [" + Environment.NewLine;
            //_DevReport += _DetailedData + Environment.NewLine;
            //_DevReport += "\t]" + Environment.NewLine + "}";
            GetDevReport(_FN).SaveAllText("I:\\tmp\\devreport.json");
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