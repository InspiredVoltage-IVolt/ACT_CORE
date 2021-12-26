namespace ACT.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EncryptAllFields : Attribute
    {
        public Guid EncryptionKeyID { get { return _EncryptionKeyID; } }
        private Guid _EncryptionKeyID = Guid.Empty;

        public EncryptAllFields(Guid encryptionKeyID)
        {
            _EncryptionKeyID = encryptionKeyID;
            // var zip = File.OpenWrite("\\aasdas.zip");

        }
    }
}
