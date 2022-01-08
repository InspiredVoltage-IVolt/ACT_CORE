using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACT.Core.Extensions;
using ACT.Core.Interfaces.CodeGeneration;
using ACT.Core.Interfaces.DataAccess;

namespace ACT.Plugins.CodeGeneration.MSSQL
{
    /// <summary>
    /// Generates MSSQL Code including CRUD Operatons, Relational Lookups, and Anything Else Defined
    /// </summary>
    public partial class ACT_MSSQL_GenerateCode : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.CodeGeneration.I_CodeGenerator         
    {
        /// <summary>
        /// Constructor for ACT_MSSQL_GenerateCode
        /// </summary>
        public ACT_MSSQL_GenerateCode()
        {
        }

        public List<I_Generated_Code> GenerateCode(I_Code_Generation_Settings CodeSettings)
        {
            throw new NotImplementedException();
        }

        public List<I_Generated_Code> GenerateCode(I_Db Database, I_Code_Generation_Settings CodeSettings)
        {
            throw new NotImplementedException();
        }

        public List<I_Generated_Code> GenerateWebFormCode(I_Code_Generation_Settings CodeSettings)
        {
            throw new NotImplementedException();
        }
    }
}