using ACT.Core.Extensions;

namespace ACT.Core
{
    internal static class Protection
    {
        public static string UnProtect(this string x)
        {
            var _ProtectedData = System.Security.Cryptography.ProtectedData.Unprotect(x.FromBase64String(), null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return System.Text.Encoding.Default.GetString(_ProtectedData);
        }

        public static string Protect(this string x)
        {
            var _ProtectedData = System.Security.Cryptography.ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(x), null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return _ProtectedData.ToBase64String();
        }
    }
}
