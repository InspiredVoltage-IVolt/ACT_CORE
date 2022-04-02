using ACT.Core.Extensions;

namespace ACT.Core.Security
{
    internal static class Protection
    {
        private static readonly byte[] CrazySauce = new byte[] { 34, 76, 80, 28, 19, 4, 22, 73 };

        public static string UnProtectByUser(this string x)
        {
            var _ProtectedData = System.Security.Cryptography.ProtectedData.Unprotect(x.FromBase64String(), CrazySauce, System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return System.Text.Encoding.Default.GetString(_ProtectedData);
        }

        public static string ProtectByUser(this string x)
        {
            var _ProtectedData = System.Security.Cryptography.ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(x), CrazySauce, System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return _ProtectedData.ToBase64String();
        }

        public static string UnProtectByMachine(this string x)
        {
            var _ProtectedData = System.Security.Cryptography.ProtectedData.Unprotect(x.FromBase64String(), CrazySauce, System.Security.Cryptography.DataProtectionScope.LocalMachine);
            return System.Text.Encoding.Default.GetString(_ProtectedData);
        }

        public static string ProtectByMachine(this string x)
        {
            var _ProtectedData = System.Security.Cryptography.ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(x), CrazySauce, System.Security.Cryptography.DataProtectionScope.LocalMachine);
            return _ProtectedData.ToBase64String();
        }
    }
}
