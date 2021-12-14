namespace ACT.Core.Attributes
{

    public class Helper
    {
        /// <summary>
        /// Helper Method to Grab the Value of an Attribute on a Method
        /// </summary>
        /// <example>var name = GetMethodAttributeValue<MyAttribute, string>(MyMethod, x => x.Name);</example>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="action"></param>
        /// <param name="valueSelector"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetMethodAttributeValue<TAttribute, TValue>(Action action, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            if (valueSelector == null) { throw new ArgumentNullException(nameof(valueSelector)); }
            if (action == null) { throw new ArgumentNullException(nameof(action)); }

            var methodInfo = action.Method;
            TAttribute? attr = methodInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null) { throw new ArgumentNullException(nameof(attr)); }
            else
            {
                var _tmpReturn = valueSelector(attr);
                if (_tmpReturn != null) { return _tmpReturn; }
                else { throw new ArgumentNullException("Default Value Is Null"); }
            }

        }
    }
}
