namespace ACT.Core.Exceptions
{
    public class ACT_Exception : Exception
    {

    }

    public class Missing_Encryption_Key : ACT_Exception
    {
        public override string Message => "Error Locating or Setting Internal Encrpyption Data";
        public override string HelpLink
        {
            get { return "https://ACT-NET.us/Documentations/ACT_Core/Exceptions/1000000000000001.html?" + Message; }
        }
    }
}
