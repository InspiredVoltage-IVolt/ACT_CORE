using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.SuperAdmin.Console
{
    public static class ACT_DirectoryParser
    {
        public static List<string> GetPaths(string DirectoryData, int MaxDepth, string OutputFile, bool DisplayOutput)
        {
            List<string> _TmpReturn = new List<string>();

            foreach (string path in DirectoryData.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                string[] parts = path.Split('\\');

                string _TmpPath = "";
              
                for(int p = 1; p <= MaxDepth; p++)
                {
                    if (parts.Length < MaxDepth + 1) { break; }

                    _TmpPath += "\\" + parts[p] + "\\";

                //    if (_TmpReturn.Contains(_TmpPath)) { break; }
                  //  else { _TmpReturn.Add(_TmpPath); }
                }
                if (_TmpReturn.Contains(_TmpPath) == false)
                {
                    _TmpReturn.Add(_TmpPath);
                }
            }

            if (DisplayOutput)
            {
                foreach(string path in _TmpReturn) { System.Console.WriteLine(path); }
            }

            if (OutputFile != null)
            {
                string _Data = "";
                foreach(string d in _TmpReturn) { _Data += d + Environment.NewLine; }
                System.IO.File.WriteAllText(OutputFile, _Data);
            }

            return _TmpReturn;
        }
    }
}
