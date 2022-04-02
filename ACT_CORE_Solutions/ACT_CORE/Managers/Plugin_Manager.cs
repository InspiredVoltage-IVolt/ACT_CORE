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
using ACT.Core.ACT_Types.Plugins;

namespace ACT.Core
{
 
    /// <summary>
    /// Current Core Represents the Entry Point for all Plugins.  Use this to gauruntee you get the defined plugin
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class CurrentCore<T>
    {
        /// <summary>
        /// Gets the cached assemblies.
        /// </summary>
        /// <value>The cached assemblies.</value>
        public static Dictionary<(Type, string), System.Reflection.Assembly> CachedAssemblies { get { return _CachedAssemblies; } }
        /// <summary>
        /// The cached assemblies
        /// </summary>
        private static Dictionary<(Type, string), System.Reflection.Assembly> _CachedAssemblies = new Dictionary<(Type, string), System.Reflection.Assembly>();
        /// <summary>
        /// The cached classes
        /// </summary>
        private static Dictionary<Type, object> _CachedClasses = new Dictionary<Type, object>();

        #region Methods (9)

        /// <summary>
        /// Adds the cached assembly.
        /// </summary>
        /// <param name="DLL">The DLL.</param>
        /// <param name="Type">The type.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool AddCachedAssembly(string DLL, string Type)
        {
            System.Reflection.Assembly _A;

            try
            {
                _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + DLL);
            }
            catch
            {
                try
                {
                    _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "bin\\" + DLL);
                }
                catch
                {
                    try { _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "plugins\\" + DLL); }
                    catch
                    {
                        try { _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "bin\\plugins\\" + DLL); }
                        catch { return false; }
                    }
                }
            }
            if (_A == null) { return false; }
            else
            {
                var _T = System.Type.GetType(Type);
                if (_CachedAssemblies.ContainsKey((_T, _T.FullName)) == false)
                {
                    _CachedAssemblies.Add((_T, _T.FullName), _A);
                }
                return true;
            }
        }
        /// <summary>
        /// Installation Locations
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> ACTInstallLocations()
        {
            string[] _ACTLocations = new string[] { "c:\\act\\", "d:\\act\\", "d:\\program files\\ACT\\", "c:\\program files\\ACT\\", "D:\\Program Files (x86)\\ACT\\", "C:\\Program Files (x86)\\ACT\\" };

            List<string> _TmpReturn = new List<string>();

            foreach (string loc in _ACTLocations)
            {
                if (System.IO.File.Exists(loc + "SystemConfiguration.xml"))
                {
                    _TmpReturn.Add(loc);
                }
            }

            return _TmpReturn;
        }

        /// <summary>
        /// Gets the Current Default Interface Implementation as Defined in the Plugins Section of the Configuration File
        /// </summary>
        /// <returns>T.</returns>
        /// <exception cref="System.TypeLoadException">
        /// Error Locating " + typeof(T).FullName
        /// or
        /// Error Locating " + typeof(T).FullName
        /// </exception>
        public static T GetCurrent()
        {
            PluginArguments _PluginInfo;

            if (_CachedClasses.ContainsKey(typeof(T)))
            {
                if (_CachedClasses[typeof(T)] == null)
                {
                    _CachedClasses.Remove(typeof(T));
                }
                else
                {
                    return (T)_CachedClasses[typeof(T)];
                }
            }

            _PluginInfo = new PluginArguments(typeof(T).FullName);

            System.Reflection.Assembly _A;
            object _TmpClass;

            if (_CachedAssemblies.ContainsKey((typeof(T), typeof(T).FullName)))
            {
                _A = _CachedAssemblies[(typeof(T), typeof(T).FullName)];
                _TmpClass = _A.CreateInstance(_PluginInfo.FullClassName, true, System.Reflection.BindingFlags.CreateInstance, null, _PluginInfo.Arguments.ToArray(), System.Globalization.CultureInfo.CurrentCulture, null);
            }
            else
            {
                if (_PluginInfo.DLLName != "")
                {
                    try
                    {
                        if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + _PluginInfo.DLLName))
                        {
                            _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + _PluginInfo.DLLName);
                        }
                        else if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "bin\\" + _PluginInfo.DLLName))
                        {
                            _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "bin\\" + _PluginInfo.DLLName);
                        }
                        else if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "bin\\plugins\\" + _PluginInfo.DLLName))
                        {
                            _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "bin\\plugins\\" + _PluginInfo.DLLName);
                        }
                        else
                        {
                            // TODO - Log Error
                            // THEN ERASE LINE 1 - Helper.ErrorLogger.LogErrorToDisk("CurrentCore<>.GetCurrent() + Error locating DLL: " + _PluginInfo.DLLName);
                            throw new System.TypeLoadException("Error Locating " + typeof(T).FullName);
                        }

                        _CachedAssemblies.Add((typeof(T), typeof(T).FullName), _A);
                        _TmpClass = _A.CreateInstance(_PluginInfo.FullClassName, true, System.Reflection.BindingFlags.CreateInstance, null, _PluginInfo.Arguments.ToArray(), System.Globalization.CultureInfo.CurrentCulture, null);

                    }
                    catch (Exception ex)
                    {
                        throw new System.TypeLoadException("Error Locating " + typeof(T).FullName, ex);
                    }

                }
                else
                {
                    _TmpClass = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(_PluginInfo.FullClassName);
                }
            }

            if (_PluginInfo.StoreOnce == true)
            {
                _CachedClasses.Add(typeof(T), _TmpClass);
            }

            return (T)_TmpClass;
        }

        /// <summary>
        /// Gets the Current Default Interface Implementation as Defined in the Plugins Section of the Configuration File
        /// </summary>
        /// <param name="SettingsInstance">The settings instance.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.TypeLoadException">Error Locating " + typeof(T).FullName</exception>
        public static T GetCurrent(dynamic SettingsInstance)
        {
            PluginArguments _PluginInfo;

            if (_CachedClasses.ContainsKey(typeof(T)))
            {
                if (_CachedClasses[typeof(T)] == null)
                {
                    _CachedClasses.Remove(typeof(T));
                }
                else
                {
                    return (T)_CachedClasses[typeof(T)];
                }
            }

            _PluginInfo = new PluginArguments(typeof(T).FullName, SettingsInstance);

            System.Reflection.Assembly _A;
            object _TmpClass;

            if (_CachedAssemblies.ContainsKey((typeof(T), typeof(T).FullName)))
            {
                _A = _CachedAssemblies[(typeof(T), typeof(T).FullName)];
                _TmpClass = _A.CreateInstance(_PluginInfo.FullClassName, true, System.Reflection.BindingFlags.CreateInstance, null, _PluginInfo.Arguments.ToArray(), System.Globalization.CultureInfo.CurrentCulture, null);
            }
            else
            {
                if (_PluginInfo.DLLName != "")
                {
                    try
                    {
                        try
                        {
                            _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + _PluginInfo.DLLName);
                        }
                        catch
                        {
                            _A = System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "bin\\" + _PluginInfo.DLLName);
                        }

                        _CachedAssemblies.Add((typeof(T), typeof(T).FullName), _A);
                        _TmpClass = _A.CreateInstance(_PluginInfo.FullClassName, true, System.Reflection.BindingFlags.CreateInstance, null, _PluginInfo.Arguments.ToArray(), System.Globalization.CultureInfo.CurrentCulture, null);

                    }
                    catch (Exception ex)
                    {
                        throw new System.TypeLoadException("Error Locating " + typeof(T).FullName, ex);
                    }

                }
                else
                {
                    _TmpClass = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(_PluginInfo.FullClassName);
                }
            }

            if (_PluginInfo.StoreOnce == true)
            {
                _CachedClasses.Add(typeof(T), _TmpClass);
            }

            return (T)_TmpClass;
        }

        /// <summary>
        /// Returns the Interface implementation as defined by the custom plugin arguments
        /// </summary>
        /// <param name="Plugin">Plugin Arguments Defining Interface Implementation</param>
        /// <returns>T.</returns>
        /// <exception cref="System.TypeLoadException">
        /// Plugin is not of Type " + typeof(T).FullName
        /// or
        /// Error Locating " + typeof(T).FullName + " Plugin
        /// or
        /// Error Locating " + typeof(T).FullName + " Plugin
        /// </exception>
        public static T GetSpecific(PluginArguments Plugin)
        {
            T _TmpClass;
            System.Reflection.Assembly _A;

            if (!Plugin.DLLName.NullOrEmpty())
            {

                try
                {
                    _A = System.Reflection.Assembly.LoadFile(Plugin.DLLName);

                    if (!(_A is I_DataAccess))
                    {

                        throw new System.TypeLoadException("Plugin is not of Type " + typeof(T).FullName);
                    }
                }
                catch (Exception ex)
                {
                    throw new System.TypeLoadException("Error Locating " + typeof(T).FullName + " Plugin", ex);
                }
            }
            else
            {
                try
                {
                    _A = System.Reflection.Assembly.GetExecutingAssembly();
                }
                catch (Exception ex)
                {
                    throw new System.TypeLoadException("Error Locating " + typeof(T).FullName + " Plugin", ex);
                }
            }

            if (!_CachedAssemblies.ContainsKey((typeof(T), typeof(T).FullName)))
            {
                _CachedAssemblies.Add((typeof(T), typeof(T).FullName), _A);
            }
            _TmpClass = (T)_A.CreateInstance(Plugin.FullClassName, true, System.Reflection.BindingFlags.CreateInstance, null, Plugin.Arguments.ToArray(), System.Globalization.CultureInfo.CurrentCulture, null);
            return _TmpClass;
        }

        #endregion Methods



    }
}
