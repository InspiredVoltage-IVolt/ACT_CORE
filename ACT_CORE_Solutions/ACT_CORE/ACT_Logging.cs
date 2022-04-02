namespace ACT.Core
{
    public static class _
    {
        public static void LogBasicInfo(string Message)
        {
            var _L = NLog.LogManager.GetCurrentClassLogger();
            _L.Log(NLog.LogLevel.Info, Message);

        }

        public static void LogBasicInfoWithException(string Message, Exception ex)
        {
            var _L = NLog.LogManager.GetCurrentClassLogger();
            _L.Log(NLog.LogLevel.Info, ex, Message, null);

        }

        public static void LogFatalError(string Message, Exception ex)
        {
            var _L = NLog.LogManager.GetCurrentClassLogger();
            _L.Log(NLog.LogLevel.Fatal, ex, Message, null);

        }
    }
}
