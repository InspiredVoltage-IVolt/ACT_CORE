using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Core.BuiltInPlugins.Security
{
    public class ACT_Author : ACT.Core.Interfaces.Security.I_Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> AdditionalInformation { get; set; }
        public string DateLastEdited { get; set; }
        public string Description { get; set; }

        public string ACTIDHash => ACT.Core.Security.Hashing.SHAHashing.ToSHA256Hash(this.GetHashCode().ToString(), true);
    }
}
