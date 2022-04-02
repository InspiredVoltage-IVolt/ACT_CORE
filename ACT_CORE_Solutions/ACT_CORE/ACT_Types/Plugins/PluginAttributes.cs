// ***********************************************************************
// Assembly         : ACT_Core
// Author           : MarkAlicz
// Created          : 02-26-2022
//
// Last Modified By : MarkAlicz
// Last Modified On : 03-04-2022
// ***********************************************************************
// <copyright file="CurrentCore.cs" company="IVOLT LLC">
//     Copyright ©  2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using ACT.Core.Extensions;
using ACT.Core.Interfaces.DataAccess;

namespace ACT.Core.ACT_Types.Plugins
{
    /// <summary>
    /// Plugin Arguments Defines the Information needed to load a Assembly.
    /// </summary>
    public class PluginArguments
    {
        /// <summary>The loaded</summary>
        public bool Loaded = false;

        /// <summary>Full DLL Name (i.e) MyDLL.dll</summary>
        public string DLLName { get; set; }

        /// <summary>Full Class Name (i.e) MyNameSpace.MySub.MyClass</summary>
        public string FullClassName { get; set; }

        /// <summary>Defines if the class should be treated like a singleton or not</summary>
        public bool StoreOnce = false;

        /// <summary>Optional Arguments the are required to create an instance of the class</summary>
        public List<object> Arguments = new List<object>();

        /// <summary>Empty Constructor for Generic Use</summary>
        public PluginArguments() { }

        /// <summary>Loads the Plugin Arguments From the SystemConfiguration File Settings</summary>
        /// <param name="Interface">The interface.</param>
        /// <exception cref="Exception">Error Locating System Setting: " + Interface</exception>
        public PluginArguments(string Interface)
        {
            /* 
         string _Delimeter = ACT.Core.SystemSettings.GetSettingByName("Delimeter").Value;
         DLLName = ACT.Core.SystemSettings.GetSettingByName(Interface).Value;
         FullClassName = ACT.Core.SystemSettings.GetSettingByName(Interface + ".FullClassName").Value;
         string _StoreClass = ACT.Core.SystemSettings.GetSettingByName(Interface + ".StoreOnce").Value;

            if (FullClassName.NullOrEmpty() == true)
            {
                //ACT.Core.Helper.ErrorLogger.LogError(this, "Error Locating System Setting " + Interface, null, Enums.ErrorLevel.Critical);
                throw new Exception("Error Locating System Setting: " + Interface);
            }

            if (!String.IsNullOrEmpty(_StoreClass))
            {
                if (_StoreClass.ToLower() == "true")
                {
                    StoreOnce = true;
                }
            }

          string _Args = ACT.Core.SystemSettings.GetSettingByName(Interface + ".Args").Value;

            if (!String.IsNullOrEmpty(_Args))
            {
                string[] _Data = _Args.SplitString(_Delimeter, StringSplitOptions.RemoveEmptyEntries);

                foreach (string _x in _Data)
                {
                    Arguments.Add(_x);
                }
            }
        */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginArguments"/> class.
        /// </summary>
        /// <param name="Interface">The interface.</param>
        /// <param name="CustomSettings">The custom settings.</param>
        public PluginArguments(string Interface, dynamic CustomSettings)
        {
            /*
            if (CustomSettings.GetSettingByName(Interface) == null) { return; }
            if (CustomSettings.GetSettingByName("Delimeter") == null) { return; }
            if (CustomSettings.GetSettingByName(Interface + ".FullClassName") == null) { return; }
            if (CustomSettings.GetSettingByName(Interface + ".StoreOnce") == null) { return; }

            string _Delimeter = CustomSettings.GetSettingByName("Delimeter").Value;
            DLLName = CustomSettings.GetSettingByName(Interface).Value;
            FullClassName = CustomSettings.GetSettingByName(Interface + ".FullClassName").Value;
            string _StoreClass = CustomSettings.GetSettingByName(Interface + ".StoreOnce").Value;

            if (!String.IsNullOrEmpty(_StoreClass))
            {
                if (_StoreClass.ToLower() == "true")
                {
                    StoreOnce = true;
                }
            }

            try
            {
                string _Args = ACT.Core.SystemSettings.GetSettingByName(Interface + ".Args").Value;

                if (_Args.NullOrEmpty() == false)
                {
                    string[] _Data = _Args.SplitString(_Delimeter, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string _x in _Data)
                    {
                        Arguments.Add(_x);
                    }
                }
            }
            catch { }*/
        }
    }

}