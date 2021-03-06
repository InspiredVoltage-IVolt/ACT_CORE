using ACT.Core.Enums;
using ACT.Core.Extensions;
using ACT.Core.Interfaces;
using ACT.Core.Interfaces.Common;
using ACT.Core.Interfaces.Encoding;
using ACT.Core.Interfaces.Security;
using System.Reflection;
using System.Xml.Serialization;

namespace ACT.Core
{
    /// <summary>
    /// Global Implementation of the DIP_Core Interface.
    /// </summary>
    [Serializable()]
    public class ACT_Core : I_Core
    {
        public string PerformStandardTextReplacement(string instr, Enums.RepacementStandard ReplacementFormats)
        {
            return instr;
        }
        public string PerformStandardTextReplacement(string instr)
        {
            return instr;
        }

        public List<Exception> GetCachedErrors()
        {
            throw new NotImplementedException();
        }

        I_Result I_Core.HealthCheck()
        {
            throw new NotImplementedException();
        }

        #region Private Fields

        [NonSerialized()]
        private I_UserInfo _Current_UserInfo;


        private bool _HasChanged;

        /// <summary>   Options for controlling the operation. </summary>        
        [NonSerialized()]
        Dictionary<string, string> _Settings = new Dictionary<string, string>();

        #endregion Private Fields

        #region Public Fields

        /// <summary>
        /// Extra Configuration
        /// </summary>
        public Dictionary<string, string> ExtraConfigurationData = new Dictionary<string, string>();

        public event EventHandler ClassChanged;

        #endregion Public Fields

        #region Public Properties       
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets information describing the current user. </summary>
        ///
        /// <value> Information describing the current user. </value>
        ///-------------------------------------------------------------------------------------------------
        [XmlIgnore]
        public I_UserInfo Current_UserInfo
        {
            get { return _Current_UserInfo; }
            set { _Current_UserInfo = value; }
        }

        /// <summary>
        /// Returns or Sets Has Changed.  NOTICE if you get the value it resets to false automatically
        /// </summary>
        public virtual bool HasChanged
        {
            get
            {
                HasChanged = false;
                return _HasChanged;
            }
            set
            {
                _HasChanged = value;
            }
        }              
        /// <summary>
        /// Returns all the Properties in the class
        /// </summary>
        public List<string> PublicProperties
        {
            get
            {
                List<string> keys = new List<string>();
                Type thisInstance = this.GetType();

                PropertyInfo[] properties = thisInstance.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    keys.Add(property.Name);
                }

                return keys;
            }
        }

        public dynamic GetConfigurationValue() { return ""; }

        public bool CacheErrors { get; set; } = true;

        public string[] AvailableEncodingFormats => throw new NotImplementedException();

        public List<string> PropertiesMonitoredForChange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> RequiredProperties { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConfigurationJSONFileName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Not Implemented on the Global Level Must Override if needed
        /// </summary>        
        /// <returns></returns>
        public virtual void Dispose()
        {
            foreach (string propName in PublicProperties)
            {
                var _PropVal = ReturnProperty(propName);

                if (_PropVal is IDisposable)
                {
                    if (_PropVal == null) { (_PropVal as IDisposable).Dispose(); }
                }
            }
        }

        /// <summary>
        /// Not Implemented on the Global Level Must Override if needed
        /// </summary>
        /// <returns></returns>
        public virtual string ExportXMLData()
        {
            string _tmpReturn = "<" + this.GetType().FullName.Replace(".", "-") + ">" + System.Environment.NewLine;
            _tmpReturn += "<properties>" + System.Environment.NewLine;

            foreach (string x in this.PublicProperties)
            {
                _tmpReturn += "<" + x.ToLower() + "><![CDATA[" + this.ReturnProperty(x).ToString() + "]]>" + "</" + x.ToLower() + ">";
            }

            _tmpReturn += "</properties>" + System.Environment.NewLine;
            _tmpReturn += "</" + this.GetType().FullName.Replace(".", "-") + ">" + System.Environment.NewLine;
            return _tmpReturn;
        }

        /// <summary>
        /// Not Implemented on the Global Level Must Override if needed
        /// </summary>      
        /// <returns></returns>
        public virtual List<Exception> GetErrors()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks All Of the Base Functionality
        /// </summary>
        /// <returns>Test Result</returns>
        public virtual I_Result HealthCheck()
        {
            I_Result _CurrentResult = CurrentCore<I_Result>.GetCurrent();

            _CurrentResult.Success = true;

            try
            {               
                if (ValidatePluginRequirements().Success == false)
                {
                    throw new Exception("Error In Validating Plugin Requirements");
                }
            }
            catch (Exception ex)
            {
                _CurrentResult.Success = false;
                string _Error;
                _Error = ex.Message;
                if (ex.InnerException != null)
                {
                    _Error += " " + ex.InnerException.Message;
                }
                _CurrentResult.Messages.Add(_Error);

            }

            return _CurrentResult;
            //return ACT.Core.CurrentCore<I_Result>.GetCurrent();
        }

        public virtual bool Load(string JSONData)
        {
            return false;
        }

        public bool LoadConfiguration(string JSONData)
        {
            throw new NotImplementedException();
        }
                
        /// <summary>
        /// Returns the Property Value as a Object
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>Object</returns>
        public object ReturnProperty(string PropertyName)
        {
            Type thisInstance = this.GetType();

            PropertyInfo property = thisInstance.GetProperty(PropertyName);
            object _TmpReturn = property.GetValue(this, null);

            property = null;
            thisInstance = null;

            return _TmpReturn;
        }

        public Type ReturnPropertyType(string PropertyName)
        {
            Type thisInstance = this.GetType();

            PropertyInfo property = thisInstance.GetProperty(PropertyName);
            return property.PropertyType;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Returns system setting requirements. </summary>
        ///
        /// <remarks>   Mark Alicz, 7/20/2022. </remarks>
        ///
        /// <returns>   The system setting requirements. </returns>
        ///-------------------------------------------------------------------------------------------------
        public virtual List<string> ReturnSystemSettingRequirements()
        {
            List<string> _tmpReturn = new List<string>();
            return _tmpReturn;
        }

        public virtual bool Save(string FilePath)
        {
            return false;
        }

        public bool SaveConfiguration(string FilePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the Impersonation of the User Making Database Commands Which are not implmented.
        /// </summary>
        /// <param name="UserInfo"></param>
        public virtual void SetImpersonate(I_UserInfo UserInfo)
        {
            _Current_UserInfo = UserInfo;
        }

        /// <summary>
        /// Sets the property by trying to cast the object as the property type.
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="value"></param>
        /// <returns>I_Result</returns>
        public I_Result SetProperty(string PropertyName, object value)
        {
            I_Result _TmpReturn = CurrentCore<ACT.Core.Interfaces.Common.I_Result>.GetCurrent();

            try
            {
                Type thisInstance = this.GetType();

                PropertyInfo property = thisInstance.GetProperty(PropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                value = value.CorrectTypeValue(property.PropertyType);

                property.SetValue(this, value, null);

                _TmpReturn.Success = true;
            }
            catch (Exception ex)
            {               
                _TmpReturn.Success = false;
                _TmpReturn.Exceptions.Add(ex);
                _TmpReturn.Messages.Add("Error setting property");
            }

            return _TmpReturn;
        }

        /// <summary>
        /// Performs the standard replacement of the Classes Members.
        /// </summary>
        /// <param name="instr">String To Replace Data In</param>
        /// <param name="InputStandard">Currently Only UPPERCASE and IGNORECASE is Supported</param>
        /// <returns>Replaced String</returns>
        public virtual string StandardReplaceMent(string instr, ACT.Core.Enums.RepacementStandard InputStandard)
        {
            string _TmpReturn = "";

            foreach (string _prop in this.PublicProperties)
            {
                string _propertyName = _prop;
                var p = this.ReturnProperty(_prop);

                if (p == null) { p = ""; }

                if (InputStandard == RepacementStandard.UPPERCASE) { _propertyName = _prop.ToUpper(); }

                if (_TmpReturn.Contains("###" + _propertyName + "###"))
                {
                    _TmpReturn = _TmpReturn.Replace("###" + _propertyName + "###", p.ToString());
                }

                if (InputStandard == RepacementStandard.IGNORECASE)
                {
                    if (_TmpReturn.Contains("###" + _propertyName + "###", true))
                    {
                        int _StartingIndex = -1;
                        int _EndIndex = 0;

                        while (true)
                        {
                            _StartingIndex = _TmpReturn.IndexOf("###" + _propertyName + "###", StringComparison.CurrentCultureIgnoreCase);
                            if (_StartingIndex < 1) { break; }
                            _EndIndex = _TmpReturn.IndexOf("###", _StartingIndex + 3);
                            string _tmp = _TmpReturn;
                            _tmp = _TmpReturn.Substring(0, _StartingIndex) + p.ToString() + _TmpReturn.Substring(_EndIndex + 3);
                            _TmpReturn = _tmp;
                        }
                    }
                }
            }

            return _TmpReturn;
        }

        /// <summary>
        /// Validate the Plugin
        /// </summary>
        /// <returns><see cref="ACT.Core.Interfaces.Common.I_Result">I_Result</see></returns>         
        public virtual I_Result ValidatePluginRequirements()
        {
            var _TmpReturn = SystemSettings.MeetsExpectations((I_Plugin)this);
            return _TmpReturn;
        }



        public string EncodeText(string Input, string Format, I_EncoderRules Rules)
        {
            throw new NotImplementedException();
        }
        

        public void LogError(string className, string summary, Exception ex, string additionInformation, Enums.Common.Error_Code_Severity  errorType)
        {
            throw new NotImplementedException();
        }


        public void LogError(string className, string summary, Exception ex, string additionInformation, string errorType)
        {
            throw new NotImplementedException();
        }

        public void DLogError(string className, string summary, Exception ex, string additionInformation, string errorType)
        {
            throw new NotImplementedException();
        }

        public object GetPropertyValue(string PropertyName)
        {
            throw new NotImplementedException();
        }

        public Type GetPropertyType(string PropertyName)
        {
            throw new NotImplementedException();
        }

        public I_Result SetPropertyValue(string PropertyName, object value)
        {
            throw new NotImplementedException();
        }

        public dynamic GetConfigurationValue(string Key)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods


    }
}
