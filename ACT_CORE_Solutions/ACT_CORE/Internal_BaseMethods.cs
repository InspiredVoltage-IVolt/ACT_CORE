namespace ACT.Core
{
    internal class _ : Interfaces.Common.I_ErrorLoggable
    {
        static internal void Log(Enums.SecurityAccessError Severity, string className, string summary, Exception ex, string additionInformation)
        {
            Severity.
            return;
        }

        public void DLogError(string className, string summary, Exception ex, string additionInformation, string errorType)
        {
            throw new NotImplementedException();
        }

        public void LogError(string className, string summary, Exception ex, string additionInformation, string errorType)
        {
            throw new NotImplementedException();
        }
    }
}
