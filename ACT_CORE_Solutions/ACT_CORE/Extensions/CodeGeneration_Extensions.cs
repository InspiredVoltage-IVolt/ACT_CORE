using ACT.Core.Extensions;

namespace ACT.Core.SupportExtensions
{
    public static class CodeGeneration_Extensions
    {
        /// <summary>
        /// Generates the primary key select list MSSQL.
        /// </summary>
        /// <param name="Table">The table.</param>
        /// <returns>System.String.</returns>
        public static string GeneratePrimaryKeySelectListMSSQL(this ACT.Core.Interfaces.DataAccess.I_DbTable Table)
        {

            string _TmpReturn = "";

            foreach (var c in Table.Columns)
            {
                if (c.IsPrimaryKey)
                {
                    if (Table.Name.StartsWith("["))
                    {
                        _TmpReturn = Table.Name.Substring(Table.Name.IndexOf("[dbo].[") + 7).TrimEnd("]") + "." + c.ShortName + ", ";
                        //_TmpReturn += Table.Name + "." + c.ShortName + ", ";
                    }
                    else
                    {
                        _TmpReturn += "[" + Table.Name + "].[" + c.ShortName + "], ";

                    }
                }
            }

            return _TmpReturn.TrimEnd(", ".ToCharArray());
        }

    }
}
