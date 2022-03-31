using ACT.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC = System.Console;

namespace ACT.SuperAdmin.Console
{
    internal class HelperTmp
    {
        public static string GetUserInput(string Caption, List<string> AcceptableResponsed = null, bool EnsureDirectoryExists = false, bool EnsureFileExists = false, List<string> AllowedExtensions = null)
        {
        StartMNU:
            SC.Write(Caption);

            string _Response = SC.ReadLine();

            if (AcceptableResponsed != null)
            {
                if (AcceptableResponsed.Contains(_Response))
                {
                    return _Response;
                }
                else
                {
                    SC.Write("Invalid Response!");
                    goto StartMNU;
                }
            }
            else if (EnsureDirectoryExists == true)
            {
                if (_Response.DirectoryExists() == false)
                {
                    SC.Write("Invalid - Requires a Directory!");
                    goto StartMNU;
                }
            }
            else if (EnsureFileExists == true)
            {
                if (_Response.FileExists() == false)
                {
                    SC.Write("Invalid - Requires a File!");
                    goto StartMNU;
                }
                else
                {
                    if (AllowedExtensions != null)
                    {
                        string _Extension = _Response.Substring(_Response.LastIndexOf("."));
                        if (AllowedExtensions.Contains(_Extension) == false)
                        {
                            SC.Write("Invalid - Requires a File!");
                            goto StartMNU;
                        }
                        return _Response;
                    }
                    else
                    {
                        SC.Write("Invalid - Requires a File!");
                        goto StartMNU;
                    }
                }
            }

            return _Response;
        }
    }
}
