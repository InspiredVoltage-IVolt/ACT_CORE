﻿using ACT.Core.Interfaces.Common;
using ACT.Core.Interfaces.DataAccess;

namespace ACT.Plugins.DataAccess
{
    public class ACT_DbStoredProcedure : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DbStoredProcedure
    {

        int _AgeInDays = -1;
        List<I_DbStoredProcedureParameter> _Parameters = new List<I_DbStoredProcedureParameter>();

        /// <summary>
        /// Name of the Stored Proc
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Name of the Owner (Schema)
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Age In Days Since The Procedure Was Last Modified
        /// </summary>
        public int AgeInDays { get { return _AgeInDays; } set { _AgeInDays = value; } }



        /// <summary>
        /// All of the Parameters
        /// </summary>
        public List<I_DbStoredProcedureParameter> Parameters
        {
            get
            {
                return _Parameters;
            }
            set
            {
                _Parameters = value;
            }
        }

        /// <summary>
        /// Fully Qualified Database Name
        /// </summary>
        public string FullName { get { return "[" + Owner + "].[" + Name + "]"; } }

        /// <summary>
        /// Short Name No Schema Qualifier
        /// </summary>
        public string ShortName { get { return "[" + Name + "]"; } }

        /// <summary>
        /// Returns the comments saved for the stored procedure
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Returns the Code
        /// </summary>
        public string Code { get; set; }


        /// <summary>
        /// Lists the Plugin Requirements for this Class
        /// </summary>
        /// <returns></returns>
        public override I_Result ValidatePluginRequirements()
        {
            var _TR = ACT.Core.CurrentCore<ACT.Core.Interfaces.Common.I_Result>.GetCurrent();
            _TR.Success = true;

            return _TR;
        }

        /// <summary>
        /// Run Health Check
        /// </summary>
        /// <returns></returns>
        public override I_Result HealthCheck()
        {
            return ValidatePluginRequirements();
        }

        public List<string> ReturnSystemSettingRequirements(bool PerformReplacements = false)
        {
            throw new NotImplementedException();
        }

        public List<string> ReturnRequiredFiles(bool PerformReplacements = false)
        {
            throw new NotImplementedException();
        }
    }
}
