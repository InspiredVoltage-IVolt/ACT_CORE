
using System.Data.SqlClient;
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
            System.Console.WriteLine(GenericJSONSerializer.EncodeToJSON<System.Data.SqlClient.SqlConnectionStringBuilder>(new TestData(), false));
            System.Console.ReadKey();

            //    return;
            //mainMenu:
            //    SC.Clear();
            //    SC.WriteLine("ACT Super Admin");
            //    SC.WriteLine("---------------------------------------------");
            //    SC.WriteLine("");
            //    SC.WriteLine("SystemConfiguration - New Wizard (CC) ");
            //    SC.WriteLine("Reflection - Generate Interfaces (GI) ");
            //    SC.WriteLine("Generate Dev Report (DR) ");
            //    SC.Write("Enter your Selection: ");

            //    string _Entry = SC.ReadLine();

            //    if (_Entry.ToLower() == "gi")
            //    {
            //        SC.Clear();
            //        SC.WriteLine("<Generate Interface Report>");

            //        SC.WriteLine("---------------------------------------------");
            //        SC.WriteLine("");
            //    getDLLLocation:
            //        SC.Write("Enter the DLL You wish to extract the interfaces From: ");
            //        string _DLL_Location = SC.ReadLine();

            //        if (_DLL_Location.ToLower() == "q") { goto mainMenu; }

            //        if (_DLL_Location.FileExists() == false || _DLL_Location.ToLower().EndsWith(".dll") == false)
            //        {
            //            if ((AppDomain.CurrentDomain.BaseDirectory + _DLL_Location).FileExists())
            //            {
            //                _DLL_Location = AppDomain.CurrentDomain.BaseDirectory + _DLL_Location;
            //            }
            //            else
            //            {
            //                SC.WriteLine("Error DLL Not Found. Please Try Again. Press Q to Quite to Main Menu");
            //                goto getDLLLocation;
            //            }
            //        }

            //        var _Results = ReflectionManagement.GetACTInterfaces(_DLL_Location);

            //    GetExportLocation:
            //        SC.WriteLine("");
            //        SC.Write("Enter the Full JSONFile Report Destination: ");
            //        string _ExportToLocation = SC.ReadLine();

            //        if (_ExportToLocation.GetDirectoryFromFileLocation().EnsureDirectoryFormat().DirectoryExists() == false
            //            || _ExportToLocation.ToLower().EndsWith(".json") == false)
            //        {
            //            SC.WriteLine("Error Invalid Path. Please Try Again.");
            //            goto GetExportLocation;
            //        }

            //        var _Interfaces = ReflectionManagement.GetACTInterfaces(_DLL_Location);
            //        ReflectionManagement.ExportDictionaryToJSONFile(_Interfaces).SaveAllText(_ExportToLocation);

            //    }
            //    else if (_Entry.ToLower() == "dr")
            //    {
            //    getDLLLocation:
            //        SC.Write("Enter the DLL You wish to run the Dev Report On: ");
            //        string _DLL_Location = SC.ReadLine();

            //        if (_DLL_Location.ToLower() == "q") { goto mainMenu; }

            //        if (_DLL_Location.FileExists() == false || _DLL_Location.ToLower().EndsWith(".dll") == false)
            //        {
            //            if ((AppDomain.CurrentDomain.BaseDirectory + _DLL_Location).FileExists())
            //            {
            //                _DLL_Location = AppDomain.CurrentDomain.BaseDirectory + _DLL_Location;
            //            }
            //            else
            //            {
            //                SC.WriteLine("Error DLL Not Found. Please Try Again. Press Q to Quite to Main Menu");
            //                goto getDLLLocation;
            //            }
            //        }

            //        SC.Clear();
            //        SC.WriteLine("Processing...");

            //        string _Code = GetDevReport(_DLL_Location);
            //    GetExportLocation:
            //        SC.WriteLine("");
            //        SC.Write("Enter the Full JSONFile Report Destination: ");
            //        string _ExportToLocation = SC.ReadLine();

            //        if (_ExportToLocation.GetDirectoryFromFileLocation().EnsureDirectoryFormat().DirectoryExists() == false
            //            || _ExportToLocation.ToLower().EndsWith(".json") == false)
            //        {
            //            SC.WriteLine("Error Invalid Path. Please Try Again.");
            //            goto GetExportLocation;
            //        }
            //        _Code.SaveAllText(_ExportToLocation);

            //        SC.WriteLine("");
            //        SC.Write("Report Saved: Press Any Key To Continue: ");
            //        SC.ReadKey();
            //        goto mainMenu;
            //    }
            //    else if (_Entry.ToLower() == "cc")
            //    {

            //    }
            //    else
            //    {
            //        SC.WriteLine("");
            //        SC.Write("Invalid Entry (Press Q to Quit or Any Key to Try Again: ");
            //        if (SC.ReadKey().Key == ConsoleKey.Q) { return; }
            //        goto mainMenu;
            //    }


            //}



            //static string GetDevReport(string Path)
            //{
            //    return ACT.Core.Attributes.Helper.GenerateJSONDevelopmentReport(Path, true);
            //}



            ///// <summary>
            ///// Generate Client License
            ///// </summary>
            ///// <returns>License Text</returns>
            //[DEV(ToDo = true, ToDo_Description = "Finish Code", Priority = 20)]
            //static string GenerateClientLic()
            //{
            //    Dictionary<string, string> _Data = new Dictionary<string, string>();

            //    SC.WriteLine("Client (Short) Name: ");
            //    string _ClientName = SC.ReadLine();

            //    SC.WriteLine("Product (Short) Name: ");
            //    string _ProductName = SC.ReadLine();

            //    SC.WriteLine("Purchase ID: ");
            //    string _PurchaseID = SC.ReadLine();

            //    SC.WriteLine("Purchase Date: ");
            //    string _PurchaseDate = SC.ReadLine();

            //    SC.WriteLine("Quantity: ");
            //    string _Quantity = SC.ReadLine();

            //    SC.WriteLine("Code: ");
            //    string _Code = SC.ReadLine();

            //    _Data.Add("ClientID", "");


            //    string _fn = @"D:\IVolt_Development\ACT_Core\ACT_CORE\ACT_CORE_Solutions\ACT_CORE\Lic.txt";

            //    //  string _LicFile = _Data.EncryptString("ACTLicFileEncryp");
            //    //_LicFile.SaveAllText(_fn);
            //    return "";
            //}
        }
        public class TestData
        {
            //
            // Summary:
            //     Declares the application workload type when connecting to a database in an SQL
            //     Server Availability Group. You can set the value of this property with System.Data.SqlClient.ApplicationIntent.
            //     For more information about SqlClient support for Always On Availability Groups,
            //     see SqlClient Support for High Availability, Disaster Recovery.
            //
            // Returns:
            //     Returns the current value of the property (a value of type System.Data.SqlClient.ApplicationIntent).
            public ApplicationIntent ApplicationIntent
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the name of the application associated with the connection string.
            //
            // Returns:
            //     The name of the application, or ".NET SqlClient Data Provider" if no name has
            //     been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string ApplicationName
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a string that contains the name of the primary data file. This includes
            //     the full path name of an attachable database.
            //
            // Returns:
            //     The value of the AttachDBFilename property, or String.Empty if no value has been
            //     supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string AttachDBFilename
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     The number of reconnections attempted after identifying that there was an idle
            //     connection failure. This must be an integer between 0 and 255. Default is 1.
            //     Set to 0 to disable reconnecting on idle connection failures. An System.ArgumentException
            //     will be thrown if set to a value outside of the allowed range.
            //
            // Returns:
            //     The number of reconnections attempted after identifying that there was an idle
            //     connection failure.
            public int ConnectRetryCount
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Amount of time (in seconds) between each reconnection attempt after identifying
            //     that there was an idle connection failure. This must be an integer between 1
            //     and 60. The default is 10 seconds. An System.ArgumentException will be thrown
            //     if set to a value outside of the allowed range.
            //
            // Returns:
            //     Amount of time (in seconds) between each reconnection attempt after identifying
            //     that there was an idle connection failure.
            public int ConnectRetryInterval
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the length of time (in seconds) to wait for a connection to the
            //     server before terminating the attempt and generating an error.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.ConnectTimeout
            //     property, or 15 seconds if no value has been supplied.
            public int ConnectTimeout
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the SQL Server Language record name.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.CurrentLanguage
            //     property, or String.Empty if no value has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string CurrentLanguage
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the name or network address of the instance of SQL Server to connect
            //     to.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.DataSource
            //     property, or String.Empty if none has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string DataSource
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a Boolean value that indicates whether SQL Server uses SSL encryption
            //     for all data sent between the client and server if the server has a certificate
            //     installed.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.Encrypt property,
            //     or false if none has been supplied.
            public bool Encrypt
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a Boolean value that indicates whether the SQL Server connection
            //     pooler automatically enlists the connection in the creation thread's current
            //     transaction context.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.Enlist property,
            //     or true if none has been supplied.
            public bool Enlist
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the name or address of the partner server to connect to if the primary
            //     server is down.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.FailoverPartner
            //     property, or String.Empty if none has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string FailoverPartner
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the name of the database associated with the connection.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.InitialCatalog
            //     property, or String.Empty if none has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string InitialCatalog
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a Boolean value that indicates whether User ID and Password are
            //     specified in the connection (when false) or whether the current Windows account
            //     credentials are used for authentication (when true).
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.IntegratedSecurity
            //     property, or false if none has been supplied.
            public bool IntegratedSecurity
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the minimum time, in seconds, for the connection to live in the
            //     connection pool before being destroyed.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.LoadBalanceTimeout
            //     property, or 0 if none has been supplied.
            public int LoadBalanceTimeout
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the maximum number of connections allowed in the connection pool
            //     for this specific connection string.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.MaxPoolSize
            //     property, or 100 if none has been supplied.
            public int MaxPoolSize
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the minimum number of connections allowed in the connection pool
            //     for this specific connection string.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.MinPoolSize
            //     property, or 0 if none has been supplied.
            public int MinPoolSize
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     When true, an application can maintain multiple active result sets (MARS). When
            //     false, an application must process or cancel all result sets from one batch before
            //     it can execute any other batch on that connection. For more information, see
            //     Multiple Active Result Sets (MARS).
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.MultipleActiveResultSets
            //     property, or false if none has been supplied.
            public bool MultipleActiveResultSets
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     If your application is connecting to an AlwaysOn availability group (AG) on different
            //     subnets, setting MultiSubnetFailover=true provides faster detection of and connection
            //     to the (currently) active server. For more information about SqlClient support
            //     for Always On Availability Groups, see SqlClient Support for High Availability,
            //     Disaster Recovery.
            //
            // Returns:
            //     Returns System.Boolean indicating the current value of the property.
            public bool MultiSubnetFailover
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the size in bytes of the network packets used to communicate with
            //     an instance of SQL Server.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.PacketSize
            //     property, or 8000 if none has been supplied.
            public int PacketSize
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the password for the SQL Server account.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.Password property,
            //     or String.Empty if none has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     The password was incorrectly set to null. See code sample below.
            public string Password
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a Boolean value that indicates if security-sensitive information,
            //     such as the password, is not returned as part of the connection if the connection
            //     is open or has ever been in an open state.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.PersistSecurityInfo
            //     property, or false if none has been supplied.
            public bool PersistSecurityInfo
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a Boolean value that indicates whether the connection will be pooled
            //     or explicitly opened every time that the connection is requested.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.Pooling property,
            //     or true if none has been supplied.
            public bool Pooling
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a Boolean value that indicates whether replication is supported
            //     using the connection.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.Replication
            //     property, or false if none has been supplied.
            public bool Replication
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a string value that indicates how the connection maintains its association
            //     with an enlisted System.Transactions transaction.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.TransactionBinding
            //     property, or String.Empty if none has been supplied.
            public string TransactionBinding
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a value that indicates whether the channel will be encrypted while
            //     bypassing walking the certificate chain to validate trust.
            //
            // Returns:
            //     A Boolean. Recognized values are true, false, yes, and no.
            public bool TrustServerCertificate
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a string value that indicates the type system the application expects.
            //
            // Returns:
            //     The following table shows the possible values for the System.Data.SqlClient.SqlConnectionStringBuilder.TypeSystemVersion
            //     property: Value Description SQL Server 2005 Uses the SQL Server 2005 type system.
            //     No conversions are made for the current version of ADO.NET. SQL Server 2008 Uses
            //     the SQL Server 2008 type system. Latest Use the latest version than this client-server
            //     pair can handle. This will automatically move forward as the client and server
            //     components are upgraded.
            public string TypeSystemVersion
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets the user ID to be used when connecting to SQL Server.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.UserID property,
            //     or String.Empty if none has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public string UserID
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

            //
            // Summary:
            //     Gets or sets a value that indicates whether to redirect the connection from the
            //     default SQL Server Express instance to a runtime-initiated instance running under
            //     the account of the caller.
            //
            // Returns:
            //     The value of the System.Data.SqlClient.SqlConnectionStringBuilder.UserInstance
            //     property, or False if none has been supplied.
            //
            // Exceptions:
            //   T:System.ArgumentNullException:
            //     To set the value to null, use System.DBNull.Value.
            public bool UserInstance
            {
                get
                {
                    throw null;
                }
                set
                {
                }
            }

        }
        public static class GenericJSONSerializer
        {
            public static string EncodeToJSON<T>(object Obj, bool Base64Encode)
            {

                var _String = Newtonsoft.Json.JsonConvert.SerializeObject(Obj, typeof(T), new Newtonsoft.Json.JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All });

                if (Base64Encode)
                {
                    return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(_String));
                }

                return _String;
            }
        }
    }
}