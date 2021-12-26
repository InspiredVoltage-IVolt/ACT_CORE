using ACT.Core.Interfaces.Common;

namespace ACT.Core.BuiltInPlugins.Common
{
    internal class ACT_ResultExpanded : I_ResultExpanded
    {
        Guid _TransactionID = Guid.NewGuid();

        public Guid TransactionID { get { return _TransactionID; } set { } }

        public List<Exception> Exceptions { get; set; }
        public List<string> Messages { get; set; }
        public bool Success { get; set; }
        public List<string> Warnings { get; set; }
        public bool HasWarnings { get; set; }
        public bool ExitProcess { get; set; }

        public object[] ReturnData { get; set; }
    }
}
