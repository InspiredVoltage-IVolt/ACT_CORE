using ACT.Core.Extensions;

namespace ACT.Core.Attributes
{
    /// Class ClassID.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassID : System.Attribute
    {
        /// <summary>
        /// The internal
        /// </summary>
        private string _Internal;

        /// <summary>
        /// Gets or sets the internal.
        /// </summary>
        /// <value>The internal.</value>
        public string InternalID { get { return _Internal; } set { _Internal = value; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classid"></param>
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassID"/> class.
        /// </summary>
        /// <param name="classid">The classid.</param>
        public ClassID(string classid)
        {
            _Internal = classid;
        }

        public ClassID()
        { }
        public void CalculateID(Type ClassType)
        {
            string _Data = "";

            foreach (var mem in ClassType.GetMembers())
            {
                _Data += mem.GetHashCode().ToString();
            }

            foreach (var fld in ClassType.GetFields())
            {
                _Data += fld.GetHashCode().ToString();
            }

            foreach (var prop in ClassType.GetProperties())
            {
                _Data += prop.GetHashCode().ToString();
            }

            _Internal = _Data.ComputeHash(Hashing.eHashType.SHA256);
        }
    }

    public class ClassAttribute_Helper
    {
        public static string GetClassID(Type t)
        {
            string _tmpReturn = null;
            if (t == null) { throw new ArgumentNullException(nameof(t)); }

            // Using reflection.  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.  

            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is ClassID)
                {
                    ClassID a = (ClassID)attr;
                    a.CalculateID(t);
                    _tmpReturn = a.InternalID;
                }
            }

            return _tmpReturn;
        }
    }
}
