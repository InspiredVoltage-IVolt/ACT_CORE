namespace ACT.Core.BuiltInPlugins.Security
{
    public class ACT_SimpleSecurity : ACT.Core.Interfaces.Security.I_Encryption
    {
        public byte[] Decrypt(byte[] cipherData, string Salt, byte[] IV, string Password)
        {

            throw new NotImplementedException();
        }

        public string Decrypt(string ClearText)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, string Password)
        {
            throw new NotImplementedException();
        }

        public byte[] Decrypt(byte[] cipherData, string Password)
        {
            throw new NotImplementedException();
        }

        public void Decrypt(string fileIn, string fileOut, string Password)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string clearText)
        {
            return ACT.Core.Security.Encryption.EncryptString(clearText, "asd");
        }

        public string Encrypt(string clearText, string Password)
        {
            return ACT.Core.Security.Encryption.EncryptString(clearText, Password);
        }

        public byte[] Encrypt(byte[] clearData, string Password)
        {
            throw new NotImplementedException();
        }

        public void Encrypt(string fileIn, string fileOut, string Password)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] clearData, string Salt, byte[] IV, string Password)
        {
            throw new NotImplementedException();
        }

        public bool HealthCheck()
        {
            throw new NotImplementedException();
        }

        public string MD5(string value)
        {
            throw new NotImplementedException();
        }

        public string MD5ALT(string value)
        {
            throw new NotImplementedException();
        }

        public string SHA256(string value)
        {
            throw new NotImplementedException();
        }

        public string SHA512(string value)
        {
            throw new NotImplementedException();
        }
    }
}
